using System;
using System.Diagnostics;
using System.Threading;

namespace GsUtil
{
    /// <summary>
    /// 一个高速、线程安全的对象池的实现
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ObjectPool<T> where T : class
    {
        [DebuggerDisplay("{Value,nq}")]
        private struct Element
        {
            internal T Value;
        }

        public delegate T Factory();

        // Storage for the pool objects. The first item is stored in a dedicated field because we expect to be able to
        // satisfy most requests from it.
        private T _firstItem;

        private readonly Element[] _items;

        // factory is stored for the lifetime of the pool. We will call this only when pool needs to expand. compared to
        // "new T()", Func gives more flexibility to implementers and faster than "new T()".
        private readonly Factory _factory;

        public ObjectPool(Factory factory) : this(factory, Environment.ProcessorCount * 2)
        { }

        public ObjectPool(Factory factory, int size)
        {
            Debug.Assert(size >= 1);
            _factory = factory;
            _items = new Element[size - 1];
        }

        private T CreateInstance()
        {
            T inst = _factory();
            return inst;
        }

        /// <summary>
        /// Produces an instance.
        /// </summary>
        /// <remarks>
        /// Search strategy is a simple linear probing which is chosen for it cache-friendliness. Note that Free will try
        /// to store recycled objects close to the start thus statistically reducing how far we will typically search.
        /// </remarks>
        public T Allocate()
        {
            // PERF: Examine the first element. If that fails, AllocateSlow will look at the remaining elements. Note
            // that the initial read is optimistically not synchronized. That is intentional. We will interlock only when
            // we have a candidate. in a worst case we may miss some recently returned objects. Not a big deal.
            T inst = _firstItem;
            if (inst == null || inst != Interlocked.CompareExchange(ref _firstItem, null, inst))
            {
                inst = AllocateSlow();
            }

            return inst;
        }

        private T AllocateSlow()
        {
            Element[] items = _items;

            for (int i = 0; i < items.Length; i++)
            {
                // Note that the initial read is optimistically not synchronized. That is intentional. We will interlock
                // only when we have a candidate. in a worst case we may miss some recently returned objects. Not a big deal.
                T inst = items[i].Value;
                if (inst != null)
                {
                    if (inst == Interlocked.CompareExchange(ref items[i].Value, null, inst))
                    {
                        return inst;
                    }
                }
            }

            return CreateInstance();
        }

        /// <summary>
        /// Returns objects to the pool.
        /// </summary>
        /// <remarks>
        /// Search strategy is a simple linear probing which is chosen for it cache-friendliness. Note that Free will try
        /// to store recycled objects close to the start thus statistically reducing how far we will typically search in Allocate.
        /// </remarks>
        public void Free(T obj)
        {
            Validate(obj);

            if (_firstItem == null)
            {
                // Intentionally not using interlocked here. In a worst case scenario two objects may be stored into same
                // slot. It is very unlikely to happen and will only mean that one of the objects will get collected.
                _firstItem = obj;
            }
            else
            {
                FreeSlow(obj);
            }
        }

        private void FreeSlow(T obj)
        {
            Element[] items = _items;
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].Value == null)
                {
                    // Intentionally not using interlocked here. In a worst case scenario two objects may be stored into
                    // same slot. It is very unlikely to happen and will only mean that one of the objects will get collected.
                    items[i].Value = obj;
                    break;
                }
            }
        }

        [Conditional("DEBUG")]
        private void Validate(object obj)
        {
            Debug.Assert(obj != null, "freeing null?");

            Debug.Assert(_firstItem != obj, "freeing twice?");

            var items = _items;
            for (int i = 0; i < items.Length; i++)
            {
                var value = items[i].Value;
                if (value == null)
                {
                    return;
                }

                Debug.Assert(value != obj, "freeing twice?");
            }
        }
    }
}
using System.Diagnostics;
using ApplicationLayer.PropertySettlementSystem;
using ApplicationLayer.System;

namespace ApplicationLayer.EntitySystem
{
    public abstract class Entity : IDamageable
    {
        public string Name;
        public double HealthPointsMAX = 100;
        public double CurrentHealthPoints = 100;
        public bool IsAlive = true;
        public delegate void OnDead(Entity deadEntity);
        public delegate void OnEntityDamaged(Entity deadEntity);
        public event OnDead? OnEntityDeadEvent;
        public event OnEntityDamaged? OnEntityDamagedEvent;
        public Position EntityPosition;
        public Entity(string Name, Position spawnPosition)
        {
            this.Name = Name;
            EntityPosition = spawnPosition;
        }

        public double GetCurrentHealthPoint()
        {
            return CurrentHealthPoints;
        }

        public double GetMaxHealthPoint()
        {
            return HealthPointsMAX;
        }

        public void Heal(double heal)
        {
            if (CurrentHealthPoints + heal > HealthPointsMAX)
            {
                Debug.Print("实体'" + Name + "'受到了治疗，生命值已满");
                CurrentHealthPoints = HealthPointsMAX;
            }
            else
            {
                Debug.Print("实体'" + Name + "'受到了" + heal + "点治疗");
                CurrentHealthPoints += heal;
            }
        }

        public void TakeDamage(double damage)
        {
            
            CurrentHealthPoints -= damage;
            if (CurrentHealthPoints <= 0)
            {
                CurrentHealthPoints = 0;
                Debug.Print("实体'" + Name + "'受到了" + damage + "点伤害");
                OnEntityDamagedEvent?.Invoke(this);
                if (IsAlive)
                {
                    IsAlive = false;
                    Debug.Print("实体'" + Name + "'因受到了" + damage + "点伤害");
                    OnEntityDeadEvent?.Invoke(this);
                }
            }
            else
            {
                Debug.Print("实体'" + Name + "'受到了" + damage + "点伤害");
                OnEntityDamagedEvent?.Invoke(this);
            }
        }
    }
}
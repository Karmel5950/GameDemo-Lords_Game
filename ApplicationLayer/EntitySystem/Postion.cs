using ApplicationLayer.System;

namespace ApplicationLayer.EntitySystem
{
    public abstract class Position
    {
        public double x;
        public double y;
        public Position(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public static Position InitPosition(double x, double y, double z = 0)
        {
            if (SystemConstants.PositonType == GamePositonType.TYPE2D)
            {
                return new Position2D(x, y);
            }
            // else if (SystemConstants.PositonType == GamePositonType.TYPE3D)
            // {
            //     return new Position3D(x, y, z);
            // }
        }
    }
    public class Position2D : Position
    {
        public Position2D(double x, double y) : base(x, y)
        {
        }
    }
    public class Position3D : Position
    {
        public double z;

        public Position3D(double x, double y, double z) : base(x, y)
        {
            this.z = z;
        }
    }
}
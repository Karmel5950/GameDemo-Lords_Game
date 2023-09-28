namespace ApplicationLayer.System
{
    public static class SystemConstants{
        public const double ActionValueMax = 1000;
        public const double GameFramePerSecond = 60;
        public const GamePositonType PositonType = GamePositonType.TYPE2D;

    }

    public enum GamePositonType
    {
        TYPE2D,
        TYPE3D
    }
    


}
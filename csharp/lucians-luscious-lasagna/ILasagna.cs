namespace learncsharp.csharp
{
    public interface ILasagna
    {
        public int ExpectedMinutesInOven();
        public int RemainingMinutesInOven(int remainingMinutes);
        public int PreparationTimeInMinutes(int preparationTime);
        public int ElapsedTimeInMinutes(int numberOfLayer, int numberOfMinutesInOven);
    }
}
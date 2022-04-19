

class Lasagna
{
    private int minutes;

    public int ElapsedTimeInMinutes(int numberOfLayer, int numberOfMinutesInOven)
    {
        return numberOfMinutesInOven + PreparationTimeInMinutes(numberOfLayer);
    }


    public int ExpectedMinutesInOven()
    {
        return this.minutes;
    }

    public int PreparationTimeInMinutes(int preparationTime)
    {
        int defaultMinutesToPrepare = 2;
        return preparationTime * defaultMinutesToPrepare;
    }

    public int RemainingMinutesInOven(int remainingMinutes)
    {
        return this.minutes - remainingMinutes;
    }
    public Lasagna()
    {
        minutes = 40;
    }
}


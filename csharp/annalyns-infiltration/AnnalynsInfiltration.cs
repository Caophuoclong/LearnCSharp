using System;

static class QuestLogic
{
    public static bool CanFastAttack(bool knightIsAwake)
    {
        return !knightIsAwake;
    }

    public static bool CanSpy(bool knightIsAwake, bool archerIsAwake, bool prisonerIsAwake)
    {
        if (!archerIsAwake && !knightIsAwake && prisonerIsAwake)
            return true;
        return knightIsAwake || archerIsAwake;
    }

    public static bool CanSignalPrisoner(bool archerIsAwake, bool prisonerIsAwake)
    {
        return !archerIsAwake && prisonerIsAwake;
    }

    public static bool CanFreePrisoner(bool knightIsAwake, bool archerIsAwake, bool prisonerIsAwake, bool petDogIsPresent)
    {
        if (prisonerIsAwake)
        {
            if (petDogIsPresent)
            {
                if (archerIsAwake)
                    return false;
                return true;

            }
            else
            {
                if (!knightIsAwake && !archerIsAwake)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        else
        {
            if (!knightIsAwake && !archerIsAwake)
            {
                if (petDogIsPresent)
                    return true;
                return false;
            }
            else if (knightIsAwake && !archerIsAwake && petDogIsPresent)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

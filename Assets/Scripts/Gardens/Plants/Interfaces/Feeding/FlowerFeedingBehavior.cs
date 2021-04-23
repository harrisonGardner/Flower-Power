using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerFeedingBehavior : IFeedingBehavior
{
    public int FeedingIntensity { get; }
    public int ThirstIntensity { get; }

    public FlowerFeedingBehavior(int thirst, int hunger)
    {
        FeedingIntensity = hunger;
        ThirstIntensity = thirst;
    }

    public int CollectSunEnergy(Plot plot)
    {
        return plot.removeSunEnergy(FeedingIntensity);
    }

    public int CollectWater(Plot plot)
    {
        return plot.removeWater(ThirstIntensity);
    }
}

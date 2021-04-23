using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFeedingBehavior
{
    public int FeedingIntensity { get; }
    public int ThirstIntensity { get; }

    public int CollectWater(Plot plot);
    public int CollectSunEnergy(Plot plot);
}

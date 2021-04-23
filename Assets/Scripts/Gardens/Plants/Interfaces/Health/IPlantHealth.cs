using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This Interface provides different types of plants to evaluate the
/// core metrics of their health, which may affect their other behaviors
/// </summary>
/// <author>Nicholas Gliserman</author>
public interface IPlantHealth
{
    public bool DyingToday { get; set; } // Set the plant stage as dying
    public bool WiltingToday { get; set; } // Unhealthy today

    public void FeedingToday(int sun, int water);
    public void SetMinFeedingRequirements(int minWater, int minSun);
}
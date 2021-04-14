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
    public bool IsHealthyToday();
    public bool IsWiltingToday();
    public bool IsDyingToday();
}

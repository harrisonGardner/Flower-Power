using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The weed is always healthy and will not die of its own accord --
/// it must be killed by the player with the scissors. 
/// </summary>
/// <author>Nicholas Gliserman</author>
public class WeedHealth : IPlantHealth
{
    public bool Dead { get; set; } = false;
    public bool DyingToday { get; set; } = false;
    public bool WiltingToday { get; set; } = false;
    
    public void FeedingToday(int sun, int water) { }
}

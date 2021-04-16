using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  A Flower's health depends on its ability to secure adequate
///  sun and water.
/// </summary>
/// <author>Nicholas Gliserman</author>
public class FlowerHealth : IPlantHealth
{
    private int MinWaterRequirement { get; }
    private int MinSunRequirement { get; }
    private int MaxSunStorage { get; }
    private int UnhealthyDaysForDying { get; }

    public int SunEnergy { get; set; }
    public int UnhealthyDays { get; set; }

    // INTERFACE PROPERTIES
    public bool DyingToday { get; set; } = false;
    public bool WiltingToday { get; set; } = false;

    public FlowerHealth(int minWater, int minSun, int unhealthyDaysForDying, int sunStorage)
    {
        MinWaterRequirement = minWater;
        MinSunRequirement = minSun;
        UnhealthyDaysForDying = unhealthyDaysForDying;
        MaxSunStorage = sunStorage;
    }

    public void FeedingToday(int sun, int water)
    {
        WiltingToday = false;

        // SUN REQUIREMENTS
        SunEnergy += sun; // ACQUIRE SUN
        SunEnergy -= MinSunRequirement; // CONSUME SUN

        if (SunEnergy > MaxSunStorage) // IF SURPLUS SUN CANNOT BE STORED
            SunEnergy = MaxSunStorage;

        if (SunEnergy < 0) // IF FLOWER HAS NOT HAD ENOUGH SUN
        {
            SunEnergy = 0;
            WiltingToday = true;
        }

        // WATER REQUIREMENTS
        if (water < MinWaterRequirement)
            WiltingToday = true;

        // CHECK on PLANT HEALTH
        // IF PLANT is WILTING, INCREMENT # UNHEALTHY DAYS
        if (WiltingToday)
            UnhealthyDays++;
        else
            UnhealthyDays = 0;

        // CHECK if PLANT is ON DEATH's DOOR (but not already dead)
        if (UnhealthyDays == UnhealthyDaysForDying)
        {
            DyingToday = true;
        }
            

    }

}

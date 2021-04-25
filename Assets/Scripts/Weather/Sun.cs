using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : IWeather
{
    public WeatherType Type { get; set; } = WeatherType.SUN;

    public void SetDaysWeather(Garden garden)
    {
        garden.SunAllPlots(5);
        garden.RemoveWaterFromRandomPlots(4);
    }
}


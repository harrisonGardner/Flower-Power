using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : IWeather
{
    public WeatherType Type { get; set; } = WeatherType.sun;

    public void setDaysWeather(Garden garden)
    {
        garden.SunAllPlots(5);
    }
}


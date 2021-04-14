using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : IWeather
{
    public WeatherType Type { get; set; } = WeatherType.rain;

    public void setDaysWeather(Garden garden)
    {
        garden.WaterAllPlots(7);
    }
}

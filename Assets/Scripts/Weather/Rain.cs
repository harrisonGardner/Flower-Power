using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : IWeather
{
    public WeatherType Type { get; set; } = WeatherType.RAIN;

    public void SetDaysWeather(Garden garden)
    {
        garden.WaterAllPlots(3);
    }
}

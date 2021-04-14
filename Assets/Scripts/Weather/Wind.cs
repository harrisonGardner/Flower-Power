using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : IWeather
{
    public WeatherType Type { get; set; } = WeatherType.wind;

    public void setDaysWeather(Garden garden)
    {
        garden.AdjustWindDirection(Directions.GetRandomDirection());
    }
}

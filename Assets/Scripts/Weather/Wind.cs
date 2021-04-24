using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : IWeather
{
    public WeatherType Type { get; set; } = WeatherType.WIND;
    public Direction RandomDir { get; set; } = Directions.GetRandomDirection();

    public void SetDaysWeather(Garden garden)
    {
        garden.WindyToday = true;
        garden.AdjustWindDirection(RandomDir);

        // SET RANDOM DIRECTION
        RandomDir = Directions.GetRandomDirection();
    }
}

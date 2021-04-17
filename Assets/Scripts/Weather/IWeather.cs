using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeather
{
    public WeatherType Type { get; set; }

    public void SetDaysWeather(Garden garden);
}

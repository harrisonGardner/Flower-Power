using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeatherType { rain, sun, wind }

public interface IWeather
{
    public WeatherType Type { get; set; }

    public void setDaysWeather(Garden garden);
}

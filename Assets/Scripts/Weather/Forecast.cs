using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeatherType { RAIN, SUN, WIND }

/// <summary>
/// Controls the weather state for the next five days
/// </summary>
public class Forecast : MonoBehaviour
{
    private System.Random RandomNum { get; } = new System.Random();
    public int numDaysInForecast = 5;

    private IWeather[] weathers = new IWeather[] { new Rain(), new Sun(), new Wind() };

    public Queue<IWeather> FiveDayForecast { get; }  = new Queue<IWeather>();

    public void LoadFiveDaysWeather()
    {
        for (int i = 0; i < numDaysInForecast; i++)
        {
            AddRandomWeather();
        }
    }

    public void AddRandomWeather()
    {
        int numWeatherTypes = weathers.Length;
        int weatherVal = RandomNum.Next(0, numWeatherTypes);
        FiveDayForecast.Enqueue(weathers[weatherVal]);
    }

    /// <summary>
    /// Returns the weather today, removing it from the queue.
    /// </summary>
    /// <returns></returns>
    public IWeather GetTodaysWeather()
    {
        return FiveDayForecast.Dequeue();
    }
}

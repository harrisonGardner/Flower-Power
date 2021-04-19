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
    static System.Random RandomNum { get; } = new System.Random();
    public static int numDaysInForecast = 5;

    private static IWeather[] weathers = new IWeather[] { new Rain(), new Sun(), new Wind() };

    public static Queue<IWeather> FiveDayForecast { get; set; } = LoadFiveDaysWeather();
    public static DirectionName WindDirection { get; set; } = DirectionName.right;

    public static Queue<IWeather> LoadFiveDaysWeather()
    {
        Queue<IWeather> forecast = new Queue<IWeather>();

        for (int i = 0; i < numDaysInForecast; i++)
        {
            forecast.Enqueue(GetRandomWeather());
        }

        return forecast;
    }

    public static IWeather GetRandomWeather()
    {
        int numWeatherTypes = weathers.Length;
        int weatherVal = RandomNum.Next(0, numWeatherTypes);
        return weathers[weatherVal];
    }

    public static IWeather AddRandomWeather()
    {
        IWeather temp = GetRandomWeather();
        FiveDayForecast.Enqueue(temp);
        return temp;
    }

    /// <summary>
    /// Returns the weather today, removing it from the queue.
    /// </summary>
    /// <returns></returns>
    public static IWeather GetTodaysWeather()
    {
        // TODO: ADD RANDOM WEATHER
        // TODO: GET the new WEATHER to the end of the Five Day Forecast
        // TODO: UPDATE SPRITES
        //AddRandomWeather();
        return FiveDayForecast.Dequeue();
    }
}

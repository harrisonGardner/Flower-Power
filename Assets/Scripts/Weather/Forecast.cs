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
    private int numDays;
    private static IWeather[] weathers = new IWeather[] { new Rain(), new Sun(), new Wind() };
    private Queue<IWeather> forecast;
    private DirectionName currentWindDirection;

    public GameObject[] visualForecast;
    public GameObject windIcon;

    //public DirectionName WindDirection { get; set; }
    public int extraSunChance = 25;

    private void Start()
    {
        numDays = visualForecast.Length;
        LoadFiveDaysWeather();
    }

    public void LoadFiveDaysWeather()
    {
        // RANDOMLY CHOOSE first DAYS of WEATHER...
        forecast = new Queue<IWeather>();
        for (int i = 0; i < numDays; i++)
        {
            IWeather randomWeather = GetRandomWeather();
            forecast.Enqueue(randomWeather);


            // UPDATE SPRITES for the VISUAL FORECAST
            visualForecast[i].GetComponent<WeatherIcon>().Weather = randomWeather;

            visualForecast[i].GetComponent<WeatherIcon>().spriteUpdate =
                visualForecast[i].GetComponent<WeatherIconSpriteUpdater>();
            SpriteUpdateController.AddSpriteToRedraw(visualForecast[i].GetComponent<WeatherIcon>().spriteUpdate);
        }
    }

    /// <summary>
    /// Generates a random IWeather
    /// </summary>
    /// <returns></returns>
    public  IWeather GetRandomWeather()
    {
        int numWeatherTypes = weathers.Length;
        int weatherVal = MasterController.universallyAvailableRandom.Next(0, numWeatherTypes + extraSunChance);

        // Increase likelihood of sun
        if (weatherVal >= numWeatherTypes)
            weatherVal = 1; // 1 for Sun

        return weathers[weatherVal];
    }

    /// <summary>
    /// Adds a 
    /// </summary>
    /// <returns></returns>
    public  void AdvanceWeather()
    {
        forecast.Dequeue();
        IWeather randomWeather = GetRandomWeather();
        forecast.Enqueue(randomWeather);
        
        for (int i = 0; i < numDays; i++)
        {
            // UPDATE SPRITES for the VISUAL FORECAST 
            if (i < numDays - 1) // ADVANCING EXISTING GAME OBJECTS
            {
                visualForecast[i].GetComponent<WeatherIcon>().Weather =
                    visualForecast[i + 1].GetComponent<WeatherIcon>().Weather;
            }
            else
            {
                visualForecast[i].GetComponent<WeatherIcon>().Weather = randomWeather;
            }

            visualForecast[i].GetComponent<WeatherIcon>().spriteUpdate =
                visualForecast[i].GetComponent<WeatherIconSpriteUpdater>();

            SpriteUpdateController.AddSpriteToRedraw(visualForecast[i].GetComponent<WeatherIcon>().spriteUpdate);
        }
    }

    /// <summary>
    /// Returns the weather today.
    /// </summary>
    /// <returns></returns>
    public  IWeather GetTodaysWeather()
    {
        AdvanceWeather();
        IWeather today = forecast.Peek();
        if (today.Type == WeatherType.WIND)
        {
            Wind windToday = (Wind)today;
            currentWindDirection = windToday.RandomDir.Name;
            UpdateWindIcon();
        }
            
        return today;
    }


    public void UpdateWindIcon()
    {
        windIcon.GetComponent<WindIcon>().Direction = currentWindDirection;
        windIcon.GetComponent<WindIcon>().spriteUpdate = windIcon.GetComponent<WindIconSpriteUpdater>();
        SpriteUpdateController.AddSpriteToRedraw(windIcon.GetComponent<WindIcon>().spriteUpdate);
    }
}

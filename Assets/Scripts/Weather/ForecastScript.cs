using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForecastScript : MonoBehaviour
{
    public GameObject[] days;
    public GameObject windIcon;

    public GameObject garden;

    // Start is called before the first frame update
    void Start()
    {
        //Forecast.LoadFiveDaysWeather();
        UpdateWeatherIcons();
        UpdateWindIcon();
    }

    public void UpdateWeatherIcons()
    {
        for (int i = 0; i < days.Length; i++)
        {
            //days[i].GetComponent<WeatherIcon>().Weather = Forecast.FiveDayForecast.ToArray()[i];

            days[i].GetComponent<WeatherIcon>().spriteUpdate = days[i].GetComponent<WeatherIconSpriteUpdater>();
            SpriteUpdateController.AddSpriteToRedraw(days[i].GetComponent<WeatherIcon>().spriteUpdate);
        }
    }

    public void UpdateWindIcon()
    {
        windIcon.GetComponent<WindIcon>().Direction = garden.GetComponent<Garden>().WindDirection.Name;
        windIcon.GetComponent<WindIcon>().spriteUpdate = windIcon.GetComponent<WindIconSpriteUpdater>();
        SpriteUpdateController.AddSpriteToRedraw(windIcon.GetComponent<WindIcon>().spriteUpdate);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForecastScript : MonoBehaviour
{
    public GameObject[] days;
    //public GameObject windDirectionIcon;
    // Start is called before the first frame update
    void Start()
    {
        Forecast.LoadFiveDaysWeather();
        UpdateWeatherIcons();
        //windDirectionIcon.GetComponent<WindIcon>().Direction = DirectionName.left;
        //windDirectionIcon.GetComponent<WindIcon>().spriteUpdate = windDirectionIcon.GetComponent<WeatherIconSpriteUpdater>();
        //SpriteUpdateController.AddSpriteToRedraw(windDirectionIcon.GetComponent<WindIcon>().spriteUpdate);
    }

    public void UpdateWeatherIcons()
    {
        for (int i = 0; i < days.Length; i++)
        {
            days[i].GetComponent<WeatherIcon>().Weather = Forecast.FiveDayForecast.ToArray()[i];

            days[i].GetComponent<WeatherIcon>().spriteUpdate = days[i].GetComponent<WeatherIconSpriteUpdater>();
            SpriteUpdateController.AddSpriteToRedraw(days[i].GetComponent<WeatherIcon>().spriteUpdate);
        }
    }
}

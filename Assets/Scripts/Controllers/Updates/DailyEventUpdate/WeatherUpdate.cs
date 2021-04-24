using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherUpdate : MonoBehaviour, IGardenUpdate
{
    public Forecast fiveDayWeather = GameObject.Find("Forecast").GetComponent<Forecast>();

    public void ActionOnUpdate(Garden garden)
    {
        IWeather todaysWeather = fiveDayWeather.GetTodaysWeather();
        todaysWeather.SetDaysWeather(garden);
        garden.SunAllPlots(2);
    }
}
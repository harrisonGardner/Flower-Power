using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherUpdate : IGardenUpdate
{
    //public Forecast fiveDayWeather = new Forecast();

    public void ActionOnUpdate(Garden garden)
    {
        IWeather todaysWeather = Forecast.GetTodaysWeather();
        todaysWeather.SetDaysWeather(garden);
    }
}
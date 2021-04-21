using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherIconSpriteUpdater : MonoBehaviour, ISpriteUpdate
{
    public void Start()
    {
        gameObject.GetComponent<WeatherIcon>().spriteUpdate = gameObject.GetComponent<WeatherIconSpriteUpdater>();
    }

    public void SpriteUpdate()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite =
                SpriteFetcher.GetSpriteWeather(gameObject.GetComponent<WeatherIcon>().Weather.Type);
    }
}

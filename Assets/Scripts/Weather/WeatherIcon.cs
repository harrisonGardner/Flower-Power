using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherIcon : MonoBehaviour
{
    public IWeather Weather { get; set; }
    public ISpriteUpdate spriteUpdate;
}

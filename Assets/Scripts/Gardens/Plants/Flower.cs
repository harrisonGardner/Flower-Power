using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Flower : Plant
{
    public Flower(Plot plot, Color flowerColor, IPlantHealth health) : base(PlantType.Flower, health, plot, flowerColor)
    {

    }

    public void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = SpriteFetcher.GetSprite(WeatherType.rain);
    }
}

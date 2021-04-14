using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : Plant
{
    public Flower(Plot plot, Color flowerColor, IPlantHealth health) : base(PlantType.Flower, health, plot, flowerColor)
    {

    }

}

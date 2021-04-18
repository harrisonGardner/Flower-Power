using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerGrow : IGardenUpdate
{
    public void ActionOnUpdate(Garden garden)
    {
        garden.PlantsGrow(PlantType.Flower);
    }
}

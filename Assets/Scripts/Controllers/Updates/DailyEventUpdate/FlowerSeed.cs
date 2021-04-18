using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerSeed : IGardenUpdate
{
    public void ActionOnUpdate(Garden garden)
    {
        garden.SpreadSeeds(PlantType.Flower);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerFeed : IGardenUpdate
{
    public void ActionOnUpdate(Garden garden)
    {
        garden.PlantsFeed(PlantType.Flower);
    }
}


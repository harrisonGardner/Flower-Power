using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeedFeed : IGardenUpdate
{
    public void ActionOnUpdate(Garden garden)
    {
        garden.PlantsFeed(PlantType.Weed);
    }
}
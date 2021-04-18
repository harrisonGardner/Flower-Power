using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerPollinate : IGardenUpdate
{
    public void ActionOnUpdate(Garden garden)
    {
        garden.SpreadPollen(PlantType.Flower);
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Each flower in the garden will give off pollen.
/// </summary>
public class FlowerPollinate : IGardenUpdate
{
    public void ActionOnUpdate(Garden garden)
    {
        garden.SpreadPollen(PlantType.Flower);
    }
}


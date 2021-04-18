using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeedSeed : IGardenUpdate
{
    public void ActionOnUpdate(Garden garden)
    {
        garden.SpreadSeeds(PlantType.Weed);
    }
}

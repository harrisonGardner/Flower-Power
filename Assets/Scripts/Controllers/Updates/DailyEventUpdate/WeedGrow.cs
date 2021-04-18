using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeedGrow : IGardenUpdate
{
    public void ActionOnUpdate(Garden garden)
    {
        garden.PlantsGrow(PlantType.Weed);
    }
}
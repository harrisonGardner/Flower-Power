using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeedPollinate : IGardenUpdate
{
    public void ActionOnUpdate(Garden garden)
    {
        garden.SpreadPollen(PlantType.Weed);
    }
}

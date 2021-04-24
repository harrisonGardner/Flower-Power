using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeedSeed : IGardenUpdate
{
    public void ActionOnUpdate(Garden garden)
    {
        garden.SpreadSeeds(PlantType.Weed);


        // CHANCE of RANDOMLY GENERATING WEED
        int rand = MasterController.universallyAvailableRandom.Next(0, 3);
        if (rand == 0)
        {
            garden.addRandomWeed();
        }
    }
}

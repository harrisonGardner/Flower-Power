using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PestSpread : IGardenUpdate
{
    public void ActionOnUpdate(Garden garden)
    {
        garden.PestSpread();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Start day
/// </summary>
public class StartDay : IGardenUpdate
{
    public void ActionOnUpdate(Garden garden)
    {
        garden.WindyToday = false;
        garden.RemovePollen();
    }
}

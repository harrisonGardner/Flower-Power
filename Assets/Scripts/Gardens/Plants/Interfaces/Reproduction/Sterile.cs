using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  Represents a plant who does not reproduce.
///
///  Accordingly, all of the methods referenced in the interface do nothing.
/// </summary>
public class Sterile : IReproductionBehavior
{
    public void SpreadPollen(Plot plot, Direction direction, bool windyDay) { }

    public void Seed(Plot plot){ }
}

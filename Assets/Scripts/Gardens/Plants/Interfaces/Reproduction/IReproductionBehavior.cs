using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IReproductionBehavior
{
    public void SpreadPollen(Plot plot, Direction direction, bool windyDay);
    public void Seed(Plot plot);
}

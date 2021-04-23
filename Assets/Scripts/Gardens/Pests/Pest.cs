using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Threatens flowers by eating them and spreading
/// to a new plot.
///
/// Generated when two flowers of opposite colors are adjacent to each other.
/// </summary>
public class Pest : MonoBehaviour
{
    public Plot CurrentPlot { get; set; }
    bool dead = false;

    /// <summary>
    /// The pest eats the plant in the current space.
    /// </summary>
    public void Eat()
    {
        if (!CurrentPlot.IsEmpty)
            CurrentPlot.RemoveSinglePlant();
        else // IN CASE PLANT HERE YESTERDAY is now DEAD
            dead = true;
    }

    /// <summary>
    /// The pest moves into a new space.
    /// </summary>
    public void Spread()
    {
        Eat();
        CurrentPlot = CurrentPlot.AdjacentPlots.getRandomNeighborWithPlant();
        if (CurrentPlot == null) // IF NO ADJACENT PLOT HAS A PLANT
            dead = true;
    }

    /// <summary>
    /// If the pest has not eaten a plant recently,
    /// it will die.
    /// </summary>
    public bool IsDead() { return (dead); }

}

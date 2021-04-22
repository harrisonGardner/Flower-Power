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
    Plot CurrentPlot { get; set; }
    int MaxDaysWithoutFood = 1;
    int DaysWithoutFood = 0;

    /// <summary>
    /// The pest eats the plant in the current space.
    /// </summary>
    public void KillPlant()
    {
        CurrentPlot.RemoveSinglePlant(); // TODO: Single plant or batch?
        DaysWithoutFood = 0;
    }

    public void Spread()
    {

    }

    /// <summary>
    /// If the pest has not eaten a plant recently,
    /// it will die.
    /// </summary>
    public void Die()
    {
        //
        // DESTROY GAME OBJECT
    }

    public void RemoveFromGame()
    {

    }

}

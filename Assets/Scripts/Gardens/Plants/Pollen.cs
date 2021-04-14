using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Combines with a plant in a space to potentially generate a new plant.
///
/// Wind pushes the pollen through a series of 
/// </summary>
public class Pollen
{
    // COLOR color
    Direction Move { get; set; }
    int MovesLeft { get; set; }
    int Intensity { get; set; }
    Plot currentPlot { get; set; }

    /// <summary>
    /// Moves the pollen through the plots along a particular direction
    /// so that it can potentially germinate plants along the way.
    ///
    /// n.b. Pollen should be deposited in the pollen's origin space, providing
    /// for the possibility that it could pollinate its origin flower.
    /// </summary>
    public void Spread()
    {
        bool inBounds = true;
        while (MovesLeft >= 0 && inBounds)
        {
            DepositPollen(); // PLACE POLLEN in CURRENT SPACE
            inBounds = EnterNextPlot(); // ENTER NEXT PLOT
            MovesLeft--; // DECREMENT NUMBER OF MOVES  
        }
    }

    private void DepositPollen()
    {
        currentPlot.addPollen(Intensity);
    }

    /// <summary>
    /// Moves the pollen into the next space, as long as that space
    /// is still within the garden.
    /// </summary>
    /// <returns></returns>
    private bool EnterNextPlot()
    {
        try
        {
            Plot next = currentPlot.AdjacentPlots.getNeighbor(Move.Name);
            currentPlot = next;
            return true;
        }
        catch(IndexOutOfRangeException e)
        {
            return false;
        }
        

    }
}

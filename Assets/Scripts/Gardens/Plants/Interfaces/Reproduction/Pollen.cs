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
    private ColorName color;
    private Direction Move { get; set; }
    private int MovesLeft { get; set; }
    private int Intensity { get; set; }
    public Plot currentPlot { get; set; }

    public Pollen(Direction direction, int totalMoves, int intensity)
    {
        Move = direction;
        MovesLeft = totalMoves;
        Intensity = intensity;
    }

    /// <summary>
    /// Moves the pollen through the plots along a particular direction
    /// so that it can potentially germinate plants along the way.
    ///
    /// n.b. Pollen should be deposited in the pollen's origin space, providing
    /// for the possibility that it could pollinate its origin flower.
    /// </summary>
    public void Spread()
    {
        Debug.Log("SPREADING POLLEN");
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
        // ONLY ADD POLLEN if PLANT in the SPACE
        if (currentPlot.plantHere != null)
        { 
            currentPlot.addPollen(Intensity, this.color);
            Debug.Log("POLLEN DEPOSITED");
        }
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
        catch(IndexOutOfRangeException)
        {
            return false;
        }
    }
}

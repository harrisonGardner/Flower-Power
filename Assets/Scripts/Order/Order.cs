using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents the objective of a given level in the game
/// and checks whether the objective has been met.
///
/// Components of the objective include the number of flowers of each type
/// to be harvested (in the flowering stage) and the maximum number of days
/// in which the order can be completed.
/// 
/// </summary>
public class Order //: MonoBehaviour
{
    public TalliedSet<ColorName> flowerRequirements = new TalliedSet<ColorName>();
    public TalliedSet<ColorName> flowersFulfilled = new TalliedSet<ColorName>();
    public int maxNumDays;

    /// <summary>
    /// Has the player harvested all of the flowers required?
    /// </summary>
    /// <returns></returns>
    public bool IsOrderFulfilled()
    {
        foreach (KeyValuePair<ColorName, int> seedCount in flowerRequirements)
        {
            // If flowersFulfilled is less than requirement, then return false;
            if (flowersFulfilled.Count(seedCount.Key) < seedCount.Value)
                return false;
        }

        return true;
    }

    /// <summary>
    /// Allows the player to add a flower to the bouqet
    /// on their mission to fulfill the order.
    /// </summary>
    /// <param name="flower"></param>
    public void AddFlower(Flower flower)
    {
        // ONLY ADD if FLOWER is FLOWERING
        if (flower.CurrentStage.CurrentStage == StageType.FLOWERING)
        {
            flowersFulfilled.Add(flower.PlantColor.Name);
        }
    }

    /// <summary>
    /// Has the player exceeded the time limit?
    /// </summary>
    /// <returns></returns>
    public bool IsTimeUp()
    {
        return (MasterController.DayNumber > maxNumDays);
    }

    /// <summary>
    /// Testing method before File I/O is implemented
    /// </summary>
    public void CreateDummyOrder()
    {
        // PRIMARY COLORS
        flowerRequirements.Add(ColorName.BLUE, 10);
        flowerRequirements.Add(ColorName.RED, 10);
        flowerRequirements.Add(ColorName.YELLOW, 10);

        // SECONDARY COLORS
        flowerRequirements.Add(ColorName.GREEN, 7);
        flowerRequirements.Add(ColorName.ORANGE, 7);
        flowerRequirements.Add(ColorName.PURPLE,7);

        maxNumDays = 30;
    }
}
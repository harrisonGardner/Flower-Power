using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Represents the objective of a given level in the game
/// and checks whether the objective has been met.
///
/// Components of the objective include the number of flowers of each type
/// to be harvested (in the flowering stage) and the maximum number of days
/// in which the order can be completed.
/// 
/// </summary>
/// <author>Nicholas Gliserman</author>
public class Order : MonoBehaviour
{
    public TalliedSet<ColorName> flowerRequirements = new TalliedSet<ColorName>();
    public TalliedSet<ColorName> flowersFulfilled = new TalliedSet<ColorName>();
    public int maxNumDays;
    public string levelName;
    public int bestTime;

    // ORDER ICONS
    public GameObject red;
    public GameObject blue;
    public GameObject yellow;
    public GameObject green;
    public GameObject purple;
    public GameObject orange;

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

    // TODO: IMPLEMENT
    public static bool BeatsBestTime() // IF yes, write back to original file
    {
        return false;
    }

    /// <summary>
    /// Displays how close to completion an order is for the inputted color.
    ///
    /// Used for game UI.
    /// </summary>
    /// <param name="colorName"></param>
    /// <returns></returns>
    public string colorStatus(ColorName colorName)
    {
        return flowersFulfilled.Count(colorName) + "/" + flowerRequirements.Count(colorName);
    }

    /// <summary>
    /// Allows the player to add a flower to the bouqet
    /// on their mission to fulfill the order.
    /// </summary>
    /// <param name="flower"></param>
    public void AddFlower(Plant flower)
    {
        // ONLY ADD if FLOWER is FLOWERING
        if (flower.CurrentStage.CurrentStage == StageType.FLOWERING)
        {
            flowersFulfilled.Add(flower.PlantColor.Name);
        }

        UpdateOrder(flower.PlantColor.Name);
    }

    #region UPDATE ORDERS

    public void UpdateOrder(ColorName cn)
    {
        UnityEngine.UI.Text text;

        if (cn == ColorName.RED)
            text = red.GetComponent<Text>();
        else if (cn == ColorName.BLUE)
            text = blue.GetComponent<Text>();
        else if (cn == ColorName.YELLOW)
            text = yellow.GetComponent<Text>();
        else if (cn == ColorName.GREEN)
            text = green.GetComponent<Text>();
        else if (cn == ColorName.ORANGE)
            text = orange.GetComponent<Text>();
        else // if (cn == ColorName.PURPLE)
            text = purple.GetComponent<Text>();

        text.text = colorStatus(cn);
    }

    public void UpdateAll()
    {
        foreach (ColorName c in Enum.GetValues(typeof(ColorName)))
        {
            if (c != ColorName.NONE)
            {
                UpdateOrder(c);
            }
        }
    }

    #endregion

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
        levelName = "Dummy Level";
        bestTime = 28;
    }
}
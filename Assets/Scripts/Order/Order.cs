using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
/// <author>Nicholas Gliserman & Megan Lisette Peck</author>
public class Order : MonoBehaviour
{
    public TalliedSet<ColorName> flowerRequirements = new TalliedSet<ColorName>();
    public TalliedSet<ColorName> flowersFulfilled = new TalliedSet<ColorName>();
    public int maxNumDays { get; set; }
    public string levelName;
    public int bestTime;
    public SeedPouch seeds;
    private static string orderItemsFile;
    private static string levelSettingsFile;
    public static IList<ItemDetails> orderItems { get; private set; } = new List<ItemDetails>();
    public static GameSettings levelSettings { get; private set; } = new GameSettings();

    // ORDER ICONS
    public GameObject red;
    public GameObject blue;
    public GameObject yellow;
    public GameObject green;
    public GameObject purple;
    public GameObject orange;

    private void Start()
    {
        levelName = "Easy";     //TODO - Dynamically pass a value for the level
        seeds = GameObject.Find("SeedPouch").GetComponent<SeedPouch>();
        
        //CreateDummyOrder();
        CreateOrder(levelName);

        GameObject.Find("Record").GetComponent<Text>().text = 
            $"Record: {(bestTime >= 0 ? bestTime : maxNumDays)}"; 
    }

    /// <summary>
    /// Has the player harvested all of the flowers required?
    /// </summary>
    /// <returns></returns>
    public bool OrderFulfilled()
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
    /// Has the current (completed) game beaten the previous record.
    /// </summary>
    /// <returns></returns>
    public void BeatsBestTime() // IF yes, write back to original file
    {
        if (OrderFulfilled() && (MasterController.DayNumber < bestTime || levelSettings.BestTime == -1))
            PrintBestScore.WriteBestScore(levelName, MasterController.DayNumber);
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

        // UPDATE VISUALS
        UpdateOrder(flower.PlantColor.Name);

        // CHECK for VICTORY
        if (OrderFulfilled())
        {
            GameObject.Find("Victory").GetComponent<Text>().text = "VICTORY is YOURS!!!";
        }
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
        flowerRequirements.Add(ColorName.BLUE, 13);
        flowerRequirements.Add(ColorName.RED, 13);
        flowerRequirements.Add(ColorName.YELLOW, 13);

        // SECONDARY COLORS
        flowerRequirements.Add(ColorName.GREEN, 9);
        flowerRequirements.Add(ColorName.ORANGE, 9);
        flowerRequirements.Add(ColorName.PURPLE, 9);

        seeds.Add(ColorName.BLUE, 30);
        seeds.Add(ColorName.RED, 30);
        seeds.Add(ColorName.YELLOW, 30);
        seeds.UpdateSeedAmount();

        maxNumDays = 100;
        levelName = "Dummy Level";
        bestTime = 57;

        UpdateAll();
    }

    public void CreateOrder(string level)
    {
        //GetLevelDetails.ReadFiles(level); - Would have to return several items

        orderItemsFile = FindFileLocations.findOrderItemsFile(level);
        levelSettingsFile = FindFileLocations.findLevelSettingsFile(level);

        orderItems = ReadLevelOrderandSettings.LoadOrderItems(orderItemsFile);
        levelSettings = ReadLevelOrderandSettings.LoadSettings(levelSettingsFile);

        foreach (ItemDetails order in orderItems)
        {
            switch (order.itemType)
            {
                case ItemType.FLOWER:
                    if(order.quantity > 0)
                    {
                        flowerRequirements.Add(order.color, order.quantity);
                    }
                    break;
                case ItemType.SEED:
                    seeds.Add(order.color, order.quantity);
                    break;
                default:
                    Debug.Log("Unknown ItemType");
                    break;
            }
        }

        maxNumDays = levelSettings.MaxNumDays;
        levelName = levelSettings.LevelName;
        bestTime = levelSettings.BestTime;

        UpdateAll();
    }
}
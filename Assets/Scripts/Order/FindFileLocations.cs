using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used to find the file paths of orders and game settings for each level.
/// </summary>
/// <author>Megan Lisette Peck</author>
public class FindFileLocations //: MonoBehaviour
{
    /// <summary>
    /// Takes in a string of the level, and finds the file with the orders
    /// for that level of the game.
    /// </summary>
    /// <param name="level">level the user wants to play</param>
    /// <returns>File of orders for the specific level</returns>
    public static string findOrderItemsFile(string level)
    {
        switch (level)
        {
            case "Hard":
                return "Assets/Resources/TextFiles/OrdersForLevelHard.json";
            case "Medium":
                return "Assets/Resources/TextFiles/OrdersForLevelMedium.json";
            default:
                return "Assets/Resources/TextFiles/OrdersForLevelEasy.json";
        }
    }

    /// <summary>
    /// Takes in a string of the level, and finds the file with the settings
    /// for that level of the game.
    /// </summary>
    /// <param name="level">level the user wants to play</param>
    /// <returns>File of settings for the specific level</returns>
    public static string findLevelSettingsFile(string level)
    {
        switch (level)
        {
            case "Hard":
                return "Assets/Resources/TextFiles/levelSettingsHard.json";
            case "Medium":
                return "Assets/Resources/TextFiles/levelSettingsMedium.json";
            default:
                return "Assets/Resources/TextFiles/levelSettingsEasy.json";
        }
    }
}

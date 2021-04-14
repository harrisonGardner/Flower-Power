using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains the number of seeds, in each color that the player has.
/// </summary>
/// <author>Lisette Peck, Nicholas Gliserman</author>
public class SeedPouch : MonoBehaviour
{
    private IDictionary<ColorName, int> Seeds { get; } = new Dictionary<ColorName, int>();
    // TODO: Add currentDisplay color for graphics & a method to get the next color so the user can tap the icon to see other seed colors

    /// <summary>
    /// Adds a seed of the given color to the players pouch.
    /// 
    /// If the color already exist in the players pouch, the 
    /// number of seeds increases. Otherwise a new color/int pair
    /// added to the pouch.
    /// </summary>
    /// <param name="seed"></param>
    public void Add(Plant seed)
    {
        if (seed.CurrentStage.CurrentStage == StageType.SEED)
        {
            Color seedColor = seed.PlantColor;

            if (Seeds.ContainsKey(seedColor.Name))
                Seeds[seedColor.Name]++;
            else
                Seeds.Add(seedColor.Name, 1);
        }
    }

    /// <summary>
    /// Checks if the player has a seed of the given color.
    /// 
    /// If the player has it, it will be removed and the value
    /// of "true" is returned. Otherwise returns "false."
    /// </summary>
    /// <param name="color">Color of the seed to look for.</param>
    /// <returns>True if the player has a seed of that color.</returns>
    public bool Remove(ColorName color)
    {
        if (Seeds.ContainsKey(color))
        {
            // CASE WHERE THERE IS A SEED TO REMOVE
            if (Seeds[color] > 0)
            {
                Seeds[color] = Seeds[color]--;
                return true;
            }
            if (Seeds[color] <= 0)
            {
                Seeds.Remove(color);
            }
        }
        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains the number of seeds, in each color that the player has.
/// </summary>
public class SeedPouch : MonoBehaviour
{
    private IDictionary<ColorName, int> seeds = new Dictionary<ColorName, int>();

    /// <summary>
    /// Adds a seed of the given color to the players pouch.
    /// If the color already exist in the players pouch, the 
    /// number of seeds increases. Otherwise a new color/int pair
    /// added to the pouch.
    /// </summary>
    /// <param name="color">Color of the seed to add.</param>
    /// <param name="numToAdd">Number of seeds to add. If no color is given, the deafult is 1.</param>
    public void add(ColorName color, int numToAdd = 1)
    {
        if (seeds.ContainsKey(color))
            seeds[color] = seeds[color] + numToAdd;
        else
            seeds.Add(color, numToAdd);
            Console.WriteLine("Salt Lake City was not found in the dictionary cities.");
    }

    /// <summary>
    /// Checks if the player has a seed of the given color.
    /// If the player has it, it will be removed and the value
    /// of "true" is returned. Otherwise returns "false."
    /// </summary>
    /// <param name="color">Color of the seed to look for.</param>
    /// <returns>True if the player has a seed of that color.</returns>
    public bool remove(ColorName color)
    {
        bool seedExist = false;
        if ((seeds.ContainsKey(color))
        {
            if (seeds[color] > 0)
            {
                seeds[color] = seeds[color]--;
                seedExist = true;
            }
        }
        if ((seeds.ContainsKey(color) && seeds[color] < 0)
            seeds.Remove(color);
        return seedExist;
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

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
    // TODO: Add currentDisplay color for graphics & a method to get the next color so the user can tap the icon to see other seed colors
    public TalliedSet<ColorName> Seeds { get; } = new TalliedSet<ColorName>();
    

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


            //if (Seeds.ContainsKey(seedColor.Name))
            //    Seeds[seedColor.Name]++;
            //else
            //    Seeds.Add(seedColor.Name, 1);
        }
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

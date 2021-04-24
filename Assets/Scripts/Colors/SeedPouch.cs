using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Contains the number of seeds, in each color that the player has.
/// </summary>
/// <author>Lisette Peck, Nicholas Gliserman</author>
public class SeedPouch : MonoBehaviour
{
    public TalliedSet<ColorName> Seeds { get; } = new TalliedSet<ColorName>();
    
    // Graphic Related
    private static ColorName[] bagColors = new ColorName[3] { ColorName.BLUE, ColorName.YELLOW, ColorName.RED };
    private static int bagColorArrayHead = 0;
    public static bool holding = false;
    public GameObject seedObject;
    private Vector3 defaultPosition;

    public Text seedAmountText;

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

    public void Add(ColorName color, int amount)
    {
        Seeds.Add(color, amount);
    }

    public ColorName RemoveSeed()
    {
        try
        {
            ColorName seed = Seeds.Remove(bagColors[bagColorArrayHead]);
            UpdateSeedAmount();
            return seed;
        }
        catch (KeyNotFoundException)
        {
            throw new KeyNotFoundException("No more seeds of this color in the pouch");
        }
    }


    // Start is called before the first frame update
    void Start()
    {


        defaultPosition = seedObject.transform.position;
        
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButton(1))
            DropTool();

        if (holding)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            seedObject.transform.position = new Vector3(mousePosition.x, mousePosition.y, -1);
        }
        else
            seedObject.transform.position = Vector3.MoveTowards(seedObject.transform.position, defaultPosition, 0.2f);
    }

    private void OnMouseOver()
    {
        if(Input.GetMouseButtonUp(1))
        {
            // Cycle through the colors in the bag
            bagColorArrayHead++;
            if (bagColorArrayHead > bagColors.Length-1)
                bagColorArrayHead = 0;

            // Update the sprite
            gameObject.GetComponent<SpriteRenderer>().sprite = SpriteFetcher.GetSpriteSeedOrPouch(SpriteFetcher.SeedOrPouch.SEEDPOUCH, bagColors[bagColorArrayHead]);
            seedObject.GetComponent<SpriteRenderer>().sprite = SpriteFetcher.GetSpriteSeedOrPouch(SpriteFetcher.SeedOrPouch.SEED, bagColors[bagColorArrayHead]);

            UpdateSeedAmount();
        }
    }

    public void UpdateSeedAmount()
    {
        // Update the count
        seedAmountText.text = Seeds.Count(bagColors[bagColorArrayHead]).ToString();
    }

    public static void DropTool()
    {
        holding = false;
    }

    private void OnMouseDown()
    {
        seedAmountText.text = Seeds.Count(bagColors[bagColorArrayHead]).ToString();

        if (!holding)
        {
            WateringCan.DropTool();
            Clippers.DropTool();
            holding = true;
        }
        else
        {
            DropTool();
        }
    }
}

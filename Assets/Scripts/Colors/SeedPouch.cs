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
    public TalliedSet<ColorName> Seeds { get; } = new TalliedSet<ColorName>();
    
    // Graphic Related
    private static ColorName[] bagColors = new ColorName[3] { ColorName.BLUE, ColorName.YELLOW, ColorName.RED };
    private static int bagColorArrayHead = 0;
    public static bool holding = false;

    public GameObject seedObject;
    private Vector3 defaultPosition;

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

    public static ColorName GetSeedColor()
    {
        return bagColors[bagColorArrayHead];
    }


    // Start is called before the first frame update
    void Start()
    {
        defaultPosition = seedObject.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (holding)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            seedObject.transform.position = new Vector3(mousePosition.x, mousePosition.y, -1);
        }
        else
            seedObject.transform.position = defaultPosition;

    }

    private void OnMouseOver()
    {
        if(Input.GetMouseButtonUp(1))
        {
            bagColorArrayHead++;
            if (bagColorArrayHead > bagColors.Length-1)
                bagColorArrayHead = 0;

            gameObject.GetComponent<SpriteRenderer>().sprite = SpriteFetcher.GetSprite(SpriteFetcher.SeedOrPouch.SEEDPOUCH, bagColors[bagColorArrayHead]);
            seedObject.GetComponent<SpriteRenderer>().sprite = SpriteFetcher.GetSprite(SpriteFetcher.SeedOrPouch.SEED, bagColors[bagColorArrayHead]);
        }
    }

    private void OnMouseDown()
    {
        if (holding)
            holding = false;
        else
            holding = true;
    }
}

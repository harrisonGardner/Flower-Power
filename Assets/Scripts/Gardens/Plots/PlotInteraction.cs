using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteractionType { NONE, WATER, CUT, PLANT}

/// <summary>
/// Checks for plot clicks and responds with appropriate action.
/// </summary>
/// <author> Harrison Gardner </author>>
public class PlotInteraction : MonoBehaviour
{
    public Plot Plot { get; set; }
    public enum PlantAction { NONE, CUT, WILT } // TODO: REVISIT
    public PlantAction plotPlantAction = PlantAction.NONE;
    public InteractionType currentAction;

    public bool hasBeenClicked = false;

    // Update is called once per frame
    // n.b. IDEALLY we don't want to run all plots through the update function
    // PREFERRED -- on a click event via the OnMouseDown function, determine which action to perform and do it then
    void Update()
    {
        //PlotClickedOnCheck();
    }

    private void OnMouseDown()
    {
        //hasBeenClicked = true;

        //if (hasBeenClicked)
        //{
            //Watering Can Click
            if (WateringCan.holding)
            {
                Plot.addWater(3);
                WateringCan.useTool = true;
            }
            //Clippers Click
            if (Clippers.holding)
            {
                if (!Plot.IsEmpty)
                    Plot.plantHere.KillPlant();
                Clippers.useTool = true;
            }
            if (SeedPouch.holding == true)
            {
                if (Plot.IsEmpty)
                {
                    Plot.addPlant(PlantType.Flower, SeedPouch.GetSeedColor());
                    SeedPouch.holding = false;
                }
            }

            this.hasBeenClicked = false; // RESET
        //}

        Plot.SpriteUpdate();
    }

    //Mouse click on plot check
    private void PlotClickedOnCheck()
    {
        if (hasBeenClicked)
        {
            //Watering Can Click
            if (WateringCan.holding)
            {
                Plot.addWater(3);
                WateringCan.useTool = true;
            }
            //Clippers Click
            if (Clippers.holding)
            {
                if (!Plot.IsEmpty)
                    Plot.plantHere.KillPlant();
                Clippers.useTool = true;
            }
            //Seed holding click
            if (SeedPouch.holding == true)
            {
                if (Plot.IsEmpty)
                {
                    Plot.addPlant(PlantType.Flower, SeedPouch.GetSeedColor());
                    SeedPouch.holding = false;
                }
            }

            this.hasBeenClicked = false; // RESET
        }

        Plot.SpriteUpdate();
    }
}

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
    public enum PlantAction { NONE, CUT, WILT }
    public PlantAction plotPlantAction = PlantAction.NONE;
    public InteractionType currentAction;

    public bool hasBeenClicked = false;

    private void OnMouseDown()
    {
        //Watering Can Click
        if (WateringCan.holding)
        {
            Plot.addWater(4);
            WateringCan.useTool = true;
            SpriteUpdateController.AddSpriteToRedraw(GetComponent<Plot>().spriteUpdate);
        }
        //Clippers Click
        else if (Clippers.holding)
        {
            if (!Plot.IsEmpty)
            {
                Plant removed = Plot.RemoveSinglePlant();
                Order currentOrder = GameObject.Find("OrderInfo").GetComponent<Order>();
                currentOrder.AddFlower(removed);
            }
                
            Clippers.useTool = true;
        }
        else if (SeedPouch.holding == true)
        {
            if (Plot.IsEmpty)
            {
                SeedPouch pouch = GameObject.Find("SeedPouch").GetComponent<SeedPouch>();

                try
                {
                    Plot.AddPlant(PlantType.Flower, pouch.RemoveSeed());
                }
                catch (KeyNotFoundException) { }
               
            }
        }
    }
}

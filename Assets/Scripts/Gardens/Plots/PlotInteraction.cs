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

    private void OnMouseDown()
    {
        //Watering Can Click
        if (WateringCan.holding)
        {
            Plot.addWater(3);
            WateringCan.useTool = true;
            SpriteUpdateController.AddSpriteToRedraw(GetComponent<Plot>().spriteUpdate);
        }
        //Clippers Click
        if (Clippers.holding)
        {
            if (!Plot.IsEmpty)
            {
                Debug.Log("In Plot with " + Plot.plantHere.PlantType.ToString() + " of color " + Plot.plantHere.PlantColor.Name);
                Debug.Log("Cutting Down Now...");
                Plant removed = Plot.RemoveSinglePlant();
                Order currentOrder = GameObject.Find("OrderInfo").GetComponent<Order>();
                Debug.Log("Trying to Add " + removed.PlantType + " of color " + removed.PlantColor.Name);
                currentOrder.AddFlower(removed);
            }
                
            Clippers.useTool = true;
            //UITextUpdater.UpdateOrderNumbers();
        }
        if (SeedPouch.holding == true)
        {
            if (Plot.IsEmpty)
            {
                Plot.AddPlant(PlantType.Flower, SeedPouch.GetSeedColor());
            }
        }
    }
}

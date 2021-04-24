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

    public bool watering = false;


    private void FixedUpdate()
    {
        //if we are watering the plot continually add 1 until we stop
        if (watering)
        {
            Plot.addWater(1);
            SpriteUpdateController.AddSpriteToRedraw(GetComponent<Plot>().spriteUpdate);
        }
    }

    private void OnMouseDown()
    {
        //Clippers Click
        if (Clippers.holding)
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

    private void OnMouseOver()
    {
        //Check if useTool is true while over the plot
        //If it is set watering to true so we can add water each step
        if (WateringCan.useTool)
            watering = true;
    }

    private void OnMouseExit()
    {
        //Once the mouse leaves the plots collider set watering to false so we stop
        watering = false;
    }
}

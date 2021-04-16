using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Building block of the garden that houses up to a single plant
/// and mediates the plant's interactions with the external world.
/// </summary>
/// <author>Nicholas Gliserman</author>
public class Plot : MonoBehaviour
{
    // GRAPHICS
    public GameObject plotObject;

    // Spatial Logic
    public Neighbors AdjacentPlots { get; set; }
    private Garden garden;

    // Metrics
    int waterLevel = 0;
    private const int WATER_CAPCITY = 12;
    public int SunEnergyToday { get; set; } = 0;

    // Plant Related Fields
    Plant plantHere;
    public IList<Pollen> PollenToday { get; } // TODO: REVISIT DATA STRUCTURE

    // Pest Related Fields
    // TODO: the pest in this space
    public bool clashingFlowerColorHere = false;

    // Start is called before the first frame update
    void Start()
    {
     
        //plantHere = new Flower(this, Colors.getColor(ColorName.BLUE), new WeedHealth());
       
    }

    public void UpdatePlot()
    {
        PlotClickedOnCheck();
    }

    //Mouse click on plot check
    private void PlotClickedOnCheck()
    {
        if (this.plotObject.GetComponent<PlotInteraction>().hasBeenClicked)
        {
            waterLevel++;
            this.plotObject.GetComponent<PlotInteraction>().hasBeenClicked = false;
        }

        SpriteUpdate();
    }

    //Sprite Update Check
    public void SpriteUpdate()
    {
        if (waterLevel <= 0)
            this.plotObject.gameObject.GetComponent<SpriteRenderer>().sprite = SpriteFetcher.GetSprite(0);
        else if (waterLevel <= 4)
            this.plotObject.gameObject.GetComponent<SpriteRenderer>().sprite = SpriteFetcher.GetSprite(1);
        else if (waterLevel <= 8)
            this.plotObject.gameObject.GetComponent<SpriteRenderer>().sprite = SpriteFetcher.GetSprite(2);
        else if (waterLevel <= 12)
            this.plotObject.gameObject.GetComponent<SpriteRenderer>().sprite = SpriteFetcher.GetSprite(3);
    }

    /// <summary>
    /// Constructor method to create a new Plot object.
    /// </summary>
    /// <param name="garden">The Garden to which this plot belongs</param>
    public Plot(Garden garden, GameObject prefab)
    {
        this.garden = garden;
        this.plotObject = prefab;
    }


    public void setPositionAndScale(int x, int y, int width, int height)
    {
        this.plotObject.transform.position.Set(x, y, 1);
        this.plotObject.transform.localScale.Set(width, height, 1);
    }

    /// <summary>
    /// If there is not already a plant in this plot, places
    /// the inputted plant into this plot.
    /// </summary>
    /// <param name="plant"></param>
    public void addPlant(Plant plant)
    {
        // Add the plant to the appropriate list (weed or flower) in the garden
        if (this.plantHere == null)
        {
            this.plantHere = plant;
            garden.addPlant(plant);
        }
    }

    /// <summary>
    /// When a plant has died, empties the plot to allow for a new plant.
    /// </summary>
    public void removePlant()
    {
        // TODO: Add logic to ensure there is plant here and it is in fact dead
        // TODO: remove it from the garden

        this.plantHere = null;

    }
    

    /// <summary>
    /// Increases the amount of water in the space up to the plot's capacity.
    /// </summary>
    /// <param name="watering"></param>
    public void addWater(int watering)
    {
        // Add input water to overall amount of water
        this.waterLevel += watering;

        // If the new waterlevel exceeds capacity, set it to capacity
        if (this.waterLevel > WATER_CAPCITY)
            this.waterLevel = WATER_CAPCITY;
    }

    /// <summary>
    /// Allows for water to leave the plot, for example
    /// if the plant in this space wants to drink it.
    ///
    /// More water cannot leave than is currently stored.
    /// </summary>
    /// <param name="requestedWater"></param>
    /// <returns></returns>
    public int removeWater(int requestedWater)
    {
        if (this.waterLevel >= requestedWater)
        {
            this.waterLevel -= requestedWater;
            return requestedWater;
        }
        else
        {
            int temp = this.waterLevel;
            this.waterLevel = 0;
            return temp;
        }
    }

    /// <summary>
    /// Allows for sun energy to leave the plot, for
    /// example to be consumed by the plant.
    ///
    /// More sun energy cannot leave than is currently stored.
    /// </summary>
    /// <param name="requestedSunEnergy"></param>
    /// <returns></returns>
    public int removeSunEnergy(int requestedSunEnergy)
    {
        if (this.SunEnergyToday >= requestedSunEnergy)
        {
            this.SunEnergyToday -= requestedSunEnergy;
            return requestedSunEnergy;
        }
        else
        {
            int temp = this.SunEnergyToday;
            this.SunEnergyToday = 0;
            return temp;
        }
    }

    // TODO: COMPLETE THIS METHOD
    public void addPollen(int amount) // TODO: Add Color
    {
        // IF THERE IS NO PLANT in the SPACE, DO NOTHING
        // IF THERE IS A PLANT, ADD POLEN
    }

    // TODO: COMPLETE THIS METHOD
    public void emptyPollen()
    {
        // ONCE DATA STRUCTURE FOR POLLEN IS SETTLED
        // SET the OLD DATA Loose For Garbage Collection
    }

    public void addPest()
    {
        // TODO: Once Pest Class is Implemented
    }
}

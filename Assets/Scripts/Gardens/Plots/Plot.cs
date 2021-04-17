using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

/// <summary>
/// Building block of the garden that houses up to a single plant
/// and mediates the plant's interactions with the external world.
/// </summary>
/// <author>Nicholas Gliserman, Harrison Gardner</author>
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
    public Plant plantHere;
    public TalliedSet<ColorName> PollenHere { get; private set; } = new TalliedSet<ColorName>();
    public enum PlantAction { NONE, CUT, WILT }
    public PlantAction plotPlantAction = PlantAction.NONE;

    // Pest Related Fields
    // TODO: the pest in this space
    public bool clashingFlowerColorHere = false;

    // Start is called before the first frame update
    void Start()
    {
        
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
            //Watering Can Click
            if (WateringCan.holding)
            {
                waterLevel = WATER_CAPCITY;
                WateringCan.useTool = true;
            }
            //Clippers Click
            if (Clippers.holding)
            {
                if(plantHere)
                    this.plantHere.KillPlant();
                Clippers.useTool = true;
            }
            if (SeedPouch.holding == true)
            {
                if (this.plantHere == null)
                {
                    Plant plantObject = new Flower(this, Colors.GetColor(SeedPouch.GetSeedColor()), new FlowerHealth(0, 0, 90, 10));
                    addPlant(plantObject);
                    SeedPouch.holding = false;
                }
            }
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

    /// <summary>
    /// Logic for putting a plot (as game object) into the game.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
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
        // REMOVE the PLANT FROM THE GARDEN
        if (this.plantHere.PlantType == PlantType.Weed)
        {
            garden.Weeds.Remove(this.plantHere);
        }
        else if (this.plantHere.PlantType == PlantType.Flower)
        {
            garden.Flowers.Remove(this.plantHere);
        }

        // REMOVE from this PLOT
        this.plantHere = null;
    }

    public int GetWaterLevel()
    {
        return waterLevel;
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

    /// <summary>
    /// Deposits pollen in this space.
    /// </summary>
    /// <param name="amount"></param>
    /// <param name="color"></param>
    public void addPollen(int amount, ColorName color)
    {
        // ONLY DEPOSIT POLLEN if THERE IS A PLANT HERE
        if (this.plantHere != null)
        {
            for (int i = 0; i < amount; i++)
            {
                PollenHere.Add(color);
            }
        }
    }

    /// <summary>
    /// Resets the pollen in this plot
    /// </summary>
    public void emptyPollen()
    {
        // IF PLANT is HERE, NEED TO EMPTY PLOT of POLLEN
        if (this.plantHere != null)
        {
            // SET the OLD DATA LOOSE for GARBAGE COLLECTIOn
            PollenHere = new TalliedSet<ColorName>();
        }
    }

    // TODO: Once Pest Class is Implemented
    public void addPest()
    {
        
    }
}

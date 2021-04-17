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
    public GameObject PlotObject { get; set; }

    // Spatial Logic
    public Neighbors AdjacentPlots { get; set; }
    public Garden Garden { get; set; }

    // Metrics
    int waterLevel = 0;
    private const int WATER_CAPCITY = 12;
    public int SunEnergyToday { get; set; } = 0;

    // Plant Related Fields
    public Plant plantHere;
    public GameObject plantPrefab;
    public bool IsEmpty = true;
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
        if (this.PlotObject.GetComponent<PlotInteraction>().hasBeenClicked)
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
                if(!IsEmpty)
                    this.plantHere.KillPlant();
                Clippers.useTool = true;
            }
            if (SeedPouch.holding == true)
            {
                if (IsEmpty)
                {
                    addPlant(PlantType.Flower, SeedPouch.GetSeedColor());
                    SeedPouch.holding = false;
                }
            }
            this.PlotObject.GetComponent<PlotInteraction>().hasBeenClicked = false;
        }
        SpriteUpdate();
    }

    //Sprite Update Check
    public void SpriteUpdate()
    {
        if (waterLevel <= 0)
            this.PlotObject.gameObject.GetComponent<SpriteRenderer>().sprite = SpriteFetcher.GetSprite(0);
        else if (waterLevel <= 4)
            this.PlotObject.gameObject.GetComponent<SpriteRenderer>().sprite = SpriteFetcher.GetSprite(1);
        else if (waterLevel <= 8)
            this.PlotObject.gameObject.GetComponent<SpriteRenderer>().sprite = SpriteFetcher.GetSprite(2);
        else if (waterLevel <= 12)
            this.PlotObject.gameObject.GetComponent<SpriteRenderer>().sprite = SpriteFetcher.GetSprite(3);
    }

    /// <summary>
    /// Constructor method to create a new Plot object.
    /// </summary>
    /// <param name="garden">The Garden to which this plot belongs</param>
    //public Plot(Garden garden, GameObject prefab)
    //{
    //    this.Garden = garden;
    //    this.PlotObject = prefab;
    //}

    /// <summary>
    /// Logic for putting a plot (as game object) into the game.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    public void setPositionAndScale(int x, int y, int width, int height)
    {
        this.PlotObject.transform.position.Set(x, y, 1);
        this.PlotObject.transform.localScale.Set(width, height, 1);
    }

    /// <summary>
    /// If there is not already a plant in this plot, places
    /// the inputted plant into this plot.
    /// </summary>
    /// <param name="plant"></param>
    public void addPlant(PlantType pt, ColorName cn)
    {
        // Add the plant to the appropriate list (weed or flower) in the garden
        if (this.IsEmpty)
        {
            plantPrefab = Instantiate(Resources.Load("Prefabs/FlowerPrefab") as GameObject, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1), new Quaternion());
            Flower flowerObject = plantPrefab.GetComponent<Flower>();
            flowerObject.StartPlant(pt, new FlowerHealth(0, 0, 90, 10), this, Colors.GetColor(cn));
            plantPrefab.GetComponent<SpriteRenderer>().sprite = SpriteFetcher.GetSprite(SeedPouch.GetSeedColor(), plantPrefab.GetComponent<Flower>().CurrentStage.CurrentStage);

            this.IsEmpty = false;
            this.plantHere = flowerObject;
            Garden.addPlant(flowerObject);
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
            Garden.Weeds.Remove(this.plantHere);
        }
        else if (this.plantHere.PlantType == PlantType.Flower)
        {
            Garden.Flowers.Remove(this.plantHere);
        }

        // REMOVE from this PLOT
        IsEmpty = true;
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

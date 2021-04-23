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
    public PlotInteraction PlotInteraction { get; set; }
    public ISpriteUpdate spriteUpdate;

    // Spatial Logic
    public Neighbors AdjacentPlots { get; set; }
    public Garden Garden { get; set; }

    // Metrics
    public int waterLevel = 0;
    private const int WATER_CAPCITY = 12;
    public int SunEnergyToday { get; set; } = 0;

    // Plant Related Fields
    public Plant plantHere;
    public GameObject plantPrefab;
    public bool IsEmpty = true;
    public TalliedSet<ColorName> PollenHere { get; set; } = new TalliedSet<ColorName>();

    // FIELDS for TESTING
    public bool PollenIsHere = false;

    // Pest Related Fields
    // TODO: the pest in this space
    public bool clashingFlowerColorHere = false;

    // PLOT SETTINGS
    public void InitializePlotSettings(Garden garden, GameObject plotObject)
    {
        this.Garden = garden;
        this.PlotObject = plotObject;
        this.PlotInteraction = PlotObject.GetComponent<PlotInteraction>();
        this.PlotInteraction.Plot = this;
        this.spriteUpdate = gameObject.GetComponent<PlotSpriteUpdater>();
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
        this.PlotObject.transform.position.Set(x, y, 1);
        this.PlotObject.transform.localScale.Set(width, height, 1);
    }

    // PLANT-RELATED METHODS

    /// <summary>
    /// If there is not already a plant in this plot, places
    /// the inputted plant into this plot.
    /// </summary>
    /// <param name="pt">PlantType</param>
    /// <param name="cn">ColorName</param>
    public void AddPlant(PlantType pt, ColorName cn)
    {
        // Add the plant to the appropriate list (weed or flower) in the garden
        if (this.IsEmpty)
        {
            // TODO: ADD LOGIC to INSTANTIATE WEED as WELL based on PLANTTYPE
            plantPrefab = Instantiate(Resources.Load("Prefabs/PlantPrefab") as GameObject,
                new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1), new Quaternion());

            // GET UNDERLYING PLANT from GAME OBJECT
            Plant plant = plantPrefab.GetComponent<Plant>();
            plant.spriteUpdate = plantPrefab.GetComponent<PlantSpriteUpdater>();

            //INITIALIZE FLOWER SETTINGS
            if (pt == PlantType.Flower)
            {
                //Debug.Log($"Should be a flower {pt}");
                plant.StartPlant(pt, new FlowerHealth(0, 0, 90, 10), this, Colors.GetColor(cn), plantPrefab);
                plantPrefab.GetComponent<SpriteRenderer>().sprite =
                    SpriteFetcher.GetSpriteFlower(SeedPouch.GetSeedColor(),
                    plantPrefab.GetComponent<Plant>().CurrentStage.CurrentStage);
            }
            else if (pt == PlantType.Weed)
            {
                plant.StartPlant(pt, new WeedHealth(), this, Colors.GetColor(ColorName.NONE), plantPrefab);
                plantPrefab.GetComponent<SpriteRenderer>().sprite =
                    SpriteFetcher.GetSpriteWeed(plantPrefab.GetComponent<Plant>().CurrentStage.CurrentStage);
            }

            this.IsEmpty = false;
            this.plantHere = plant;
            Garden.AddPlant(plant);
        }
    }

    /// <summary>
    /// When a plant has died, empties the plot to allow for a new plant.
    /// </summary>
    public void RemoveSinglePlant()
    {
        // BEFORE REMOVING from PLOT, REMOVE from GARDEN
        Garden.AddToRemove(this.plantHere);
        Garden.RemoveFromGarden();
    }

    public void RemovePlantDuringGrowth()
    {
        Garden.AddToRemove(this.plantHere);
    }

    // CALLED after REMOVED from GARDEN
    public void DestroyPlant() {
        // REMOVE from this PLOT
        IsEmpty = true;
        this.plantHere = null;
        Destroy(plantPrefab); }

    // WATER-RELATED METHODS

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

    // SUN-RELATED METHODS

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

    // POLLEN-RELATED METHODS

    /// <summary>
    /// Deposits pollen in this space.
    /// </summary>
    /// <param name="amount"></param>
    /// <param name="color"></param>
    public void addPollen(int amount, ColorName color)
    {
        // ONLY DEPOSIT POLLEN if THERE IS A PLANT HERE
        //if (!this.IsEmpty)
        //{
            for (int i = 0; i < amount; i++)
            {
                PollenHere.Add(color);
            }
        //}
        PollenIsHere = true;
    }

    /// <summary>
    /// Resets the pollen in this plot
    /// </summary>
    public void emptyPollen()
    {
        // IF PLANT is HERE, NEED TO EMPTY PLOT of POLLEN
        if (!this.IsEmpty)
        {
            // SET the OLD DATA LOOSE for GARBAGE COLLECTION
            PollenHere = new TalliedSet<ColorName>();
        }
        PollenIsHere = false;
    }

    // TODO: Once Pest Class is Implemented
    public void addPest()
    {
        
    }
}

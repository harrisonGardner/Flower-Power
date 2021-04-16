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
    public GameObject plotPrefab;

    // Spatial Logic
    public Neighbors AdjacentPlots { get; set; }
    private Garden garden;

    // Metrics
    int waterLevel = 0;
    private const int WATER_CAPCITY = 10;
    public int SunEnergyToday { get; set; } = 0;

    // Plant Related Fields
    public Plant plantHere;
    public TalliedSet<ColorName> PollenHere { get; }

    // Pest Related Fields
    // TODO: the pest in this space
    public bool clashingFlowerColorHere = false;

    // Start is called before the first frame update
    void Start()
    {
     
        
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Constructor method to create a new Plot object.
    /// </summary>
    /// <param name="garden">The Garden to which this plot belongs</param>
    public Plot(Garden garden, GameObject prefab)
    {
        this.garden = garden;
        this.plotPrefab = prefab;
    }


    public void setPositionAndScale(int x, int y, int width, int height)
    {
        this.plotPrefab.transform.position.Set(x, y, 1);
        this.plotPrefab.transform.localScale.Set(width, height, 1);
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
    public void addPollen(int amount, ColorName color)
    {
        // ONLY DEPOSITE POLLEN if THERE IS A PLANT HERE
        if (plantHere != null)
        {
            for (int i = 0; i < amount; i++)
            {
                PollenHere.Add(color);
            }
        }
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

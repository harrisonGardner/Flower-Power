using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

/// <summary>
/// The primary game space, encompassing the plots where
/// plants can grow.
/// </summary>
/// <author>Nicholas Gliserman, Harrison Gardner</author>
public class Garden : MonoBehaviour
{
    // PREFABS
    public GameObject plotPrefab;
    public GameObject gardenPrefab;

    // DIMENSIONS
    public int height;
    public int width;
    public int plotLength;
    public GameObject[,] plots;

    /// <summary>
    /// n.b. Having these lists of Plants lets us iterate through the plant-based
    /// actions at a faster pace, i.e. rather than trying to iterate
    /// through all the plots in the 2d array.
    /// </summary>
    public IList<Plant> Flowers { get; } = new List<Plant>();
    public IList<Plant> Weeds { get; } = new List<Plant>();

    // WEATHER
    public Direction WindDirection { get; set; }
    public bool WindyToday { get; set; }

    // RANDOM
    public System.Random random = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        initializeGarden();
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject plot in plots)
        {
            plot.GetComponent<Plot>().UpdatePlot();
        }
        UpdatePlantSprites();
    }

    /// <summary>
    /// Builds the garden object at the beginning of the game.
    ///
    /// Creates the 2d array of plots, creates the plots, intertwines
    /// the plots so each one can easily locate its neighbors without
    /// needing intervention from the Garden class.
    /// </summary>
    /// <param name="height">The number of plots the garden should have along the y axis</param>
    /// <param name="width">The number of plots the garden should have along the x axis</param>
    public void initializeGarden()
    {
        // New 2d Array of Plots
        //this.height = height;
        //this.width = width;
        this.plots = new GameObject[this.width, this.height];
        

        // Iterate through array and add plots                                           
        for (int y = 0; y < this.height; y++)
        {
            for (int x = 0; x < this.width; x++)
            {
                // DUPLICATE PLOT PREFAB
                GameObject prefab = Instantiate<GameObject>(this.plotPrefab,
                    new Vector3(gameObject.transform.position.x + (x * 0.16f), gameObject.transform.position.y + (y * 0.16F), 1F), new Quaternion());

                // Hierarchy
                prefab.transform.parent = gameObject.transform;

                // ADD to ARRAY              
                this.plots[x, y] = prefab;
                prefab.GetComponent<Plot>().Garden = this;
                prefab.GetComponent<Plot>().PlotObject = prefab;
            }
        }

        // Iterate through array and set Neighbors for plots
        for (int y = 0; y < this.height; y++)
        {
            for (int x = 0; x < this.width; x++)
            {
                Neighbor[] surroundingPlots = new Neighbor[9];

                // ITERATE THROUGH ALL DIRECTIONS
                for (int i = 0; i < surroundingPlots.Length; i++)
                {
                    // GET THE DIRECTION
                    Direction direction = Directions.GetDirection(i);
                    // DETERMINE NEIGHBOR POSITION BASED ON DIRECTION
                    int newY = y + direction.Y;
                    int newX = x + direction.X;

                    // IF NEIGHBOR is in the GARDEN 
                    if (isInGarden(newX, newY))
                    {
                        surroundingPlots[i] = new Neighbor(direction, plots[newX, newY].GetComponent<Plot>());
                    }
                    else // USE SPECIAL CONSTRUCTOR INDICATING SPACE is EDGE
                    {
                        surroundingPlots[i] = new Neighbor(direction);
                    }

                }
                // APPEND NEIGHBORS to PLOT
                this.plots[x, y].GetComponent<Plot>().AdjacentPlots = new Neighbors(surroundingPlots);
            }
        }
    }

    private bool isInGarden(int x, int y)
    {
        return (y < height && y >= 0 && x < width && x >= 0);
    }

    /// <summary>
    /// Manages all of the automated events that
    /// happen at the start of the day
    /// </summary>
    public void newDay() // TODO: PUT THIS INTO A NEW MANAGER CLASS
    {
        // Set weather
        // Plants eat and drink
        // Plants health determined
        // Pollination
        // Plant reproduction -- seeds made and placed
        // Random chance of new weed in empty plot

        // Find clashing plant colors
            // Generate pests in each space
        // Pest eats plant and goes to new space
    }

    /// <summary>
    /// Rainy weather restores the water level in each plot of land.
    /// </summary>
    /// <param name="waterAmount"></param>
    public void WaterAllPlots(int waterAmount)
    {
        // RAINING TODAY, i.e. NOT WINDY
        WindyToday = false;

        // Iterate through array
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                this.plots[x, y].GetComponent<Plot>().addWater(waterAmount);
            }
        }
    }

    /// <summary>
    /// Sunny weather gives plants increased amounts of energy to grow.
    /// </summary>
    /// <param name="sunAmount"></param>
    public void SunAllPlots(int sunAmount)
    {
        // SUNNY TODAY, i.e. NOT WINDY
        WindyToday = false;
        
        // Iterate through array
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                this.plots[x, y].GetComponent<Plot>().SunEnergyToday = sunAmount;
            }
        }
    }

    /// <summary>
    /// Windy weather changes the way the wind blows and increases
    /// chances of pollination. 
    /// </summary>
    /// <param name="newWindDirection"></param>
    public void AdjustWindDirection(Direction newWindDirection)
    {
        WindDirection = newWindDirection;
        WindyToday = true;
        SunAllPlots(1);
    }

    public void UpdatePlantSprites()
    {
        IList<Plant> removedPlants = new List<Plant>();
        foreach (Plant flower in this.Flowers)
        {
            Flower tempFlower = (Flower)flower;
            tempFlower.SpriteUpdate();
            if (flower.CurrentStage.CurrentStage == StageType.DEAD)
                removedPlants.Add(flower);
        }
        foreach (Plant remove in removedPlants)
        {
            remove.MyPlot.removePlant();
        }
    }

    /// <summary>
    /// All of the weeds in the garden take sun and water from
    /// plots before the flowers are able to do so
    /// </summary>
    public void weedsEatDrink()
    {
        // TODO: FINISH THIS METHOD WHEN WEED CLASS IS DONE
        // Iterate through the flowers list
        foreach (Plant weed in this.Weeds)
        {

        }
    }

    /// <summary>
    /// After the weeds have taken their share, the flowers
    /// take in the remaining water and sunenergy
    /// </summary>
    public void flowersEatDrink()
    {
        // TODO: FINISH THIS METHOD WHEN FLOWER CLASS IS DONE
        // Iterate through the flowers list
        foreach (Plant flower in this.Flowers)
        {

        }
    }

    public void addPlant(Plant plant)
    {
        Debug.Log("Add Plant in garden called");
        // if the plant is a weed
        if (plant.PlantType == PlantType.Weed)
        {
            this.Weeds.Add(plant);
        }
        // plant is a flower
        else if (plant.PlantType == PlantType.Flower)
        {
            this.Flowers.Add(plant);
        }
    }

    /// <summary>
    /// Removes a plant from the garden.
    /// </summary>
    /// <param name="removeMe">Plant to be removed, can be a flower or a weed</param>
    public void removePlant(Plant removeMe)
    {
        if (removeMe.PlantType == PlantType.Weed)
        {
            this.Weeds.Remove(removeMe);
        }
        else if (removeMe.PlantType == PlantType.Flower)
        {

            this.Flowers.Remove(removeMe);
        }
    }

    // TODO: IMPLEMENT THIS 
    public void addRandomWeed()
    {
        // IF the size of the weeds list is below a certain number
        // Generate random numbers for height & width to choose initial space

        // Check if plot has something growing
        // IF YES, then choose random neighbor

        // Try this five times -- if there still is no success, displace
        // whatever is growing in the fifth space explored.
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Quick way to assess what plant is -- a flower or a weed
/// </summary>
public enum PlantType { Flower, Weed }

/// <summary>
/// Represents a plant object in the game -- either a flower needed
/// to fulfill an order or a weed, which takes resources from the
/// flowers in the garden.
/// </summary>
/// <author>Nicholas Gliserman</author>
public class Plant : MonoBehaviour
{
    // TYPE
    public PlantType PlantType { get; }

    // GAME OBJECTS
    public GameObject plantPrefab;

    // LOCATION
    public Plot MyPlot { get; }

    // PLANT BEHAVIOR
    

    // STATE of the PLANT
    public bool Wilting { get; set; }
    public IPlantHealth Health { get; set; }
    public IPlantStage CurrentStage { get; set; }
    public Color PlantColor { get; set; }

    public Plant(PlantType plantType, IPlantHealth health, Plot plot, Color color)
    {
        PlantType = plantType;
        Health = health;
        MyPlot = plot;

        // ENSURE WEED has no COLOR
        if (PlantType == PlantType.Weed)
            PlantColor = Colors.GetColor(ColorName.NONE);
        else
            PlantColor = color;

        // ADD First PlantStage based on Plant Type
        if (PlantType == PlantType.Weed)
            CurrentStage = new YoungWeed();
        else
            CurrentStage = new Seed();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Ages the plant so that it can eventually reach
    /// the next stage of its life cycle.
    /// </summary>
    public void Grow()
    {
        CurrentStage.DecrementDaysToNextStage(Wilting);
        if (CurrentStage.IsReadyForNextStage())
        {
            IPlantStage temp = CurrentStage.GetNextStage();
            if (temp == null) // IF THIS IS THE TERMINAL STAGE
                MyPlot.removePlant(); // REMOVE from PLOT
            else
                CurrentStage = temp;
        }
    }

    /// <summary>
    /// Plant obtains water and energy from the plot,
    /// with amounts depending on its feeding behavior
    /// </summary>
    public void Feed()
    {
        CurrentStage.FeedingBehavior.CollectWater(MyPlot);
        CurrentStage.FeedingBehavior.CollectSunEnergy(MyPlot);
    }

    // TODO
    public void CheckHealth()
    {

    }

    /// <summary>
    /// Spreads pollen according to wind conditions and the reproductive 
    /// behavior of the plant's current stage
    /// </summary>
    /// <param name="windDirection"></param>
    /// <param name="windyDay"></param>
    public void SpreadPollen(Direction windDirection, bool windyDay)
    {
        CurrentStage.Reproduction.SpreadPollen(MyPlot, windDirection, windyDay);
    }

    /// <summary>
    /// Transforms the pollen in this plot into seeds according to the 
    /// reproductive behavior of the plant's current stage. Then,
    /// spreads the seeds.
    ///
    /// </summary>
    public void MakeSeeds()
    {
        CurrentStage.Reproduction.Seed(MyPlot);
    }
}

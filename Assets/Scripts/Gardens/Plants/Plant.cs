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
/// <author>Nicholas Gliserman, Harrison Gardner</author>
public class Plant : MonoBehaviour
{
    // TYPE
    public PlantType PlantType { get; set; }
    public ISpriteUpdate spriteUpdate;

    // GAME OBJECTS
    public GameObject plantPrefab;

    // LOCATION
    public Plot MyPlot { get; set; }

    // STATE of the PLANT
    public IPlantHealth Health { get; set; }
    public bool isHealthy = true;
    public IPlantStage CurrentStage { get; set; }
    public Color PlantColor { get; set; }

    // TESTING
    public string visibleState;

    public void StartPlant(PlantType plantType, IPlantHealth health, Plot plot, Color color, GameObject plantPrefab)
    {
        PlantType = plantType;
        Health = health;
        MyPlot = plot;
        this.plantPrefab = plantPrefab;

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
    /// Plant obtains water and energy from the plot,
    /// with amounts depending on its feeding behavior
    /// </summary>
    public void Feed()
    {
        int water = CurrentStage.FeedingBehavior.CollectWater(MyPlot);
        int sun = CurrentStage.FeedingBehavior.CollectSunEnergy(MyPlot);
        CheckHealth(sun, water);
    }

    /// <summary>
    /// Given the sun and water taken in today, assesses
    /// if the plant is in a state of good health, bad health,
    /// or even dying.
    /// </summary>
    /// <param name="sunshine"></param>
    /// <param name="water"></param>
    public void CheckHealth(int sunshine, int water)
    {
        Health.FeedingToday(sunshine, water);

        this.isHealthy = !Health.WiltingToday;

        if (CurrentStage.CurrentStage == StageType.DEAD || Health.DyingToday)
        {
            MyPlot.RemovePlantDuringGrowth();
        }
    }

    /// <summary>
    /// Ages the plant so that it can eventually reach
    /// the next stage of its life cycle.
    /// </summary>
    public void Grow()
    {
        CurrentStage.DecrementDaysToNextStage(Health.WiltingToday);

        if (CurrentStage.IsReadyForNextStage())
        {
            IPlantStage temp = CurrentStage.GetNextStage();
            if (temp == null || temp.CurrentStage == StageType.DEAD) // IF THIS IS THE TERMINAL STAGE
                MyPlot.RemovePlantDuringGrowth();
            else
            {
                CurrentStage = temp;

                if (PlantType == PlantType.Flower)
                {
                    Health.SetMinFeedingRequirements(CurrentStage.FeedingBehavior.ThirstIntensity,
                        CurrentStage.FeedingBehavior.FeedingIntensity);
                }
                SpriteUpdateController.AddSpriteToRedraw(spriteUpdate);
            }
        }

        this.visibleState = stringForTesting();
    }

    /// <summary>
    /// Removes Plant from Game via the Plot
    /// </summary>
    public void KillPlant()
    {
        MyPlot.RemoveSinglePlant();
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

    public string stringForTesting()
    {
        return "Stage " + CurrentStage.CurrentStage.ToString()
            + " Color " + PlantColor.Name.ToString() + " Wilting: " + Health.WiltingToday;

    }
}

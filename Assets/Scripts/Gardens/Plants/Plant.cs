using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // LOCATION
    public Plot MyPlot { get; }

    // PLANT BEHAVIOR
    public IFeedingBehavior FeedingBehavior { get; }

    // STATE of the PLANT
    public bool Wilting { get; set; }
    public IPlantHealth Health { get; set; }
    // TODO: IPlantStage { get; set; }
    // TODO: Color PlantColor { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Plant(PlantType plantType, IPlantHealth health, Plot plot)
    {
        PlantType = plantType;
        Health = health;
        MyPlot = plot;

    }

    public void Feed()
    {
        FeedingBehavior.CollectWater();
        FeedingBehavior.CollectSunEnergy();
    }

    public void CheckHealth()
    {

    }

    public void Die()
    {

    }

    public void SpreadPollen()
    {
        //Call the IPlantStage's IReproductionBehavior to spreak pollen
    }

    public void MakeSeeds()
    {
        //Call the IPlantStage's IReproductionBehavior to spreak pollen
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// First stage of a plant object. 
/// </summary>
/// <author>Lisette Peck, Nicholas Gliserman</author>
public class Seed : IPlantStage
{
    public int DaysToNextStage { get; set; }   
    public int CutDifficulty { get; }               
    //public bool MustBeHealthyToProgress { get; }
    public StageType CurrentStage { get; } = StageType.SEED;

    /// <summary>
    /// Creates a seed object, with the default values for DaysToNextStage,
    /// CutDifficulty and MustBeHealthyToProgress;
    /// </summary>
    public Seed()
    {
        DaysToNextStage = 1;
        CutDifficulty = 10;
        //MustBeHealthyToProgress = true;
    }

    /// <summary>
    /// Decrements the number of days until the Seed can move to
    /// the sprout stage.
    /// Only decrements if the seed is healthy.
    /// </summary>
    /// <param name="isWilting">If the plant is currently wilting</param>
    public void DecrementDaysToNextStage(bool wilting)
    {
        if (!wilting)
            DaysToNextStage--;
    }

    /// <summary>
    /// Determines if there are any days left until the Seed can move
    /// to the sprout stage.
    /// </summary>
    /// <returns>True if the seed is ready to grow into a Sprout.</returns>
    public bool IsReadyForNextStage()
    {
        return (DaysToNextStage <= 0);
    }

    /// <summary>
    /// Creates an object of the SproutStage.
    /// </summary>
    /// <returns>A sprout object.</returns>
    public IPlantStage GetNextStage()
    {
        return new Sprout();
    }
}

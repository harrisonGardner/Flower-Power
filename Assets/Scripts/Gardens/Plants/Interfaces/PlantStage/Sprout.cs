using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Second stage of the plant object.
/// </summary>
/// <author>Lisette Peck, Nicholas Gliserman</author>
public class Sprout : IPlantStage
{
    public int DaysToNextStage { get; set; }
    public int CutDifficulty { get; }
    public StageType CurrentStage { get; } = StageType.SPROUT;
    public IReproductionBehavior Reproduction { get; } = new Sterile();
    public IFeedingBehavior FeedingBehavior { get; } = new FlowerFeedingBehavior(2, 2);

    /// <summary>
    /// Creates a SproutStage object, with the default values for DaysToNextStage, CutDifficulty and MustBeHealthyToProgress;
    /// </summary>
    public Sprout()
    {
        DaysToNextStage = 2;
        CutDifficulty = 1;
    }

    /// <summary>
    /// Decrements the number of days until the Sprout can move to the flowering stage.
    /// Only decrements if the Sprout is healthy.
    /// </summary>
    /// <param name="isWilting">If the plant is currently wilting</param>
    public void DecrementDaysToNextStage(bool wilting)
    {
        if (!wilting)
            DaysToNextStage--;
    }

    /// <summary>
    /// Determines if there are any days left until the Sprout can move to the flowering stage.
    /// </summary>
    /// <returns>True if the Sprout is ready to flower.</returns>
    public bool IsReadyForNextStage() { return (DaysToNextStage <= 0); }

    /// <summary>
    /// Creates an object of the Flowering Stage.
    /// </summary>
    /// <returns>A Flowering object.</returns>
    public IPlantStage GetNextStage() { return new Flowering(); }
}

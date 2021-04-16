using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Second and last stage of the weed object.
/// </summary>
/// <author>Lisette Peck, Nicholas Gliserman</author>
public class MatureWeed : IPlantStage
{
    public int DaysToNextStage { get; set; }
    public int CutDifficulty { get; }
    public StageType CurrentStage { get; } = StageType.MATUREWEED;
    public IReproductionBehavior Reproduction { get; } = new WeedReproduction();
    public IFeedingBehavior FeedingBehavior { get; } = new WeedFeedingBehavior(3, 3);

    /// <summary>
    /// Creates a MatureWeed object, with the default values for DaysToNextStage, CutDifficulty and MustBeHealthyToProgress;
    /// </summary>
    public MatureWeed()
    {
        DaysToNextStage = 50;
        CutDifficulty = 8;
    }

    /// <summary>
    /// A mature weed will never die of its own accord...so this method does nothing.
    /// </summary>
    public void DecrementDaysToNextStage(bool wilting) {  }

    /// <summary>
    /// Determines if there are any days left until the weed dies without being cut.
    /// </summary>
    /// <returns>True if the weed is ready to die without being cut.</returns>
    public bool IsReadyForNextStage() { return false; }

    /// <summary>
    /// A mature weed will never die of its own accord
    /// </summary>
    public IPlantStage GetNextStage() { return new MatureWeed(); }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// First stage of the weed object.
/// </summary>
/// <author>Lisette Peck, Nicholas Gliserman</author>
public class YoungWeed : IPlantStage
{
    public int DaysToNextStage { get; set; }
    public int CutDifficulty { get; }
    public StageType CurrentStage { get; } = StageType.YOUNGWEED;

    /// <summary>
    /// Creates a YoungWeed object, with the default values for DaysToNextStage, CutDifficulty and MustBeHealthyToProgress;
    /// </summary>
    public YoungWeed()
    {
        DaysToNextStage = 2;
        CutDifficulty = 5;
    }

    /// <summary>
    /// Decrements the number of days until the YoungWeed can moves to the MatureWeed stage.
    /// Decrements regardless of if the weed is healthy.
    /// </summary>
    public void DecrementDaysToNextStage(bool wilting) {DaysToNextStage--;}

    /// <summary>
    /// Determines if there are any days left until the weed moves to the MatureWeed stage.
    /// </summary>
    /// <returns>True if the YoungWeed is ready to grow into a MatureWeed.</returns>
    public bool IsReadyForNextStage() { return (DaysToNextStage <= 0); }

    /// <summary>
    /// Creates an object of the MatureWeed stage.
    /// </summary>
    /// <returns>A MatureWeed object.</returns>
    public IPlantStage GetNextStage() { return new MatureWeed(); }
}

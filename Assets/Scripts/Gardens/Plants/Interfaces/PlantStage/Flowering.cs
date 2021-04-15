using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Third stage of the Plant object.
/// </summary>
/// <author>Lisette Peck, Nicholas Gliserman</author>
public class Flowering : IPlantStage
{
    public int DaysToNextStage { get; set; }
    public int CutDifficulty { get; }
    public StageType CurrentStage { get; } = StageType.FLOWERING;
    public IReproductionBehavior Reproduction { get; } = new FlowerReproduction();

    /// <summary>
    /// Creates a Flowering Stage object, with the default values for DaysToNextStage, CutDifficulty and MustBeHealthyToProgress;
    /// </summary>
    public Flowering()
    {
        DaysToNextStage = 5;
        CutDifficulty = 3;
    }

    /// <summary>
    /// Decrements the number of days until the Flowering Plant moves to the dying phase.
    /// Decrements at a faster pace is the plant is unhealthy.
    /// </summary>
    /// <param name="isWilting">If the plant is currently wilting</param>
    public void DecrementDaysToNextStage(bool wilting)
    {
        if (wilting)
            DaysToNextStage -= 2;
        else
            DaysToNextStage--;
    }

    /// <summary>
    /// Determines if there are any days left until the plant moves to the dying stage.
    /// </summary>
    /// <returns>True if the flower needs to move to the dying stage.</returns>
    public bool IsReadyForNextStage()
    {
        return (DaysToNextStage <= 0);
    }

    /// <summary>
    /// Creates an object of the DyingStage.
    /// </summary>
    /// <returns>A Dying object.</returns>
    public IPlantStage GetNextStage()
    {
        return new Dying();
    }

}

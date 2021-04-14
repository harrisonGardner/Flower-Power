using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The final stage of a flower in which it dies,
/// such that the plot returns to a state of being empty.
/// </summary>
/// <author>Lisette Peck, Nicholas Gliserman</author>
public class Dying : IPlantStage
{
    public int DaysToNextStage { get; set; }
    public int CutDifficulty { get; }
    public StageType CurrentStage { get; } = StageType.DYING;

    /// <summary>
    /// Creates a seed object, with the default values for DaysToNextStage, CutDifficulty and MustBeHealthyToProgress;
    /// </summary>
    public Dying()
    {
        DaysToNextStage = 4;
        CutDifficulty = 1;
    }

    /// <summary>
    /// Decrements the number of days the Dying Plant has left.
    /// Decrements at a faster pace is the plant is unhealthy.
    /// </summary>
    /// <param name="isWilting">If the plant is currently wilting</param>
    public void DecrementDaysToNextStage(bool isWilting)
    {
        if (isWilting)
            DaysToNextStage -= 2;
        else
            DaysToNextStage--;
}

    /// <summary>
    /// Determines if the dying plant has any days left.
    /// </summary>
    /// <returns>False if the plant still has more days left.</returns>
    public bool IsReadyForNextStage()
    {
        return (DaysToNextStage <= 0);
    }

    /// <summary>
    /// There is no stage after Dying -- the null
    /// value returned should be used by the plant to
    /// remove itself from the plot.
    /// </summary>
    /// <returns> </returns>
    public IPlantStage GetNextStage()
    {
        return null;
    }
}

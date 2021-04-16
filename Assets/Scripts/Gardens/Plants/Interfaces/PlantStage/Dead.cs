using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : IPlantStage
{
    public int DaysToNextStage { get; set; } = 0;

    public int CutDifficulty { get; } = 0;

    public StageType CurrentStage { get; } = StageType.DEAD;

    public IReproductionBehavior Reproduction { get; } = null;

    public IFeedingBehavior FeedingBehavior { get; } = null;

    public void DecrementDaysToNextStage(bool wilting) { }

    public IPlantStage GetNextStage()
    {
        return null;
    }

    public bool IsReadyForNextStage()
    {
        return true;
    }
}


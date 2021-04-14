using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dying : MonoBehaviour, IPlantStage
{
    public int DaysToNextStage { get; }
    [Range(0, 10)]
    public int CutDifficulty { get; }
    public bool MustBeHealthyToProgress { get; }

    /// <summary>
    /// Creates a seed object, with the default values for DaysToNextStage, CutDifficulty and MustBeHealthyToProgress;
    /// </summary>
    public void Dying()
    {
        DaysToNextStage = 4;
        CutDifficulty = 1;
        MustBeHealthyToProgress = true;
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
    /// 
    /// </summary>
    /// <returns> </returns>
    public IPlantStage GetNextStage()
    {
        //TODO    -- Not sure what we want to do here.
    }

    /// <summary>
    /// 
    /// </summary>
    public void GetReproductionBehavior()
    {
        //TODO
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

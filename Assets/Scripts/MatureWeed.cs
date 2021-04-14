using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Second and last stage of the weed object.
/// </summary>
public class MatureWeed : MonoBehaviour, IPlantStage
{
    public int DaysToNextStage { get; }
    [Range(0, 10)]
    public int CutDifficulty { get; }
    public bool MustBeHealthyToProgress { get; }

    /// <summary>
    /// Creates a MatureWeed object, with the default values for DaysToNextStage, CutDifficulty and MustBeHealthyToProgress;
    /// </summary>
    public void MatureWeed()
    {
        DaysToNextStage = 50;
        CutDifficulty = 8;
        MustBeHealthyToProgress = false;
    }

    /// <summary>
    /// Decrements the number of days until the MatureWeed dies without being cut.
    /// Decrements regardless of if the weed is healthy.
    /// </summary>
    public void DecrementDaysToNextStage()
    {
        DaysToNextStage--;
    }

    /// <summary>
    /// Determines if there are any days left until the weed dies without being cut.
    /// </summary>
    /// <returns>True if the weed is ready to die without being cut.</returns>
    public bool IsReadyForNextStage()
    {
        return (DaysToNextStage <= 0);
    }

    /// <summary>
    /// 
    /// </summary>
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

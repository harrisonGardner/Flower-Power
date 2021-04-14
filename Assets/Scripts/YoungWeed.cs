using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// First stage of the weed object.
/// </summary>
public class YoungWeed : MonoBehaviour, IPlantStage
{
    public int DaysToNextStage { get; }
    [Range(0, 10)]
    public int CutDifficulty { get; }
    public bool MustBeHealthyToProgress { get; }

    /// <summary>
    /// Creates a YoungWeed object, with the default values for DaysToNextStage, CutDifficulty and MustBeHealthyToProgress;
    /// </summary>
    public void YoungWeed()
    {
        DaysToNextStage = 2;
        CutDifficulty = 5;
        MustBeHealthyToProgress = false;
    }

    /// <summary>
    /// Decrements the number of days until the YoungWeed can moves to the MatureWeed stage.
    /// Decrements regardless of if the weed is healthy.
    /// </summary>
    public void DecrementDaysToNextStage()
    {
            DaysToNextStage--;
    }

    /// <summary>
    /// Determines if there are any days left until the weed moves to the MatureWeed stage.
    /// </summary>
    /// <returns>True if the YoungWeed is ready to grow into a MatureWeed.</returns>
    public bool IsReadyForNextStage()
    {
        return (DaysToNextStage <= 0);
    }

    /// <summary>
    /// Creates an object of the MatureWeed stage.
    /// </summary>
    /// <returns>A MatureWeed object.</returns>
    public IPlantStage GetNextStage()
    {
        MatureWeed nextStage = new MatureWeed();
        return nextStage;
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

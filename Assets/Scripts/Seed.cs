using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// First stage of a plant object. 
/// </summary>
public class Seed : MonoBehaviour, IPlantStage
{
    public int DaysToNextStage { get; }   
    [Range(0, 10)]
    public int CutDifficulty { get; }               
    public bool MustBeHealthyToProgress { get; }

    /// <summary>
    /// Creates a seed object, with the default values for DaysToNextStage, CutDifficulty and MustBeHealthyToProgress;
    /// </summary>
    public void Seed()
    {
        DaysToNextStage = 1;
        CutDifficulty = 10;
        MustBeHealthyToProgress = true;
    }

    /// <summary>
    /// Decrements the number of days until the Seed can move to the sprout stage.
    /// Only decrements if the seed is healthy.
    /// </summary>
    /// <param name="isWilting">If the plant is currently wilting</param>
    public void DecrementDaysToNextStage(bool isWilting)
    {
        if (MustBeHealthyToProgress && !isWilting)
            DaysToNextStage--;
    }

    /// <summary>
    /// Determines if there are any days left until the Seed can move to the sprout stage.
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
        Sprout nextStage = new Sprout();
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

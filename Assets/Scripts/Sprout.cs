using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Second stage of the plant object.
/// </summary>
public class Sprout : MonoBehaviour, IPlantStage
{
    public int DaysToNextStage { get; }
    [Range(0, 10)]
    public int CutDifficulty { get; }
    public bool MustBeHealthyToProgress { get; }

    /// <summary>
    /// Creates a SproutStage object, with the default values for DaysToNextStage, CutDifficulty and MustBeHealthyToProgress;
    /// </summary>
    public void Sprout()
    {
        DaysToNextStage = 2;
        CutDifficulty = 1;
        MustBeHealthyToProgress = true;
    }

    /// <summary>
    /// Decrements the number of days until the Sprout can move to the flowering stage.
    /// Only decrements if the seed is healthy.
    /// </summary>
    /// <param name="isWilting">If the plant is currently wilting</param>
    public void DecrementDaysToNextStage(bool isWilting)
    {
        if (MustBeHealthyToProgress)
        {
            if (!isWilting)
                DaysToNextStage--;
            else
                DaysToNextStage++;
        }
    }

    /// <summary>
    /// Determines if there are any days left until the Sprout can move to the flowering stage.
    /// </summary>
    /// <returns>True if the Sprout is ready to flower.</returns>
    public bool IsReadyForNextStage()
    {
        return (DaysToNextStage <= 0);
    }

    /// <summary>
    /// Creates an object of the Flowering Stage.
    /// </summary>
    /// <returns>A Flowering object.</returns>
    public IPlantStage GetNextStage()
    {
        Flowering nextStage = new Flowering();
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

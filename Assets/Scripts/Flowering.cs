using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Third stage of the Plant object.
/// </summary>
public class Flowering : MonoBehaviour, IPlantStage
{
    public int DaysToNextStage { get; }
    [Range(0, 10)]
    public int CutDifficulty { get; }
    public bool MustBeHealthyToProgress { get; }

    /// <summary>
    /// Creates a Flowering Stage object, with the default values for DaysToNextStage, CutDifficulty and MustBeHealthyToProgress;
    /// </summary>
    public void Flowering()
    {
        DaysToNextStage = 5;
        CutDifficulty = 3;
        MustBeHealthyToProgress = true;
    }

    /// <summary>
    /// Decrements the number of days until the Flowering Plant moves to the dying phase.
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
        Dying nextStage = new Dying();
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

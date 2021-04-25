using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Stores the game settings such as number of days, the level name
/// and the best time so far for that level.
/// </summary>
/// <author>Megan Lisette Peck</author>
public class GameSettings //: MonoBehaviour
{
    public int MaxNumDays { get; private set; }
    public string LevelName { get; private set; }
    public int BestTime { get; private set; }

    /// <summary>
    /// Creates an orderSettings object. 
    /// Stores the number of days, the level name and the best time 
    /// so far for that level.
    /// </summary>
    /// <param name="maxNumDays">Number of days the player has in the game</param>
    /// <param name="levelName">Easy, Medium, Hard</param>
    /// <param name="bestTime">Player high score for this level</param>
    public GameSettings(int maxNumDays = 100, string levelName = "Dummy Level", int bestTime = -1)
    {
        this.MaxNumDays = maxNumDays;
        this.LevelName = levelName;
        this.BestTime = bestTime;
    }

    public void setBestTime(int bestTime)
    {
        this.BestTime = bestTime;
    }


    public override string ToString()
    {
        return $"NumOfDays: {MaxNumDays}, Level: {LevelName}, BestTime: {BestTime}";
    }
}

using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Reads the current best score, for the given level and
/// updates it if the new best score is higher.
/// </summary>
/// <author>Megan Lisette Peck</author>
public class PrintBestScore //: MonoBehaviour
{
    public static void WriteBestScore(string level, int newScore)
    {
        Debug.Log("In WriteBestScore");
        // RETREIVE CURRENT LEVEL FILE AND GET THE CURRENT STATS FROM IT
        string levelSettingsFile = FindFileLocations.findLevelSettingsFile(level);
        GameSettings updatelevelSettings = ReadLevelOrderandSettings.LoadSettings(levelSettingsFile);

        updatelevelSettings.setBestTime(newScore);
        Debug.Log($"NewScore: {newScore}");
        try
        {
            using (StreamWriter writer = new StreamWriter(levelSettingsFile))
            {
                Debug.Log("In writer");
                string newJsonDeatails = $"[{{\"maxNumDays\": 100,\"levelName\": \"Easy\",\"bestTime\": {updatelevelSettings.BestTime}}}]";
                writer.WriteLine(newJsonDeatails);
            }
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine("Can't find the file FlowerPowerStats.txt");
            Console.WriteLine(ex.StackTrace);
        }
        catch (IOException ex)
        {
            Console.WriteLine("IO Problem writing to FlowerPowerStats.txt");
            Console.WriteLine(ex.StackTrace);
        }
    }
}

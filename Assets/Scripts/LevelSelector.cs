using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public static int LevelNumber { get; set; }

    public void StartGame()
    {
        DontDestroyOnLoad(transform.gameObject);
        SceneManager.LoadScene("FlowerPower");
    }

    public static string getSelectedLevel()
    {
        switch (LevelNumber)
        {
            case 3:
                return "Hard";
            case 2:
                return "Medium";
            default:
                return "Easy";
        }
    }
}

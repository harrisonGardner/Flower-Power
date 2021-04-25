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
}

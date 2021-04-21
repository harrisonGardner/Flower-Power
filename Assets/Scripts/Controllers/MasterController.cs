using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Initializes important game objects and classes; controls the flow of the game state.
/// </summary>
public class MasterController : MonoBehaviour
{
    // FIELD to KEEP TRACK of TIME
    //
    public GameObject GardenScript;
    Garden garden;
    DayController day;
    Colors allColors;

    public static float TimeOfDay { get; private set; } = 0;
    public static int DayNumber { get; private set; } = 0;

    private IList<IUpdateController> updates = new List<IUpdateController>();

    void Awake()
    {
        // GET the GARDEN from the GARDENSCRIPT GAME OBJECT
        garden = GardenScript.GetComponent<Garden>();

        // CREATE A DAY CONTROLLER
        day = new DayController(garden);
        updates.Add(day);

        // TODO: Add a sprite update controller

        // COLORS
        allColors = new Colors();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (DayController control in updates)
        {
            control.ActionOnUpdate();
        }

        TimeOfDay = day.TimeOfDay;
        DayNumber = day.dayNumber;
    }
}

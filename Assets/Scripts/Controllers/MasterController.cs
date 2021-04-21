using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Initializes important game objects and classes; controls the flow of the game state.
/// </summary>
public class MasterController : MonoBehaviour
{
    public GameObject GardenScript;
    Garden garden;
    DayController day;
    Colors allColors;
    SpriteUpdateController spriteUpdate;

    // FIELDs to KEEP TRACK of TIME
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

        // CREATE SPRITE CONTROLLER
        spriteUpdate = new SpriteUpdateController();
        updates.Add(spriteUpdate);

        // COLORS
        allColors = new Colors();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (IUpdateController control in updates)
        {
            control.ActionOnUpdate();
        }

        TimeOfDay = day.TimeOfDay;
        DayNumber = day.dayNumber;
    }
}

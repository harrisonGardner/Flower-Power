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
    public Colors allColors;

    // CONTROLLERS
    DayController day;
    SpriteUpdateController spriteUpdate;

    public static System.Random universallyAvailableRandom = new System.Random();
    public Order order;

    // FIELDs to KEEP TRACK of TIME
    public static float TimeOfDay { get; private set; } = 0;
    public static int DayNumber { get; private set; } = 0;

    private IList<IUpdateController> updates = new List<IUpdateController>();

    private void Awake()
    {
        // COLORS
        allColors = new Colors();
    }

    void Start()
    {
        // GET the GARDEN from the GARDENSCRIPT GAME OBJECT
        garden = GardenScript.GetComponent<Garden>();
        garden.initializeGarden();

        // CREATE A DAY CONTROLLER
        day = new DayController(garden);
        updates.Add(day);

        // CREATE SPRITE CONTROLLER
        spriteUpdate = new SpriteUpdateController();
        updates.Add(spriteUpdate);

        // ORDER
        order = GameObject.Find("OrderInfo").GetComponent<Order>();
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
        order.UpdateAll();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayController : IUpdateController
{
    private DailyEvents schedule;
    public int TimeOfDay { get; private set; }
    public int dayNumber { get; private set; }
    public Garden garden;

    public DayController(Garden garden)
    {
        schedule = new DailyEvents();
        this.garden = garden;
    }

    public void ActionOnUpdate()
    {
        // UPDATE the TIME

        // FIND OUT WHAT EVENT
        // IF NOT NONE...
            // LAUNCH APPROPRIATE ACTION (SWITCH STATEMENT?)

            // IF END of DAY is RETURNED, RESET TIME of DAY to zero
            // INCREMENT DAY NUMBER

        // CHECK if VICTORY CONDITIONS MET

        throw new System.NotImplementedException();
    }
}

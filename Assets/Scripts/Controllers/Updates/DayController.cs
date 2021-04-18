using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayController : IUpdateController
{
    private DailyEvents schedule;
    private int timeOfDay;
    private int dayNumber;

    public DayController()
    {
        schedule = new DailyEvents();
    }

    public void ActionOnUpdate()
    {
        // UPDATE the TIME

        // FIND OUT WHAT EVENT
        // IF NOT NONE...
            // LAUNCH APPROPRIATE ACTION (SWITCH STATEMENT?)

            // IF END of DAY is RETURNED, RESET TIME of DAY to zero
            // INCREMENT DAY NUMBER

        throw new System.NotImplementedException();
    }
}

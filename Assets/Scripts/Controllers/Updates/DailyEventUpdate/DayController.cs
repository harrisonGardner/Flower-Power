using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Responsible for enacting particular actions on a daily schedule.
/// </summary>
public class DayController : IUpdateController
{
    private DailyEvents schedule = new DailyEvents();
    public float TimeOfDay { get; private set; }
    public int dayNumber { get; private set; }
    public Garden garden;
    public IDictionary<DailyEventType, IGardenUpdate> dailyEvents =
        new Dictionary<DailyEventType, IGardenUpdate>()
    {
            {DailyEventType.NEWDAY, new WeatherUpdate() },
            {DailyEventType.WEATHER, new WeatherUpdate() },
            {DailyEventType.WEEDFEEDING, new WeedFeed() },
            {DailyEventType.FLOWERFEEDING, new FlowerFeed() },
            {DailyEventType.WEEDPOLLINATION, new WeedPollinate() },
            {DailyEventType.FLOWERPOLLINATION, new FlowerPollinate() },
            {DailyEventType.WEEDSEEDING, new WeedSeed() },
            {DailyEventType.FLOWERSEEDING, new FlowerSeed() },
            {DailyEventType.WEEDGROW, new WeedGrow() },
            {DailyEventType.FLOWERGROW, new FlowerGrow() },
            {DailyEventType.COLORCLASH, new ColorClash() }, // TODO
            {DailyEventType.DYING, new DeathEvent() } // TODO: IS THIS NEEDED???
    };

    public DayController(Garden garden)
    {
        schedule = new DailyEvents();
        this.garden = garden;
    }

    public void ActionOnUpdate()
    {
        // UPDATE the TIME
        TimeOfDay += Time.deltaTime;
        // FIND OUT WHAT EVENT to INSTIGATE
        DailyEventType currentEvent = this.schedule.GetCurrentEvent(TimeOfDay);

        // IF NOT NONE...
        if (currentEvent != DailyEventType.NONE)
        {
            if (currentEvent == DailyEventType.ENDDAY)// IF END of DAY       
            {
                TimeOfDay = 0.0f; // RESET TIME of DAY to zero
                dayNumber++; // INCREMENT DAY NUMBER
            }
            else // LAUNCH APPROPRIATE ACTION
            {
                dailyEvents[currentEvent].ActionOnUpdate(garden);
            }
        }
        // TODO: HERE or ELSEWHERE...CHECK if VICTORY CONDITIONS MET 
    }
}

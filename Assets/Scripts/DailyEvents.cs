using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DailyEventType
{
    NONE, NEWDAY, WEATHER,
    WEEDFEEDING, FLOWERFEEDING,
    WEEDPOLLINATION, FLOWERPOLLINATION,
    WEEDSEEDING, FLOWERSEEDING,
    COLORCLASH, DYING, ENDDAY
}

public class EventInfo
{
    public int scheduledTime;
    public bool happenedToday;

    public EventInfo(int time)
    {
        scheduledTime = time;
        happenedToday = false;
    }
}

/// <summary>
/// Dictates when events should occur within a given day.
/// </summary>
public class DailyEvents : MonoBehaviour
{
    public int dayLengthMilliseconds = 5000;
    public int intervalTime = 100;
    public bool lastEventHappened;
    public IDictionary<DailyEventType, EventInfo> daysEvents;

    public DailyEvents()
    {
        daysEvents = new Dictionary<DailyEventType, EventInfo>()
        {
            { DailyEventType.NEWDAY,
                new EventInfo (this.intervalTime * (int) DailyEventType.NEWDAY) },
            { DailyEventType.WEATHER,
                new EventInfo (this.intervalTime * (int) DailyEventType.WEATHER) },
            { DailyEventType.WEEDFEEDING,
                new EventInfo (this.intervalTime * (int) DailyEventType. WEEDFEEDING) },
            { DailyEventType.FLOWERFEEDING,
                new EventInfo (this.intervalTime * (int) DailyEventType. FLOWERFEEDING)},
            { DailyEventType.WEEDPOLLINATION,
                new EventInfo (this.intervalTime * (int) DailyEventType. WEEDPOLLINATION)},
            { DailyEventType.FLOWERPOLLINATION,
                new EventInfo (this.intervalTime * (int) DailyEventType.FLOWERPOLLINATION) },
            { DailyEventType.WEEDSEEDING,
                new EventInfo (this.intervalTime * (int) DailyEventType.WEEDSEEDING) },
            { DailyEventType.FLOWERFEEDING,
                new EventInfo (this.intervalTime * (int) DailyEventType.FLOWERFEEDING)},
            { DailyEventType.COLORCLASH,
                new EventInfo (this.intervalTime * (int) DailyEventType.COLORCLASH) },
            { DailyEventType.DYING ,
                new EventInfo (this.intervalTime * (int) DailyEventType.DYING) },
            { DailyEventType.ENDDAY ,
                new EventInfo (this.dayLengthMilliseconds) }
        };
    }

    
    public DailyEventType GetCurrentEvent(int timeOfDay)
    {
        // ITERATE THROUGH ALL EVENT TYPES
        foreach (KeyValuePair<DailyEventType, EventInfo> pair in daysEvents)
        {
            // IF THE TIME IS AT or AFTER the EVENT's SCHEDULE TIME
            // AND the EVENT has NOT YET HAPPENED
            if (pair.Value.scheduledTime >= timeOfDay && !pair.Value.happenedToday)
            {
                // SPECIAL CASES:
                // BEGINNING of DAY -- MUST INDICATE ALL OTHER EVENTS HAVE NOT YET HAPPENED
                if (pair.Key == DailyEventType.NEWDAY) // IF THE EVENT is a NEW DAY, RESET HAPPENED TODAY BOOL
                {
                    foreach (KeyValuePair<DailyEventType, EventInfo> nestedPair in daysEvents)
                    {
                        nestedPair.Value.happenedToday = false;
                    }
                    pair.Value.happenedToday = true;
                    return DailyEventType.NEWDAY;
                }

                // END of DAY -- MUST RESET BEGINNING OF DAY
                if (pair.Key == DailyEventType.ENDDAY)
                {
                    daysEvents[DailyEventType.NEWDAY].happenedToday = false;
                    pair.Value.happenedToday = true;
                    return DailyEventType.ENDDAY;
                }

                // REGUALR CASE: MARK EVENT as having HAPPENED, THEN RETURN the KEY
                pair.Value.happenedToday = true;
                return pair.Key;
            }
        }

        // NO EVENT HAPPENED
        return DailyEventType.NONE;
    }

}


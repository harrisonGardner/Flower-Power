using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// List of events occuring within a day
/// </summary>
public enum DailyEventType
{
    NONE, NEWDAY, WEATHER,
    WEEDFEEDING, FLOWERFEEDING,
    WEEDPOLLINATION, FLOWERPOLLINATION,
    WEEDSEEDING, FLOWERSEEDING,
    WEEDGROW, FLOWERGROW,
    PESTSPREAD, DYING, ENDDAY
}

// TODO: Make into a generic structure
// IMPROVED Functionality by shuffling the events in a queue structure.
// GET rid of bool as if the event happened, it will be pushed to the back
// ONLY 1 ACCESS needed
public class EventInfo //: MonoBehaviour
{
    public float scheduledTime;
    public bool happenedToday;

    public EventInfo(float time)
    {
        scheduledTime = time;
        happenedToday = false;
    }
}

/// <summary>
/// Dictates when events should occur within a given day.
/// </summary>
/// <author>Nicholas Gliserman</author>
public class DailyEvents : MonoBehaviour
{
    public float dayLengthSeconds = 5.0f;
    public float intervalTime = 0.1f;
    public bool lastEventHappened;
    public IDictionary<DailyEventType, EventInfo> daysEvents;

    public void InitializeDailyEvents()
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
            { DailyEventType.FLOWERSEEDING,
                new EventInfo (this.intervalTime * (int) DailyEventType.FLOWERSEEDING)},
            { DailyEventType.WEEDGROW,
                new EventInfo (this.intervalTime * (int) DailyEventType.WEEDGROW) },
            { DailyEventType.FLOWERGROW,
                new EventInfo (this.intervalTime * (int) DailyEventType.FLOWERGROW)},
            { DailyEventType.PESTSPREAD,
                new EventInfo (this.intervalTime * (int) DailyEventType.PESTSPREAD) }, //TODO
            { DailyEventType.DYING,
                new EventInfo (this.intervalTime * (int) DailyEventType.DYING) }, // TODO
            { DailyEventType.ENDDAY,
                new EventInfo (this.dayLengthSeconds) }
        };
    }

    /// <summary>
    /// Given the time of the day, will return what event should happen (if any)
    /// </summary>
    /// <param name="timeOfDay"></param>
    /// <returns></returns>
    public DailyEventType GetCurrentEvent(float timeOfDay)
    {
        // ITERATE THROUGH ALL EVENT TYPES
        foreach (KeyValuePair<DailyEventType, EventInfo> pair in daysEvents)
        {
            // IF THE TIME IS AT or AFTER the EVENT's SCHEDULE TIME
            // AND the EVENT has NOT YET HAPPENED
            if (timeOfDay > pair.Value.scheduledTime && !pair.Value.happenedToday)
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

                // END of DAY -- MUST RESET to BEGINNING OF DAY
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


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// List of events occuring within a day
/// </summary>
/// <author>Nicholas Gliserman & Megan Lisette Peck</author>
public enum DailyEventType
{
    NONE, NEWDAY, WEATHER,
    WEEDFEEDING, FLOWERFEEDING,
    WEEDPOLLINATION, FLOWERPOLLINATION,
    WEEDSEEDING, FLOWERSEEDING,
    WEEDGROW, FLOWERGROW,
    PESTSPREAD, DYING, ENDDAY
}

/// < summary >
/// Holds the event type and the time that is should happen
/// during each day.
/// </summary>
public class EventInfo
{
    public DailyEventType dailyEventType;
    public float scheduledTime;
    public EventInfo(DailyEventType eventType, float time)
    {
        dailyEventType = eventType;
        scheduledTime = time;
    }
}

/// < summary >
/// Creates a revolvingQueue of type EventInfo called "daysEvents"
/// which holds each event and the time it should happen each day.
/// </summary>
public class DailyEvents //: MonoBehaviour
{
    public float dayLengthSeconds = 5.0f;
    public float intervalTime = 0.1f;
    public bool lastEventHappened;
    public static int count; // = Enum.GetValues(typeof(DailyEventType)).Length - 2;
    //Minus 2, "NONE" & "DYING" are not in the Daily Event count
    private RevolvingQueue<EventInfo> daysEvents;

    public void InitializeDailyEvents()
    {
        count = Enum.GetValues(typeof(DailyEventType)).Length - 2;
        daysEvents  = new RevolvingQueue<EventInfo>(count);

        daysEvents.Enqueue(new EventInfo(DailyEventType.NEWDAY, (this.intervalTime * (int)DailyEventType.NEWDAY)));
        daysEvents.Enqueue(new EventInfo(DailyEventType.WEATHER, (this.intervalTime * (int)DailyEventType.WEATHER)));
        daysEvents.Enqueue(new EventInfo(DailyEventType.WEEDFEEDING, (this.intervalTime * (int)DailyEventType.WEEDFEEDING)));
        daysEvents.Enqueue(new EventInfo(DailyEventType.FLOWERFEEDING, (this.intervalTime * (int)DailyEventType.FLOWERFEEDING)));
        daysEvents.Enqueue(new EventInfo(DailyEventType.WEEDPOLLINATION, (this.intervalTime * (int)DailyEventType.WEEDPOLLINATION)));
        daysEvents.Enqueue(new EventInfo(DailyEventType.FLOWERPOLLINATION, (this.intervalTime * (int)DailyEventType.FLOWERPOLLINATION)));
        daysEvents.Enqueue(new EventInfo(DailyEventType.PESTSPREAD, (this.intervalTime * (int)DailyEventType.PESTSPREAD)));
        daysEvents.Enqueue(new EventInfo(DailyEventType.WEEDSEEDING, (this.intervalTime * (int)DailyEventType.WEEDSEEDING)));
        daysEvents.Enqueue(new EventInfo(DailyEventType.FLOWERSEEDING, (this.intervalTime * (int)DailyEventType.FLOWERSEEDING)));
        daysEvents.Enqueue(new EventInfo(DailyEventType.WEEDGROW, (this.intervalTime * (int)DailyEventType.WEEDGROW)));
        daysEvents.Enqueue(new EventInfo(DailyEventType.FLOWERGROW, (this.intervalTime * (int)DailyEventType.FLOWERGROW)));
        daysEvents.Enqueue(new EventInfo(DailyEventType.ENDDAY, this.dayLengthSeconds));
    }

    /// <summary>
    /// Given the time of the day, will return what event should happen (if any)
    /// </summary>
    /// <param name = "timeOfDay" ></ param >
    /// < returns > What even should happen(if any)</returns>
    public DailyEventType GetCurrentEvent(float timeOfDay)
    {
        // GET NEXT EVENT IN THE REVOLVING QUEUE
        EventInfo nextEvent = daysEvents.Peek();
        float nextEventScheduledTime = nextEvent.scheduledTime;

        // IF THE TIME IS AT or AFTER the EVENT's SCHEDULE TIME
        if (timeOfDay > nextEvent.scheduledTime)
        {
            // MOVE EVENT TO END OF THE QUEUE, AND RETURN IT AS THE CURRENT EVENT
            daysEvents.MoveItemToTail();
            return nextEvent.dailyEventType;
        }
        // ELSE - NO EVENT HAPPENED
        return DailyEventType.NONE;
    }
}


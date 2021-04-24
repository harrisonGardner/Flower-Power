using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// List of events occuring within a day
/// </summary>
public enum DailyEventType2
{
    NONE, NEWDAY, WEATHER,
    WEEDFEEDING, FLOWERFEEDING,
    WEEDPOLLINATION, FLOWERPOLLINATION,
    WEEDSEEDING, FLOWERSEEDING,
    WEEDGROW, FLOWERGROW,
    COLORCLASH, DYING, ENDDAY
}

/// < summary >
/// Holds the event type and the time that is should happen
/// during each day.
/// </summary>
/// <author>Nicholas Gliserman & Megan Lisette Peck</author>
//TODO: IMPROVED Functionality by shuffling the events in a queue structure. - Do we still want this??
public class EventInfo2
{
    public DailyEventType2 dailyEventType;
    public float scheduledTime;
    public EventInfo2(DailyEventType2 eventType, float time)
    {
        dailyEventType = eventType;
        scheduledTime = time;
    }
}

/// < summary >
/// Creates a revolvingQueue of type EventInfo called "daysEvents"
/// which holds each event and the time it should happen each day.
/// </summary>
/// <author>Nicholas Gliserman & Megan Lisette Peck</author>
public class DailyEventsQueue //: MonoBehaviour
{
    public float dayLengthSeconds = 5.0f;
    public float intervalTime = 0.1f;
    public bool lastEventHappened;
    public static int count = Enum.GetValues(typeof(DailyEventType2)).Length - 1;    //Minus 1, as to not include "NONE" in the Daily Event count
    private static RevolvingQueue<EventInfo2> daysEvents = new RevolvingQueue<EventInfo2>(count);

    public DailyEventsQueue()
    {
        daysEvents.Enqueue(new EventInfo2(DailyEventType2.NEWDAY, (this.intervalTime * (int)DailyEventType2.NEWDAY)));
        daysEvents.Enqueue(new EventInfo2(DailyEventType2.WEATHER, (this.intervalTime * (int)DailyEventType2.WEATHER)));
        daysEvents.Enqueue(new EventInfo2(DailyEventType2.WEEDFEEDING, (this.intervalTime * (int)DailyEventType2.WEEDFEEDING)));
        daysEvents.Enqueue(new EventInfo2(DailyEventType2.FLOWERFEEDING, (this.intervalTime * (int)DailyEventType2.FLOWERFEEDING)));
        daysEvents.Enqueue(new EventInfo2(DailyEventType2.WEEDPOLLINATION, (this.intervalTime * (int)DailyEventType2.WEEDPOLLINATION)));
        daysEvents.Enqueue(new EventInfo2(DailyEventType2.FLOWERPOLLINATION, (this.intervalTime * (int)DailyEventType2.FLOWERPOLLINATION)));
        daysEvents.Enqueue(new EventInfo2(DailyEventType2.WEEDSEEDING, (this.intervalTime * (int)DailyEventType2.WEEDSEEDING)));
        daysEvents.Enqueue(new EventInfo2(DailyEventType2.FLOWERSEEDING, (this.intervalTime * (int)DailyEventType2.FLOWERSEEDING)));
        daysEvents.Enqueue(new EventInfo2(DailyEventType2.WEEDGROW, (this.intervalTime * (int)DailyEventType2.WEEDGROW)));
        daysEvents.Enqueue(new EventInfo2(DailyEventType2.FLOWERGROW, (this.intervalTime * (int)DailyEventType2.FLOWERGROW)));
        daysEvents.Enqueue(new EventInfo2(DailyEventType2.COLORCLASH, (this.intervalTime * (int)DailyEventType2.COLORCLASH))); //TODO
        daysEvents.Enqueue(new EventInfo2(DailyEventType2.DYING, (this.intervalTime * (int)DailyEventType2.DYING))); //TODO
        daysEvents.Enqueue(new EventInfo2(DailyEventType2.ENDDAY, this.dayLengthSeconds));
    }

    /// <summary>
    /// Given the time of the day, will return what event should happen (if any)
    /// </summary>
    /// <param name = "timeOfDay" ></ param >
    /// < returns > What even should happen(if any)</returns>
    /// <author>Nicholas Gliserman & Megan Lisette Peck</author>
    public DailyEventType2 GetCurrentEvent(float timeOfDay)
    {
        // GET NEXT EVENT IN THE REVOLVING QUEUE
        EventInfo2 nextEvent = daysEvents.Peek();

        // IF THE TIME IS AT or AFTER the EVENT's SCHEDULE TIME
        if (timeOfDay > nextEvent.scheduledTime)
        {
            // MOVE EVENT TO END OF THE QUEUE, AND RETURN IT AS THE CURRENT EVENT
            daysEvents.MoveItemToTail();
            return nextEvent.dailyEventType;
        }
        // ELSE - NO EVENT HAPPENED
        return DailyEventType2.NONE;
    }
}


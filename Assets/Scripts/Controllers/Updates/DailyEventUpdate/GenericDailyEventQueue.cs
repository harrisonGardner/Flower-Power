//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

///// <summary>
///// List of events occuring within a day
///// </summary>
//public enum DailyEventType
//{
//    NONE, NEWDAY, WEATHER,
//    WEEDFEEDING, FLOWERFEEDING,
//    WEEDPOLLINATION, FLOWERPOLLINATION,
//    WEEDSEEDING, FLOWERSEEDING,
//    WEEDGROW, FLOWERGROW,
//    COLORCLASH, DYING, ENDDAY
//}

//// TODO: Make into a generic structure
//// IMPROVED Functionality by shuffling the events in a queue structure.
//public class EventInfo
//{
//    public DailyEventType dailyEventType;
//    public float scheduledTime;

//    public EventInfo(DailyEventType eventType, float time)
//    {
//        dailyEventType = eventType;
//        scheduledTime = time;
//    }
//}

///// <summary>
///// Dictates when events should occur within a given day.
///// </summary>
///// <author>Nicholas Gliserman</author>
//public class GenericDailyEventQueue //: MonoBehaviour
//{
//    public float dayLengthSeconds = 5.0f;
//    public float intervalTime = 0.1f;
//    public bool lastEventHappened;
//    public static int count = Enum.GetValues(typeof(DailyEventType)).Length - 1;    //Minus 1, as to not include "NONE" in the Daily Event count
//    private static RevolvingQueue<EventInfo> daysEvents = new RevolvingQueue<EventInfo>(count);

//    public GenericDailyEventQueue()
//    {
//        daysEvents.Enqueue(new EventInfo(DailyEventType.NEWDAY, (this.intervalTime * (int)DailyEventType.NEWDAY)));
//        daysEvents.Enqueue(new EventInfo(DailyEventType.WEATHER, (this.intervalTime * (int)DailyEventType.WEATHER)));
//        daysEvents.Enqueue(new EventInfo(DailyEventType.WEEDFEEDING, (this.intervalTime * (int)DailyEventType.WEEDFEEDING)));
//        daysEvents.Enqueue(new EventInfo(DailyEventType.FLOWERFEEDING, (this.intervalTime * (int)DailyEventType.FLOWERFEEDING)));
//        daysEvents.Enqueue(new EventInfo(DailyEventType.WEEDPOLLINATION, (this.intervalTime * (int)DailyEventType.WEEDPOLLINATION)));
//        daysEvents.Enqueue(new EventInfo(DailyEventType.FLOWERPOLLINATION, (this.intervalTime * (int)DailyEventType.FLOWERPOLLINATION)));
//        daysEvents.Enqueue(new EventInfo(DailyEventType.WEEDSEEDING, (this.intervalTime * (int)DailyEventType.WEEDSEEDING)));
//        daysEvents.Enqueue(new EventInfo(DailyEventType.FLOWERSEEDING, (this.intervalTime * (int)DailyEventType.FLOWERSEEDING)));
//        daysEvents.Enqueue(new EventInfo(DailyEventType.WEEDGROW, (this.intervalTime * (int)DailyEventType.WEEDGROW)));
//        daysEvents.Enqueue(new EventInfo(DailyEventType.FLOWERGROW, (this.intervalTime * (int)DailyEventType.FLOWERGROW)));
//        daysEvents.Enqueue(new EventInfo(DailyEventType.COLORCLASH, (this.intervalTime * (int)DailyEventType.COLORCLASH))); //TODO
//        daysEvents.Enqueue(new EventInfo(DailyEventType.DYING, (this.intervalTime * (int)DailyEventType.DYING))); //TODO
//        daysEvents.Enqueue(new EventInfo(DailyEventType.ENDDAY, this.dayLengthSeconds));
//    }

//    /// <summary>
//    /// Given the time of the day, will return what event should happen (if any)
//    /// </summary>
//    /// <param name="timeOfDay"></param>
//    /// <returns></returns>
//    public DailyEventType GetCurrentEvent(float timeOfDay)
//    {
//        // GET NEXT EVENT IN THE QUEUE
//        EventInfo nextEvent = daysEvents.Peek();

//        // IF THE TIME IS AT or AFTER the EVENT's SCHEDULE TIME
//        if (timeOfDay > nextEvent.scheduledTime)
//        {
//            // DEQUEUE THE EVENT, AND RETURN THE EVENT TYPE
//            daysEvents.MoveItemToTail();
//            return nextEvent.dailyEventType;
//        }

//        // ELSE - NO EVENT HAPPENED
//        return DailyEventType.NONE;
//    }
//}


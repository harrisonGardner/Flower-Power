using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Start day
/// </summary>
public class StartDay : MonoBehaviour, IGardenUpdate
{
    public void ActionOnUpdate(Garden garden)
    {
        Order order = GameObject.Find("OrderInfo").GetComponent<Order>();
        int deadline = order.maxNumDays;
        string deadeline = $"Day: {MasterController.DayNumber}     Deadline: {deadline}";
        GameObject.Find("DayCounter").GetComponent<Text>().text = deadeline;

        // HOUSEKEEPING
        garden.WindyToday = false;
        garden.RemovePollen();
    }
}

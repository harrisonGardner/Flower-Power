using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayCounter : MonoBehaviour
{
    public GameObject orderObject;
    private void FixedUpdate()
    {
        gameObject.GetComponent<Text>().text = $"Day: {MasterController.DayNumber}     deadline: {orderObject.GetComponent<Order>().maxNumDays}";
    }
}

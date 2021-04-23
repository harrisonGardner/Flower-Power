using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderNumberUI : MonoBehaviour
{
    public ColorName color;

    public void UpdateOrderNumberText(string numbers)
    {
        gameObject.GetComponent<Text>().text = numbers;
    }
}

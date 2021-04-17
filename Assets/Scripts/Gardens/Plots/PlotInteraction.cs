using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The game object portion of the plot script.
/// </summary>
/// <author> Harrison Gardner </author>>
public class PlotInteraction : MonoBehaviour
{
    public bool hasBeenClicked = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        hasBeenClicked = true;
    }
}

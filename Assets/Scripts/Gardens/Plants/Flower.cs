using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Xml.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Flower : Plant
{
    //public Flower(Plot plot, Color flowerColor, FlowerHealth health) : base(PlantType.Flower, health, plot, flowerColor)
    //{
        
    //}

    private void Start()
    {
        
    }
    public void SpriteUpdate()
    {
        //gameObject.GetComponent<SpriteRenderer>().sprite = SpriteFetcher.GetSprite(this.PlantColor.Name, this.CurrentStage.CurrentStage);
    }
}

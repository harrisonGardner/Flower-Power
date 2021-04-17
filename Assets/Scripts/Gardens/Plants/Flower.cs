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
        //try
        //{
        //    gameObject.GetComponent<SpriteRenderer>().sprite = SpriteFetcher.GetSprite(this.PlantColor.Name, this.CurrentStage.CurrentStage);
        //}
        //catch (Exception e)
        //{
        //    Debug.Log(e.StackTrace);
        //}
    }

    int delay = 1500;
    public void SpriteUpdate()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = SpriteFetcher.GetSprite(this.PlantColor.Name, this.CurrentStage.CurrentStage);
        if (delay > 0)
            delay--;
        else
        {
            this.CurrentStage = this.CurrentStage.GetNextStage();
            delay = 150;
        }
        if (this.CurrentStage.CurrentStage == StageType.DEAD)
            Destroy(plantPrefab);
    }
}

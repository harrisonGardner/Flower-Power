using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Flower : Plant
{
    public GameObject flowerObject;
    public Flower(Plot plot, Color flowerColor, IPlantHealth health) : base(PlantType.Flower, health, plot, flowerColor)
    {
        flowerObject = Instantiate(Resources.Load("Prefabs/FlowerPrefab") as GameObject, new Vector3(plot.plotObject.transform.position.x, plot.plotObject.transform.position.y, -1), new Quaternion());
    }

    private int delay = 150;
    public void SpriteUpdate()
    { 
        flowerObject.GetComponent<SpriteRenderer>().sprite = SpriteFetcher.GetSprite(this.PlantColor.Name, this.CurrentStage.CurrentStage);
        if (delay > 0)
            delay--;
        else
        {
            this.CurrentStage = this.CurrentStage.GetNextStage();
            Debug.Log(this.CurrentStage);
            Debug.Log(this.CurrentStage.CurrentStage);
            delay = 150;
        }
        if (this.CurrentStage.CurrentStage == StageType.DEAD)
            Destroy(flowerObject);
    }
}

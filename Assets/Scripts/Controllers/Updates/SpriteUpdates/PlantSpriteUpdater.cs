using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSpriteUpdater : MonoBehaviour, ISpriteUpdate
{
    public void SpriteUpdate()
    {
        if (gameObject != null)
        {
            if (gameObject.GetComponent<Flower>() != null)
            {
                Color plantColor = gameObject.GetComponent<Flower>().PlantColor;
                if (plantColor.Name != ColorName.NONE)
                {
                    StageType currentStage = gameObject.GetComponent<Flower>().CurrentStage.CurrentStage;
                    gameObject.GetComponent<SpriteRenderer>().sprite = SpriteFetcher.GetSpriteFlower(plantColor.Name, currentStage);
                }
            }
        }
    }
}

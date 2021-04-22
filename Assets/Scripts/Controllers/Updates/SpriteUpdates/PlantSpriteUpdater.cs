using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSpriteUpdater : MonoBehaviour, ISpriteUpdate
{
    public void SpriteUpdate()
    {
        if (gameObject != null)
        {
            if (gameObject.GetComponent<Plant>() != null)
            {
                Color plantColor = gameObject.GetComponent<Plant>().PlantColor;
                StageType currentStage = gameObject.GetComponent<Plant>().CurrentStage.CurrentStage;
                if (plantColor.Name != ColorName.NONE)
                    gameObject.GetComponent<SpriteRenderer>().sprite = SpriteFetcher.GetSpriteFlower(plantColor.Name, currentStage);
                else
                    gameObject.GetComponent<SpriteRenderer>().sprite = SpriteFetcher.GetSpriteWeed(currentStage);
            }
        }
    }
}

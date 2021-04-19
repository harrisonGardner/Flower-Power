using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSpriteUpdater : MonoBehaviour, ISpriteUpdate
{
    public void SpriteUpdate()
    {
        Color plantColor = gameObject.GetComponent<Flower>().PlantColor;
        StageType currentStage = gameObject.GetComponent<Flower>().CurrentStage.CurrentStage;
        Debug.Log($"Stage: {currentStage}, Color: {plantColor}");
        gameObject.GetComponent<SpriteRenderer>().sprite = SpriteFetcher.GetSpriteFlower(plantColor.Name, currentStage);
    }
}

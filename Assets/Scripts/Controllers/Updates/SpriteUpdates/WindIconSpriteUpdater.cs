using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindIconSpriteUpdater : MonoBehaviour, ISpriteUpdate
{
    public Text windText;

    public void SpriteUpdate()
    {
        //Arrow icon stuff
        gameObject.GetComponent<SpriteRenderer>().sprite = SpriteFetcher.GetSpriteWind(gameObject.GetComponent<WindIcon>().Direction);
        
        //Wind text stuff
        string directionText = "";
        switch (gameObject.GetComponent<WindIcon>().Direction)
        {
            case (DirectionName.up):
                directionText = "N";
                break;
            case (DirectionName.upRight):
                directionText = "NE";
                break;
            case (DirectionName.right):
                directionText = "E";
                break;
            case (DirectionName.downRight):
                directionText = "SE";
                break;
            case (DirectionName.down):
                directionText = "S";
                break;
            case (DirectionName.downLeft):
                directionText = "SW";
                break;
            case (DirectionName.left):
                directionText = "W";
                break;
            case (DirectionName.upLeft):
                directionText = "NW";
                break;
        }
        windText.text = directionText;
    }
}

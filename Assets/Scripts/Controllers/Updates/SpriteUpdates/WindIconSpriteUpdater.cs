using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindIconSpriteUpdater : MonoBehaviour, ISpriteUpdate
{
    public void Start()
    {
        gameObject.GetComponent<WindIcon>().spriteUpdate = this;
    }

    public void SpriteUpdate()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = SpriteFetcher.GetSpriteWind(gameObject.GetComponent<WindIcon>().Direction);
    }
}

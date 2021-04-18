using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotSpriteUpdater : MonoBehaviour, ISpriteUpdate
{
    public void SpriteUpdate()
    {
        if (gameObject.GetComponent<Plot>().waterLevel <= 0)
            gameObject.GetComponent<SpriteRenderer>().sprite = SpriteFetcher.GetSpritePlot(0);
        else if (gameObject.GetComponent<Plot>().waterLevel <= 4)
            gameObject.GetComponent<SpriteRenderer>().sprite = SpriteFetcher.GetSpritePlot(1);
        else if (gameObject.GetComponent<Plot>().waterLevel <= 8)
            gameObject.GetComponent<SpriteRenderer>().sprite = SpriteFetcher.GetSpritePlot(2);
        else if (gameObject.GetComponent<Plot>().waterLevel <= 12)
            gameObject.GetComponent<SpriteRenderer>().sprite = SpriteFetcher.GetSpritePlot(3);
    }
}

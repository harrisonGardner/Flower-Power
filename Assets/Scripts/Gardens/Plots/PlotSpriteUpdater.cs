using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotSpriteUpdater : MonoBehaviour, ISpriteUpdate
{
    public ParticleSystem pollenParticlesPrefab;
    private ParticleSystem pollenParticles;

    private void Start()
    {
        pollenParticles = Instantiate(pollenParticlesPrefab, gameObject.transform);
        pollenParticles.transform.parent = gameObject.transform;
        var main = pollenParticles.main;
        main.startColor = new UnityEngine.Color(1, 1, 1, 1);
        var colGrad = pollenParticles.colorOverLifetime;
        Gradient grad = new Gradient();
        grad.SetKeys(new GradientColorKey[] { new GradientColorKey((UnityEngine.Color.blue + UnityEngine.Color.red) / 2, 0.0f),
            new GradientColorKey((UnityEngine.Color.blue + UnityEngine.Color.red) / 2, 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(0.0f, 0.0f),
                new GradientAlphaKey(1.0f, 0.5f), new GradientAlphaKey(0.0f, 1.0f) });
        colGrad.color = grad;
    }

    private void Update()
    {
        
    }

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

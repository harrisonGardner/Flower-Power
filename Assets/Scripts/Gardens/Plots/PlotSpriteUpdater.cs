using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotSpriteUpdater : MonoBehaviour, ISpriteUpdate
{
    public ParticleSystem pollenParticlesPrefab;
    private ParticleSystem[] pollenParticles = new ParticleSystem[6];
    private ColorName[] pollenColors = new ColorName[6] { ColorName.BLUE, ColorName.YELLOW, ColorName.RED, ColorName.GREEN, ColorName.PURPLE, ColorName.ORANGE };

    private void Start()
    {
        pollenParticles[0] = Instantiate(pollenParticlesPrefab, gameObject.transform);
        pollenParticles[1] = Instantiate(pollenParticlesPrefab, gameObject.transform);
        pollenParticles[2] = Instantiate(pollenParticlesPrefab, gameObject.transform);
        pollenParticles[3] = Instantiate(pollenParticlesPrefab, gameObject.transform);
        pollenParticles[4] = Instantiate(pollenParticlesPrefab, gameObject.transform);
        pollenParticles[5] = Instantiate(pollenParticlesPrefab, gameObject.transform);

        for (int i = 0; i < pollenParticles.Length; i++)
        {
            pollenParticles[i].transform.parent = gameObject.transform;
            var colGrad = pollenParticles[i].colorOverLifetime;
            Gradient grad = new Gradient();
            grad.SetKeys(new GradientColorKey[] { new GradientColorKey(colorNameToEngineColor(pollenColors[i]), 0.0f),
            new GradientColorKey(colorNameToEngineColor(pollenColors[i]), 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(0.0f, 0.0f),
                new GradientAlphaKey(1.0f, 0.5f), new GradientAlphaKey(0.0f, 1.0f) });
            colGrad.color = grad;
        }
    }

    private UnityEngine.Color colorNameToEngineColor(ColorName c)
    {
        UnityEngine.Color engineColor;
        engineColor = UnityEngine.Color.clear;
        switch (c)
        {
            case (ColorName.RED):
                engineColor = UnityEngine.Color.red;
                break;
            case (ColorName.BLUE):
                engineColor = UnityEngine.Color.blue;
                break;
            case (ColorName.YELLOW):
                engineColor = UnityEngine.Color.yellow;
                break;
            case (ColorName.PURPLE):
                engineColor = (UnityEngine.Color.red + UnityEngine.Color.blue) / 2;
                break;
            case (ColorName.ORANGE):
                engineColor = (UnityEngine.Color.red + UnityEngine.Color.yellow) / 2;
                break;
            case (ColorName.GREEN):
                engineColor = UnityEngine.Color.green;
                break;
        }
        return engineColor;
    }

    private void Update()
    {
        for (int i = 0; i < pollenParticles.Length; i++)
        {
            if (gameObject.GetComponent<Plot>().PollenHere.Count(pollenColors[i]) > 0)
                pollenParticles[i].enableEmission = true;
            else
                pollenParticles[i].enableEmission = false;

            pollenParticles[i].emissionRate = gameObject.GetComponent<Plot>().PollenHere.Count(pollenColors[i]) * gameObject.GetComponent<Plot>().PollenHere.Count(pollenColors[i]) * 2;
        }
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

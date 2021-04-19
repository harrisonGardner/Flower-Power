using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents the vigorous way that a weed tries to spread and
/// inhibit the reproduction of nearby flowers.
/// </summary>
/// <author>Nicholas Gliserman</author>
public class WeedReproduction : IReproductionBehavior
{
    System.Random randNumber = new System.Random();

    public void SpreadPollen(Plot plot, Direction direction, bool windyDay)
    {
        // TODO: TWEAK INPUTS AS FITS GAMEPLAY
        int distance = 3;
        int pollenIntensity = 2;

        if (windyDay)
        {
            distance++;
            pollenIntensity++;
        }

        // STRONG STREAM of POLLEN
        Pollen strong = new Pollen(direction, distance, pollenIntensity, ColorName.NONE); 
        strong.currentPlot = plot.AdjacentPlots.getNeighbor(direction.Name);
        strong.Spread();

        // TWO WEAKER STREAMS
        Pollen weak1 = new Pollen(direction, (distance - 1), (pollenIntensity -1), ColorName.NONE);
        Pollen weak2 = new Pollen(direction, (distance - 1), (pollenIntensity - 1), ColorName.NONE);

        DirectionName[] weakStarts = Directions.GetAdjacentDirections(direction.Name);
        weak1.currentPlot = plot.AdjacentPlots.getNeighbor(weakStarts[0]);
        weak2.currentPlot = plot.AdjacentPlots.getNeighbor(weakStarts[1]);

        weak1.Spread();
        weak2.Spread();
    }

    public void Seed(Plot plot)
    {
       
        // GET POLLEN in this SPACE
        int weedPollen = plot.PollenHere.Count(ColorName.NONE);

        int seeds = 0;

        // HOW MANY SEEDS to MAKE?
        // TODO: TWEAK NUMBERS to FIT GAMEPLAY
        if (weedPollen >= 3) // LARGE AMOUNT OF POLLEN, PROPORTIONAL NUM of SEEDS
        {
            seeds = (int)Math.Floor((double)weedPollen / 3);
        }
        else if (weedPollen == 0) // NO POLLEN, NO SEEDS
        {
            seeds = 0;
        }
        else // LOW POLLEN, MAYBE 1 SEED
        {
            int rand = randNumber.Next(0, weedPollen + 1);
            if (rand > 0)
            {
                seeds = 1;
            }
        }

        // SPREAD the SEEDS
        for (int i = 0; i < seeds; i++)
        {
            Plot adjPlot = plot.AdjacentPlots.getRandomNeighbor();
            if (adjPlot.plantHere == null)
            {
                // TODO: Revisit this later
                //adjPlot.addPlant(new Weed(adjPlot));
                adjPlot.addPlant(PlantType.Weed, ColorName.NONE);
            }
        }
    }
}

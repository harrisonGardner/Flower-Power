using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interface that facilitates how flowers reproduce
/// </summary>
public class FlowerReproduction : IReproductionBehavior
{
    System.Random randNumber = new System.Random();

    /// <summary>
    /// Scatters pollen to neighboring spaces based on wind direction.
    /// </summary>
    /// <param name="plot"></param>
    /// <param name="direction"></param>
    public void SpreadPollen(Plot plot, Direction direction, bool windyDay)
    {
        // TODO: TWEAK INPUTS AS FITS GAMEPLAY
        int distance = 2;
        int pollenIntensity = 2;
        ColorName color = plot.plantHere.PlantColor.Name;

        if (windyDay)
        {
            distance++;
            pollenIntensity++;
        }

        // STRONG STREAM of POLLEN
        Pollen strong = new Pollen(direction, distance, pollenIntensity, color);
        Debug.Log("In flower reproduction trying to head: " + direction.Name);
        try
        {
            strong.currentPlot = plot.AdjacentPlots.getNeighbor(direction.Name);
            strong.Spread();
        }
        catch (IndexOutOfRangeException) { }
        

        // TWO WEAKER STREAMS
        Pollen weak1 = new Pollen(direction, distance, (pollenIntensity - 1), color);
        Pollen weak2 = new Pollen(direction, distance, (pollenIntensity - 1), color);

        DirectionName[] weakStarts = Directions.GetAdjacentDirections(direction.Name);

        try
        {
            weak1.currentPlot = plot.AdjacentPlots.getNeighbor(weakStarts[0]);
            weak1.Spread();
        }
        catch (IndexOutOfRangeException) { }

        try
        {
            weak2.currentPlot = plot.AdjacentPlots.getNeighbor(weakStarts[1]);
            weak2.Spread();
        }
        catch (IndexOutOfRangeException) { };


    }

    /// <summary>
    /// The flower collects the pollen in the plot and uses it
    /// to make and spread seeds in neighboring spaces.
    /// </summary>
    /// <param name="plot"></param>
    public void Seed(Plot plot)
    {
        // MAKE SEEDS
        // This Plant's Color
        Color thisPlantsColor = plot.plantHere.PlantColor;

        // Pollen Colors
        TalliedSet<ColorName> flowerPollen = plot.PollenHere;

        int pollenCount = flowerPollen.Num;
        TalliedSet<ColorName> seeds = new TalliedSet<ColorName>();

        // TODO: TWEAK NUMBERS to FIT GAMEPLAY
        // ITERATE through POLLEN in SPACE
        for (int i = 0; i < pollenCount; i++)
        {
            // 1 in 2 chance flower will receive the pollen
            if (0 == randNumber.Next(0, 2))
            {
                ColorName pollenColor = flowerPollen.RemoveRandomElement();
                
            // ENSURE POLLEN did not BELONG to a WEED
            if (pollenColor != ColorName.NONE)
                {
                    ColorName PollenFlowerBlend = Colors.GetColorBlend(thisPlantsColor,
                        Colors.GetColor(pollenColor));
                    seeds.Add(PollenFlowerBlend);
                }
            }
            else // DISCARD the POLLEN
            {
                seeds.RemoveRandomElement();
            }
        }

        // SPREAD SEEDS
        int seedCount = seeds.Num;

        for (int i = 0; i < seedCount; i++)
        {
            // CHOOSE a RANDOM NEIGHBOR
            Plot adjPlot = plot.AdjacentPlots.getRandomNeighbor();
            // GROW a NEW PLANT if it does not have one already
            if (adjPlot.plantHere == null)
            {
                // GET the SEED COLOR
                ColorName flowerColor = seeds.RemoveRandomElement();
                // TODO: Revist this commenting out
                //adjPlot.addPlant(new Flower(adjPlot,
                //    Colors.GetColor(flowerColor), new FlowerHealth(1, 1, 10, 10)));

                adjPlot.AddPlant(PlantType.Flower, flowerColor);
            }
            else
            {
                seeds.RemoveRandomElement();
            }
        }


    }
}

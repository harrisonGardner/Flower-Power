using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Dictates how and where the weed will eat and drink.
/// </summary>
/// <author>Nicholas Gliserman</author>
public class WeedFeedingBehavior : IFeedingBehavior
{
    int FeedingIntensity { get; }
    int ThirstIntensity { get; }

    /// <summary>
    /// Constructs a new WeedFeedingBehavior object, allowing for
    /// the hunger and thirst parameters to dictate how much it will consume.
    ///
    /// These parameters will vary based on the weed's stage.
    /// </summary>
    /// <param name="sunHunger"></param>
    /// <param name="waterThirst"></param>
    public WeedFeedingBehavior(int sunHunger, int waterThirst)
    {
        FeedingIntensity = sunHunger;
        ThirstIntensity = waterThirst;
    }

    /// <summary>
    /// The weed first consumes energy from its own plot and then
    /// sneaks some more (at a lower intensity) from its neighbors.
    /// </summary>
    /// <param name="plot"></param>
    /// <returns></returns>
    public int CollectSunEnergy(Plot plot)
    {
        plot.removeSunEnergy(FeedingIntensity);

        Plot[] adjacent = plot.AdjacentPlots.getNeighbors();

        for (int i = 0; i < adjacent.Length; i++)
        {
            if (adjacent[i] != null) // CHECK PLOT is in GARDEN
                plot.removeSunEnergy(FeedingIntensity - 1);
        }

        return 0; // n.b. the Health Interface does not need this for weeds
    }

    /// <summary>
    /// The weed first drinks water from its own plot and then
    /// sneaks some more (at a lower intensity) from its neighbors.
    /// </summary>
    /// <param name="plot"></param>
    /// <returns></returns>
    public int CollectWater(Plot plot)
    {
        plot.removeWater(ThirstIntensity);

        // PROBLEM IS HERE
        Plot[] adjacent = plot.AdjacentPlots.getNeighbors();

        for (int i = 0; i < adjacent.Length; i++)
        {
            if (adjacent[i] != null) // CHECK PLOT is in GARDEN
            {
                adjacent[i].removeWater(ThirstIntensity - 1);
                SpriteUpdateController.AddSpriteToRedraw(plot.gameObject.GetComponent<PlantSpriteUpdater>());
            }
        }
        return 0; // n.b. the Health Interface does not need this for weeds
    }
}

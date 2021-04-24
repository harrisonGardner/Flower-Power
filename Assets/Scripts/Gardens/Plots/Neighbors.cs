using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neighbors
{
    public Neighbor[] neighborsInclSelf;
    public Plot[] neighbors;

    /// <summary>
    /// Constructs a Neighbors object
    /// </summary>
    /// <param name="self"></param>
    /// <param name="up"></param>
    /// <param name="upRight"></param>
    /// <param name="right"></param>
    /// <param name="downRight"></param>
    /// <param name="down"></param>
    /// <param name="downLeft"></param>
    /// <param name="left"></param>
    /// <param name="upLeft"></param>
    public Neighbors(Neighbor self, Neighbor up,
        Neighbor upRight, Neighbor right, Neighbor downRight,
        Neighbor down, Neighbor downLeft, Neighbor left, Neighbor upLeft)
    {
        // FOLLOW the ORDER of the DirectionName ENUM for Easy Array Accesses
        this.neighborsInclSelf = new Neighbor[]
        {
            self, up, upRight, right, downRight,
            down, downLeft, left, upLeft
        };
        this.neighbors = new Plot[8];

        for (int i = 0; i < neighbors.Length; i++)
        {
            if (neighborsInclSelf[i + 1].TargetIsOutOfBounds)
            {
                this.neighbors[i] = null;
            }
            else
            {
                neighbors[i] = neighborsInclSelf[i + 1].Target;
            }
        }
    }

    /// <summary>
    /// Alternative constructor, in which the neighbors can be passed
    /// in with an array rather than listed individually
    /// </summary>
    /// <param name="self"></param>
    /// <param name="surroundingNeighbors"></param>
    public Neighbors(Neighbor[] surroundingNeighbors)
    {
        if (surroundingNeighbors.Length == 9)
        {
            this.neighborsInclSelf = surroundingNeighbors;
        }

        this.neighbors = new Plot[8];

        for (int i = 0; i < neighbors.Length; i++)
        {
            if (neighborsInclSelf[i + 1].TargetIsOutOfBounds)
            {
                this.neighbors[i] = null;
            }
            else
            {
                neighbors[i] = neighborsInclSelf[i + 1].Target;
            }
        }
    }

    public Plot getNeighbor(DirectionName direction)
    {
        if (neighborsInclSelf[(int)direction].TargetIsOutOfBounds)
            throw new IndexOutOfRangeException("Requested Plot is Outside the Garden");

        return neighborsInclSelf[(int)direction].Target;
    }


    public Plot getRandomNeighbor()
    {
        Plot randomNeighbor = null;

        while (randomNeighbor == null)
        {
            try
            {
                randomNeighbor = getNeighbor(Directions.GetRandomDirection().Name);
            }
            catch (IndexOutOfRangeException) { }
        }

        return randomNeighbor;
    }

    public Plot getRandomNeighborWithPlant()
    {
        Plot randomNeighborWPlant = null;
        IList<Plot> plotsWPlants = new List<Plot>();

        foreach (Plot p in neighbors)
        {
            if (p != null && p.plantHere != null)
            {
                plotsWPlants.Add(p);
            }
        }

        int rand = MasterController.universallyAvailableRandom.Next(0, plotsWPlants.Count);

        int i = 0;
        foreach (Plot withPlant in plotsWPlants)
        {
            if (i == rand)
            {
                randomNeighborWPlant = withPlant;
            }
            i++;
        }

        return randomNeighborWPlant;
    }

    public Plot[] getNeighbors() { return this.neighbors; }

}

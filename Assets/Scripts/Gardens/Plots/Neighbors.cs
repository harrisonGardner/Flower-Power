using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neighbors
{
    public Neighbor[] neighbors;

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
        this.neighbors = new Neighbor[] {
            self, up, upRight, right, downRight,
            down, downLeft, left, upLeft
        };
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
            this.neighbors = surroundingNeighbors;
        }
    }

    public Plot getNeighbor(DirectionName direction)
    {
        if (neighbors[(int)direction].TargetIsOutOfBounds)
            throw new IndexOutOfRangeException("Requested Plot is Outside the Garden");

        return neighbors[(int)direction].Target;
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

    // TODO: Method for a pest to go into a new space with a plant & if none available, die.
    // TODO: Method to check if the flower in this space is adjacent to a flower of the opposite color

}

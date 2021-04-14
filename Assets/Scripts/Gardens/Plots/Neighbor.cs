using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Space adjacent to the the origin space in a specified direction.
/// </summary>
/// <author>Nicholas Gliserman</author>
public class Neighbor
{
    public Plot Target { get; }
    public Direction Direction { get; }
    public bool TargetIsOutOfBounds { get; set; }

    /// <summary>
    /// Constructs the neighbor object
    /// </summary>
    /// <param name="space">The neighboring target space</param>
    /// <param name="direction">
    /// the direction to reach the target space from the origin
    /// </param>
    public Neighbor(Direction direction, Plot space)
    {
        this.Target = space;
        this.Direction = direction;
        this.TargetIsOutOfBounds = false;
    }

    public Neighbor(Direction direction)
    {
        this.Direction = direction;
        this.TargetIsOutOfBounds = true;
    }

}


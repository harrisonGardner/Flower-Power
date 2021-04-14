using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

/// <summary>
/// Represents the possible movement pathways in this game.
///
/// Goes in clockwise direction from the up position.
/// </summary>
/// <author>Nicholas Gliserman</author>
public enum DirectionName
{ none, up, upRight, right, downRight, down, downLeft, left, upLeft }

/// <summary>
/// Vector to move from one space to a neighbor, either
/// horizontally, vertically, or diagonally.
/// </summary>
/// <author>Nicholas Gliserman</author>
public struct Direction
{
    public int X { get; }
    public int Y { get; }
    public DirectionName Name { get; }

    public Direction(int x, int y, DirectionName name)
    {
        this.X = x;
        this.Y = y;
        this.Name = name;
    }
}

/// <summary>
/// Holds all the possible directions with
/// their corresponding name, x & y values.
/// </summary>
/// <author>Nicholas Gliserman</author>
public class Directions
{
    public static Random rand = new Random();

    private static Direction[] directions = new Direction[] {
                new Direction(0, 0, DirectionName.none),
                new Direction(0, -1, DirectionName.up),
                new Direction(1, -1, DirectionName.upRight),
                new Direction(1, 0, DirectionName.right),
                new Direction(1, 1, DirectionName.downRight),
                new Direction(0, 1, DirectionName.down),
                new Direction( -1, 1, DirectionName.downLeft),
                new Direction(-1, 0, DirectionName.left),
                new Direction(-1, -1, DirectionName.upLeft)
            };

    /// <summary>
    /// Returns the Direction object (with x & y values) for the given
    /// name of that direction.
    /// </summary>
    /// <param name="name">Enum with desired direction name</param>
    /// <returns></returns>
    public static Direction GetDirection(DirectionName name)
    {
        return directions[(int)name];
    }

    public static Direction GetDirection(int directionPosition)
    {
        return directions[directionPosition];
    }

    public static Direction GetRandomDirection()
    {
        return directions[rand.Next(1, 9)];
    }


}

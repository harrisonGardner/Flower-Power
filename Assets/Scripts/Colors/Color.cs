using System;
using System.Collections.Generic;

/// <summary>
/// Types of colors that a plant object can be.
/// </summary>
/// <author>Lisette Peck & Nicholas Gliserman</author>
public enum ColorType { NONE, PRIMARY, SECONDARY } // (TODO: IMPLEMENT TERTIARY) , TERTIARY }

/// <summary>
/// Names of the colors that a plant object can be.
/// <author>Lisette Peck & Nicholas Gliserman</author>
public enum ColorName
{
    NONE, RED, BLUE, YELLOW, GREEN, ORANGE, PURPLE // (TODO: IMPLEMENT TERTIARY) MAGENTA, VIOLET, TEAL, CHARTREUSE, AMBER, VERMILLION
}

/// <summary>
/// Color object contains the values a plant object needs to determine it's color.
/// Also contains the color that the plant object would not work well next to.
/// <author>Lisette Peck & Nicholas Gliserman</author>
public class Color 
{
    public string HexValueRGB { get; }
    public Color OppositeColor { get; set; }
    public ColorType Type { get; }
    public ColorName Name { get; }
    public IDictionary<ColorName, Color> Blends { get; } = new Dictionary<ColorName, Color>();

    /// <summary>
    /// Creates a new color object with its name, type, and a string
    /// with a hex value that can be applied for graphic purposes.
    /// </summary>
    /// <param name="colorName"></param>
    /// <param name="colorType"></param>
    /// <param name="rgbHexVal"></param>
    public Color(ColorName colorName, ColorType colorType, string rgbHexVal)
    {
        Name = colorName;
        Type = colorType;
        HexValueRGB = rgbHexVal;
    }

    /// <summary>
    /// Returns true if the object has a color, otherwise false.
    ///
    /// Useful for objects such as weeds that will have a color field
    /// as a result of inheritance but is largely just a placeholder. 
    /// </summary>
    /// <returns></returns>
    public bool HasColor()
    {
        if (Type == ColorType.NONE || Name == ColorName.NONE)
            return false;

        return true;
    }

    /// <summary>
    /// Sets this color's opposite color and then reaches
    /// into that color to set this current color as its opposite.
    /// The end result is that opposite colors will be paired.
    /// </summary>
    /// <param name="opposite"></param>
    public void setOpposite(Color opposite)
    {
        OppositeColor = opposite;
        OppositeColor.OppositeColor = this;
    }
}

/// <summary>
/// Provides access to all colors represented in the game.
/// </summary>
/// <author>Lisette Peck & Nicholas Gliserman</author
public class Colors
{
    private static Color[] allColors = new Color[] {
        new Color(ColorName.NONE, ColorType.NONE, ""), // NONE
        new Color(ColorName.RED, ColorType.PRIMARY, ""),
        new Color(ColorName.BLUE, ColorType.PRIMARY, ""),
        new Color(ColorName.YELLOW, ColorType.PRIMARY, ""),
        new Color(ColorName.GREEN, ColorType.SECONDARY, ""),
        new Color(ColorName.ORANGE, ColorType.SECONDARY, ""),
        new Color(ColorName.PURPLE, ColorType.SECONDARY, ""),
    };

    /// <summary>
    /// Constructor sets the opposite colors and therefore must be
    /// invoked before the game begins.
    /// </summary>
    public Colors()
    {
        // RED & GREEN are OPPOSITES
        GetColor(ColorName.GREEN).setOpposite(GetColor(ColorName.RED));
        // ORANGE & BLUE are OPPOSITES
        GetColor(ColorName.ORANGE).setOpposite(GetColor(ColorName.BLUE));
        // PURPLE & YELLOW are OPPOSITES
        GetColor(ColorName.PURPLE).setOpposite(GetColor(ColorName.YELLOW));

        // SET BLEND INFORMATION
        Color red = GetColor(ColorName.RED);
        red.Blends.Add(ColorName.BLUE, GetColor(ColorName.PURPLE));
        red.Blends.Add(ColorName.YELLOW, GetColor(ColorName.ORANGE));

        Color yellow = GetColor(ColorName.YELLOW);
        yellow.Blends.Add(ColorName.RED, GetColor(ColorName.ORANGE));
        yellow.Blends.Add(ColorName.BLUE, GetColor(ColorName.GREEN));

        Color blue = GetColor(ColorName.BLUE);
        blue.Blends.Add(ColorName.RED, GetColor(ColorName.PURPLE));
        blue.Blends.Add(ColorName.YELLOW, GetColor(ColorName.GREEN));
    }

    /// <summary>
    /// Given a inputted ColorName, returns the associated color object
    /// </summary>
    /// <param name="color"></param>
    /// <returns></returns>
    public static Color GetColor(ColorName color)
    {
        return allColors[(int)color];
    }

    /// <summary>
    /// Checks whether two colors are opposites
    /// 
    /// Returns true if they are opposites, otherwise false
    /// </summary>
    /// <param name="color1"></param>
    /// <param name="color2"></param>
    /// <returns></returns>
    public static bool areOpposites(ColorName color1, ColorName color2)
    {
        if (GetColor(color1).OppositeColor.Name == color2)
            return true;
        return false;
    }

    public static ColorName GetColorBlend(Color color1, Color color2)
    {
        // TODO: Add in functionality for secondary colors
        if (color1.Type == ColorType.PRIMARY && color2.Type == ColorType.PRIMARY)
        {
            return color1.Blends[color2.Name].Name;
        }

        return ColorName.NONE;
    }

}

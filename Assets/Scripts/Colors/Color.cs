using System;

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
        getColor(ColorName.GREEN).setOpposite(getColor(ColorName.RED));
        // ORANGE & BLUE are OPPOSITES
        getColor(ColorName.ORANGE).setOpposite(getColor(ColorName.BLUE));
        // PURPLE & YELLOW are OPPOSITES
        getColor(ColorName.PURPLE).setOpposite(getColor(ColorName.YELLOW));
    }

    /// <summary>
    /// Given a inputted ColorName, returns the associated color object
    /// </summary>
    /// <param name="color"></param>
    /// <returns></returns>
    public static Color getColor(ColorName color)
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
        if (getColor(color1).OppositeColor.Name == color2)
            return true;
        return false;
    }

}
 

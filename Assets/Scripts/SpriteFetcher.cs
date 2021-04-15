using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

/// <summary>
/// Lets you grab a specific sprite in code by calling the
/// GetSprite() method. The GetSprite() method has a few 
/// different overloads to account for sprites that have 
/// different purposes.
/// </summary>
/// <author>Harrison Gardner</author>
public class SpriteFetcher : MonoBehaviour
{
    public SpriteFetcher()
    {
        
    }

    //Flower Sprite Getter
    public static Sprite GetSprite(ColorName color, StageType type)
    {
        //Find the Sprites Container and load them into an array
        string spriteName = $"Sprites/{KeyWordFormat(color.ToString())} Flower";
        Sprite[] sprites = Resources.LoadAll<Sprite>(spriteName);

        //Change the spriteName to the name of the specific sprite in that array
        spriteName = $"{KeyWordFormat(color.ToString())} Flower {KeyWordFormat(type.ToString())}";

        foreach (Sprite sp in sprites)
        {
            if (sp.name.Equals(spriteName))
            {
                return sp;
            }
        }
        return null;
    }

    //Plot Sprite Getter
    public static Sprite GetSprite(int waterLevel)
    {
        //Find the Sprites Container and load them into an array
        string spriteName = $"Sprites/Plots";
        Sprite[] sprites = Resources.LoadAll<Sprite>(spriteName);

        //Change the spriteName to the name of the specific sprite in that array
        spriteName = $"Plot Water {waterLevel}";

        foreach (Sprite sp in sprites)
        {
            if (sp.name.Equals(spriteName))
            {
                return sp;
            }
        }
        return null;
    }

    //Tool Sprite Getter
    public enum Tools { WATERINGCAN, CLIPPERS }
    public static Sprite GetSprite(Tools tool, bool toolAction)
    {
        //Find the Sprites Container and load them into an array
        string spriteName = $"Sprites/{KeyWordFormat(tool.ToString())}";
        Sprite[] sprites = Resources.LoadAll<Sprite>(spriteName);

        //Change the spriteName to the name of the specific sprite in that array
        if(toolAction)
            spriteName = $"{KeyWordFormat(tool.ToString())} Using";
        else
            spriteName = $"{KeyWordFormat(tool.ToString())} Idle";

        foreach (Sprite sp in sprites)
        {
            if (sp.name.Equals(spriteName))
            {
                return sp;
            }
        }
        return null;
    }

    //Seed/SeedPouch sprite getter
    public enum SeedOrPouch { SEED, SEEDPOUCH }
    public static Sprite GetSprite(SeedOrPouch seedOrPouch, ColorName color)
    {
        //Find the Sprites Container and load them into an array
        string spriteName = $"Sprites/{KeyWordFormat(seedOrPouch.ToString())}";
        Sprite[] sprites = Resources.LoadAll<Sprite>(spriteName);

        //Change the spriteName to the name of the specific sprite in that array
        spriteName = $"{KeyWordFormat(seedOrPouch.ToString())} {KeyWordFormat(color.ToString())}";

        foreach (Sprite sp in sprites)
        {
            if (sp.name.Equals(spriteName))
            {
                return sp;
            }
        }
        return null;
    }

    //Pest sprite getter
    //Enum here to just make it clear which getter you're using
    public enum Pest { PEST }
    public static Sprite GetSprite(Pest pest)
    {
        //Find the Sprites Container and load them into an array
        string spriteName = $"Sprites/Pest";
        Sprite[] sprites = Resources.LoadAll<Sprite>(spriteName);

        //Change the spriteName to the name of the specific sprite in that array
        spriteName = $"Pest";

        //Don't need a foreach loop for the pest, I'm just lazy
        foreach (Sprite sp in sprites)
        {
            if (sp.name.Equals(spriteName))
            {
                return sp;
            }
        }
        return null;
    }

    //Weather Icon getter
    public static Sprite GetSprite(WeatherType weather)
    {
        //Find the Sprites Container and load them into an array
        string spriteName = $"Sprites/WeatherIcons";
        Sprite[] sprites = Resources.LoadAll<Sprite>(spriteName);

        //Change the spriteName to the name of the specific sprite in that array
        spriteName = $"WeatherIcon {KeyWordFormat(weather.ToString())}";

        //Don't need a foreach loop for the pest, I'm just lazy
        foreach (Sprite sp in sprites)
        {
            if (sp.name.Equals(spriteName))
            {
                return sp;
            }
        }
        return null;
    }

    //This may not be required but this will format a given string to have the first letter
    //be uppercase. Unsure if it's required to find the sprite but I made it so I guess I'll use it.
    private static string KeyWordFormat(string wordToBeFormatted)
    {
        if (wordToBeFormatted == null)
            return null;
        else if (wordToBeFormatted.Length == 1)
            return wordToBeFormatted.ToUpper(); // Shouldn't happen I think
        else
        {
            return char.ToUpper(wordToBeFormatted[0]) + wordToBeFormatted.Substring(1).ToLower();
        }
    }
}

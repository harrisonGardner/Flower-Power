using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Takes the level the player is on, and reads details in from files
/// to determine the game settings, flower orders and seeds in the 
/// seed pouch at the beginning of the game. 
/// </summary>
/// <author>Megan Lisette Peck</author>
public class ReadLevelOrderandSettings : MonoBehaviour
{
    /// <summary>
    /// Read order file, add each order item to list orderItems.
    /// </summary>
    /// <param name="level"></param>
    /// <returns>A list of orderItems including flower orders and seeds the 
    /// player will start with</returns>
    /// <author>Megan Lisette Peck</author>
    public static IList<ItemDetails> LoadOrderItems(string level)
    {
        ItemType orderType = ItemType.NONE;
        int quantity = -1;
        ColorName color = ColorName.NONE;
        ColorType colorType = ColorType.PRIMARY;
        IList<ItemDetails> orderItems = new List<ItemDetails>();

        try
        {
            using (StreamReader reader = new StreamReader(level))
            {
                try
                {
                    // READ FILE CONTENTS, AND PARSE INTO A JARRAY
                    string jsonString = reader.ReadToEnd();
                    JArray orderArray = JArray.Parse(jsonString);

                    foreach (JObject order in orderArray)
                    {
                        //CREATE ENUMERATOR TO ITERATE OVER EACH OBJECT IN THE ARRAY
                        IEnumerator<KeyValuePair<string, JToken>> e = order.GetEnumerator();

                        // ITERATE THROUGH EACH JSON KEYVALUEPAIR
                        while (e.MoveNext())
                        {
                            // USE KEY TO DETERMINE WHICH LOCAL VARIABLE TO ADD THE VALUE TO
                            switch (e.Current.Key)
                            {
                                case "orderType": orderType = stringToEnum<ItemType>(e.Current.Value.ToString()); break;
                                case "colorType": colorType = stringToEnum<ColorType>(e.Current.Value.ToString()); break;
                                case "color": color = stringToEnum<ColorName>(e.Current.Value.ToString()); break;
                                case "quantity": quantity = (int)e.Current.Value; break;
                            }
                        }
                        // ADD EACH ORDER TO THE ORDER LIST
                        orderItems.Add(new ItemDetails(orderType, quantity, color, colorType));
                    }
                    return orderItems;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("There was an error");
                    Console.WriteLine(ex.StackTrace);
                }
            }
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine($"File was not found");
            Console.WriteLine(ex.StackTrace);
        }
        catch (IOException ex)
        {
            Console.WriteLine($"IO problem with ");
            Console.WriteLine(ex.StackTrace);
        }
        return null;
    }

    /// <summary>
    /// Read settings file, add details to the level settings.
    /// </summary>
    /// <param name="level">Easy, Medium or Hard.</param>
    /// <author>Megan Lisette Peck</author>
    public static GameSettings LoadSettings(string level)
    {
        int maxNumDays = -1;
        string levelName = "Dummy Level";
        int bestTime = -1;

        try
        {
            using (StreamReader reader = new StreamReader(level))
            {
                try
                {
                    // READ FILE CONTENTS, AND PARSE INTO A JOBJECT
                    string jsonString = reader.ReadToEnd();
                    JArray settingsArray = JArray.Parse(jsonString);

                    foreach (JObject order in settingsArray)
                    {
                        //CREATE ENUMERATOR TO ITERATE OVER EACH OBJECT IN THE ARRAY
                        IEnumerator<KeyValuePair<string, JToken>> e = order.GetEnumerator();

                        // ITERATE THROUGH EACH JSON KEYVALUEPAIR
                        while (e.MoveNext())
                        {
                            // USE KEY TO DETERMINE WHICH LOCAL VARIABLE TO ADD THE VALUE TO
                            switch (e.Current.Key)
                            {
                                case "maxNumDays": maxNumDays = (int)e.Current.Value; break;
                                case "levelName": levelName = (string)e.Current.Value; break;
                                case "bestTime": bestTime = (int)e.Current.Value; break;
                            }
                        }
                    }
                    // ADD SETTINGS TO THE LEVEL SETTINGS FIELD
                    return new GameSettings(maxNumDays, levelName, bestTime);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("There was an error");
                    Console.WriteLine(ex.StackTrace);
                }
            }
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine($"File was not found");
            Console.WriteLine(ex.StackTrace);
        }
        catch (IOException ex)
        {
            Console.WriteLine($"IO problem with ");
            Console.WriteLine(ex.StackTrace);
        }
        return null;
    }

    /// <summary>
    /// Take a string input, and convert it to a custom
    /// enum type.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="stringToConvert"></param>
    /// <returns></returns>
    private static T stringToEnum<T>(string stringToConvert)
    {
        return (T)Enum.Parse(typeof(T), stringToConvert, true);
    }
}

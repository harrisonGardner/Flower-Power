using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains a set of different generic elements with a count for each
/// of those elements. 
/// </summary>
/// <typeparam name="T"></typeparam>
/// <author>Nicholas Gliserman</author>
public class TalliedSet<T> : IEnumerable
{
    private IDictionary<T, int> Elements { get; set; } = new Dictionary<T, int>();
    public int Num { get; private set; } = 0;

    /// <summary>
    /// Adds a given element to the collection if it is not already there...or, if
    /// it is, then the number of that element type is incremented.
    /// </summary>
    /// <param name="el">the element to be added</param>
    public void Add(T el)
    {
        if (Elements.ContainsKey(el))
            Elements[el]++;
        else
            Elements.Add(el, 1);

        Num++;
    }

    /// <summary>
    /// Adds a given element to the collection in the specified quanity.
    /// </summary>
    /// <param name="el">element to be added</param>
    /// <param name="amount">the number of that element to be added</param>
    public void Add(T el, int amount)
    {
        if (Elements.ContainsKey(el))
            Elements[el] += amount;
        else
            Elements.Add(el, amount);

        Num += amount;
    }

    /// <summary>
    /// Returns true if the element is included in the TalliedSet, otherwise false.
    /// </summary>
    /// <param name="el"></param>
    /// <returns></returns>
    public bool Contains(T el)
    {
        return (Elements.ContainsKey(el) && Elements[el] > 0);
    }

    public int Count(T el)
    {
        if (Elements.ContainsKey(el))
        {
            return Elements[el];
        }
        return 0;
    }

    /// <summary>
    /// Checks if the element is in the collection and, if so,
    /// returns true.
    /// </summary>
    /// <param name="color">Color of the seed to look for.</param>
    /// <returns>True if the player has a seed of that color.</returns>
    public T Remove(T el)
    {
        // CASE WHERE THERE IS A SEED TO REMOVE
        if (Contains(el))
        {
            if (Elements[el] > 0)
            {
                Elements[el]--;
                if (Elements[el] == 0)
                {
                    Elements.Remove(el);
                }
                Num--;
                return el;
            }
        }
        throw new KeyNotFoundException("Specified Element is not included in this TalliedSet");
    }

    public T[] RemoveRandomElements(int numElementsToRemove)
    {
        T[] removedElements;
        if (Num > numElementsToRemove)
        {
            removedElements = new T[numElementsToRemove];
            Num -= numElementsToRemove;
        }
        else
        {
            removedElements = new T[Num];
            Num = 0;
        }

        // CHOOSE RANDOMLY SELECTED ELEMENTS IN DICTIONARY to REMOVE
        for (int i = 0; i < removedElements.Length; i++)
        {
            try
            {
                removedElements[i] = RemoveRandomElement();
            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
        return removedElements;
    }

    /// <summary>
    /// Removes and returns one random element from the collection.
    /// </summary>
    /// <returns></returns>
    public T RemoveRandomElement()
    {
        // GET a RANDOM NUMBER
        if (this.Elements.Keys.Count == 0)
        {
            return default(T);
        }

        //int randomColorNum = MasterController.universallyAvailableRandom.Next(0, this.Elements.Keys.Count);

        int randomColorNum = 0; // TODO DELETE AFTER TEST
        int j = 0;

        foreach (KeyValuePair<T, int> el in this.Elements)
        {
            if (randomColorNum == j)
            {
                return Remove(el.Key);
            }
            j++;
        }

        throw new KeyNotFoundException("Could not find random key");
    }

    public IEnumerator GetEnumerator()
    {
        return Elements.GetEnumerator();
    }

}


using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Stores the details for a flower order or for the numbers of
/// seeds a player will start the game with.
/// </summary>
/// <author>Megan Lisette Peck</author>
public class ItemDetails //: MonoBehaviour
{
    public ItemType itemType { get; private set; }
    public int quantity { get; private set; }
    public ColorName color { get; private set; }
    public ColorType colorType { get; private set; }

    /// <summary>
    /// Creates an ItemDetail object that stores the details
    /// for a flower order or for the numbers of
    /// seeds a player will start the game with.
    /// </summary>
    /// <param name="itemType">Seed, or Flower</param>
    /// <param name="orderNumber">Number of the item</param>
    /// <param name="color">Color of the item</param>
    /// <param name="colorType">Color type</param>
    public ItemDetails(ItemType itemType, int orderNumber, ColorName color, ColorType colorType)
    {
        this.itemType = itemType;
        this.quantity = orderNumber;
        this.color = color;
        this.colorType = colorType;
    }

    public override string ToString()
    {
        return $"Item: {itemType}, ColorType: {colorType}, Color: {color}, Quantity: {quantity}";
    }
}

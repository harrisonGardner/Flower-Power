using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///// <summary>
///// Holds the given amount of items, of the type specified.
///// Adds items up to the capacity, when an item is called, it is 
///// moved to the end of the queue.
///// </summary>
///// <author>Megan Lisette Peck</author>
public class RevolvingQueue<T> : MonoBehaviour
{
    private int head;
    private int tail;
    private int n;
    private int capacity;
    private T[] items;

    /// <summary>
    /// Creates the queue with the capacity specified by the user.
    /// </summary>
    /// <param name="capacity">Size of queue to create.</param>
    public RevolvingQueue(int capacity)
    {
        this.capacity = capacity;

        //initialize the empty queue
        head = -1;
        tail = -1;
        n = 0;
        items = new T[capacity];
    }

    /// < summary >
    /// Add an item to the last position in the queue.
    /// </summary>
    /// < param name="item">Item to queue</param>
    public void Enqueue(T item)
    {
        if (n == capacity)
            throw new System.NotSupportedException("Can't add an item to a full queue.");
        if (IsEmpty())
            head = 0;

        tail = ++tail % capacity;
        items[tail] = item;
        n++;
    }

    /// < summary >
    /// Returns the item at the front of the queue, and moves it
    /// to the back of the queue.
    /// </summary>
    /// < returns>First item in the queue.</returns>
    public T MoveItemToTail()
    {
        if (IsEmpty())
            throw new NotSupportedException("Can't remove an item from an empty queue.");
        T removedItem = items[head];

        //UPDATE POSITION OF THE HEAD AND TAIL
        head = ++head % capacity;
        tail = ++tail % capacity;

        return removedItem;
    }

    /// < summary >
    /// Look at the next item in the queue, without moving it
    /// to the end of the queue.
    /// </summary>
    /// < returns></returns>
    public T Peek()
    {
        if (IsEmpty())
            throw new NotSupportedException("Can't remove an item from an empty queue.");
        T nextItem = items[head];
        return nextItem;
    }

    /// <summary>
    /// Determins the number of items currently in the queue.
    /// </summary>
    /// <returns>Number of elements</returns>
    public int Size()
    {
        return n;
    }

    /// <summary>
    /// Determins whether the queue is empty.
    /// </summary>
    /// <returns>True if the queue is empty</returns>
    public bool IsEmpty()
    {
        return n == 0;
    }
}

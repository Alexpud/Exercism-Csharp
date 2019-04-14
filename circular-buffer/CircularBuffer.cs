using System;
using System.Linq;
using System.Collections.Generic;

public class CircularBuffer<T>
{
    private Node<T> head;
    private Node<T> tail;
    public int length;
    private readonly int capacity;
    
    public CircularBuffer(int capacity)
    {
        this.capacity = capacity;
    }

    public T Read()
    {
        if (head == null)
        {
            throw new InvalidOperationException("Cant read from an empty buffer");
        }

        var value = head.Value;
        head = head.Next;
        length--;
        return value;
    }

    public void Write(T value)
    {
        if(length == capacity)
        {
            throw new InvalidOperationException("Buffer is at maximum capacity");
        }

        if (head == null)
        {
            head = new Node<T>(value);
            tail = head;
            length++;
            return;
        }
        
        FindPositionAndInsertElement(value);
    }

    private void FindPositionAndInsertElement(T value)
    {
        Node<T> currentElement = tail;
        var newNode = new Node<T>(value);
        length++;
        if (length == capacity)
        {
            newNode.Next = head;
        }
        currentElement.Next = newNode;
        tail = currentElement.Next;
    }

    public void Overwrite(T value)
    {
        if (length != capacity)
        {
            Write(value);
            return;
        }
        head.Value = value;
        head = head.Next;
    }

    public void Clear()
    {
        head = null;
        length = 0;
    }

    private class Node<T> 
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }

        public Node(T value)
        {
            this.Value = value;
            this.Next = null;
        }
    }
}
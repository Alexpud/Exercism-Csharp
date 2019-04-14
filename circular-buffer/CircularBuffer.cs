using System;
using System.Linq;
using System.Collections.Generic;

public class CircularBuffer<T>
{
    private readonly int capacity;
    private int insertPosition;
    private int readPosition;
    private T[] buffer;
    private int length;

    public CircularBuffer(int capacity)
    {
        this.capacity = capacity;
        buffer = new T[capacity];
    }

    public T Read()
    {
        if (length == 0)
        {
            throw new InvalidOperationException("Cant read from an empty buffer");
        }

        readPosition %= this.capacity;
        if (readPosition >= capacity)
        {
            throw new InvalidOperationException("An item is only readable once");
        }

        this.length--;
        return buffer[readPosition++];
    }

    public void Write(T value)
    {
        bool bufferIsFull = this.length == this.capacity;
        if (bufferIsFull)
        {
            throw new InvalidOperationException("Cant write to a full buffer");
        }

        insertPosition %= this.capacity;
        buffer[insertPosition++] = value;
        this.length++;
    }

    public void Overwrite(T value)
    {
        bool bufferIsFull = this.length == this.capacity;
        if (bufferIsFull)
        {
            insertPosition %= this.capacity;
            buffer[insertPosition] = value;
            readPosition++;
        }
        else
        {
            buffer[insertPosition++] = value;
            this.length++;
        }
    }

    public void Clear()
    {
        buffer = new T[capacity];
        this.length = 0;
        insertPosition = 0;
        readPosition = 0;
    }
}
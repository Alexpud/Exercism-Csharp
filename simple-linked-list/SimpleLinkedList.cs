using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SimpleLinkedList<T> : IEnumerable<T>
{
    private SimpleLinkedList<T> _next;
    private T _value;

    public SimpleLinkedList() { }
    public SimpleLinkedList(T value)
    {
        _value = value;
    }

    public SimpleLinkedList(IEnumerable<T> values)
    {
    }

    public T Value 
    { 
        get => _value;
        private set => _value = value;
    }

    public SimpleLinkedList<T> Next
    { 
        get
        {
            return _next;
        }
    }

    public SimpleLinkedList<T> Add(T value)
    {
        var current = _next;
        while(current != null)
        {
            current = current.Next;
        }
        current = new SimpleLinkedList<T>(value);
        return this;
    }

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        var current = this;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }
}
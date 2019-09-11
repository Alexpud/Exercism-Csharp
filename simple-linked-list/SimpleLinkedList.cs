using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace SimpleLinkedList
{
    public class SimpleLinkedList<T> : IEnumerable<T>
    {
        private Node<T> _head;
        private IEnumerator<T> _enumerator;
        public SimpleLinkedList(T value)
        {
            _head = new Node<T>(value);
            _enumerator = new SimpleLinkedListEnumerator<T>(_head);
        }

        public SimpleLinkedList(IEnumerable<T> values)
        {
            throw new NotImplementedException("You need to implement this function.");
        }

        public T Value
        {
            get
            {
                return _enumerator.Current;
            }
        }

        public SimpleLinkedList<T> Next
        {
            get
            {
                if (_enumerator.MoveNext())
                    return this;
                return null;
            }
        }

        public SimpleLinkedList<T> Add(T value)
        {
            _head.Next = new Node<T>(value);
            return this;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new SimpleLinkedListEnumerator<T>(_head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public class Node<T>
    {
        public T Value;
        public Node<T> Next;

        public Node(T value)
        {
            Value = value;
        }
    }

    public class SimpleLinkedListEnumerator<T> : IEnumerator<T>
    {
        private Node<T> _head;
        private Node<T> _current;
        object IEnumerator.Current => _current.Value;
        T IEnumerator<T>.Current => _current.Value;

        public SimpleLinkedListEnumerator(Node<T> node)
        {
            _head = node;
            _current = node;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (_current.Next != null)
            {
                _current = _current.Next;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
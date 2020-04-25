using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BinarySearchTree : IEnumerable<int>
{
    private int _value = 0;
    private BinarySearchTree _leftNode;
    private BinarySearchTree _rightNode;
    public BinarySearchTree() { }

    public BinarySearchTree(int value)
    {
        _value = value;
    }

    public BinarySearchTree(IEnumerable<int> values)
    {
        foreach(var value in values)
        {
            Add(value);
        }
    }

    public int Value
    {
        get
        {
            return _value;
        }
    }

    public BinarySearchTree Left
    {
        get
        {
            return _leftNode;
        }
    }

    public BinarySearchTree Right
    {
        get
        {
            return _rightNode;
        }
    }

    public BinarySearchTree Add(int value)
    {
        if (this._value == 0)
        {
            this._value = value;
            return this;
        }
        if  (value <= this._value)
        {
            _leftNode = _leftNode == null ? new BinarySearchTree(value) : _leftNode.Add(value);
            return this;
        }
        if  (value > this._value)
        {
            _rightNode = _rightNode == null ? new BinarySearchTree(value) : _rightNode.Add(value);
            return this;
        }

        return this;
    }

    public IEnumerator<int> GetEnumerator()
    {
        var nodesInOrder = InOrderTreeTraversal(this, new List<int>());
        foreach(var node in nodesInOrder)
        {
            yield return node;
        }
    }

    public List<int> InOrderTreeTraversal(BinarySearchTree node, List<int> nodesValues)
    {
        if (node.Left != null)
        {
            nodesValues = InOrderTreeTraversal(node.Left, nodesValues);
        }
        
        nodesValues.Add(node._value);

        if (node.Right != null)
        {
            nodesValues = InOrderTreeTraversal(node.Right, nodesValues);
        }
        return nodesValues;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BinarySearchTree : IEnumerable<int>
{
    private int value = 0;
    private BinarySearchTree leftNode;
    private BinarySearchTree rightNode;
    public BinarySearchTree() { }

    public BinarySearchTree(int value)
    {
        this.value = value;
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
            return this.value;
        }
    }

    public BinarySearchTree Left
    {
        get
        {
            return leftNode;
        }
    }

    public BinarySearchTree Right
    {
        get
        {
            return rightNode;
        }
    }

    public BinarySearchTree Add(int value)
    {
        if (this.value == 0)
        {
            this.value = value;
            return this;
        }
        if  (value <= this.value)
        {
            leftNode = leftNode == null ? new BinarySearchTree(value) : leftNode.Add(value);
            return this;
        }

        if  (value > this.value)
        {
            rightNode = rightNode == null ? new BinarySearchTree(value) : rightNode.Add(value);
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
        nodesValues.Add(node.value);

        if (node.rightNode != null)
        {
            nodesValues = InOrderTreeTraversal(node.rightNode, nodesValues);
        }
        return nodesValues;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
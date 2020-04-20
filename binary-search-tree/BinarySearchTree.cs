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
        var currentNode = this;
        while(true)
        {
            if (currentNode.Left != null)
            {
                currentNode = currentNode.leftNode;
            }
            else if (currentNode.Right != null)
            {
                currentNode = currentNode.Right;
            }
        }
        throw new NotImplementedException("You need to implement this function.");
    }

    public List<int> Search(BinarySearchTree node, List<int> nodesValues)
    {
        if (node.Left != null)
        {
            nodesValues = Search(node.Left, nodesValues);
        }
        nodesValues.Add(node.value);

        if (node.rightNode != null)
        {
            nodesValues = Search(node.rightNode, nodesValues);
        }
        return nodesValues;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
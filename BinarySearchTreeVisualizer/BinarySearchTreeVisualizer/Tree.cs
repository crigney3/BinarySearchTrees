using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearchTreeVisualizer
{
    class Tree
    {
        protected Node root;
        protected List<int> output;
        protected List<int> minOutput;
        public Node Root { get { return this.root; } }
        public List<int> Output { get { return this.output; } }

        /// <summary>
        /// Default tree constructor. With the root set to null, the next 
        /// AddNode() call will be the root.
        /// </summary>
        public Tree()
        {
            this.root = null;
            this.output = new List<int>();
        }

        /// <summary>
        /// Constructs a tree. Automatically runs AddNode() given the dataset.
        /// </summary>
        /// <param name="data"></param>
        public Tree(int[] data)
        {
            this.root = AddNode(null, data[0]);
            this.output = new List<int>();
            for (int i = 0; i < data.Length; i++)
            {
                AddNode(this.root, data[i]);
            }
        }

        /// <summary>
        /// Add a node to the tree (recursively)
        /// </summary>
        /// <param name="node"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public Node AddNode(Node node,int key)
        {
           if(node == null)
           {
                node = new Node(key);
                return node;
           }
           if(node.Key > key)
           {
                node.NodeLeft = AddNode(node.NodeLeft, key);
           }
           else if(node.Key < key)
           {
                node.NodeRight = AddNode(node.NodeRight, key);
           }
            return node;

        }

        /// <summary>
        /// Given a node, deletes it from the try and rebalances. Uses the successor() to 
        /// correctly rebalance
        /// </summary>
        /// <param name="toDelete"></param>
        public void Remove(Node toDelete)
        {
            if(toDelete.NodeLeft == null && toDelete.NodeRight == null)
            {
                toDelete = null;
            }
            else if(toDelete.NodeLeft == null && toDelete.NodeRight != null) {
                toDelete = toDelete.NodeRight;
            }
            else if(toDelete.NodeRight == null && toDelete.NodeLeft != null)
            {
                toDelete = toDelete.NodeLeft;
            }
            else if(toDelete.NodeLeft != null && toDelete.NodeRight != null)
            {
                this.minOutput.Clear();
                minValue(toDelete);
                Node successor = Search(this.minOutput[0], toDelete.NodeRight);
                toDelete = successor;
                Remove(successor);
            }
        }

        /// <summary>
        /// Searches for a node that has a particular key, returns the node
        /// </summary>
        /// <param name="key"></param>
        /// <param name="startNode"></param>
        /// <returns></returns>
        public Node Search(int key, Node startNode)
        {
            while (startNode != null)
            {
                if (startNode.Key == key)
                {
                    return startNode;
                }
                else if (startNode.Key < key)
                {
                    startNode = startNode.NodeRight;
                }
                else
                {
                    startNode = startNode.NodeLeft;
                }
            }
            return null;
        }

        public void minValue(Node node)
        {
            if(node == null)
            {
                return;
            }
            minValue(node.NodeLeft);
            this.minOutput.Add(node.Key);
            minValue(node.NodeRight);
        }

        /// <summary>
        /// Sets the tree's output to an InOrder sort of the nodes
        /// </summary>
        /// <param name="node"></param>
        public void InOrder(Node node)
        {
            if (node == null)
            {
                return;
            }
            InOrder(node.NodeLeft);
            this.output.Add(node.Key);
            InOrder(node.NodeRight);
        }
    }
}

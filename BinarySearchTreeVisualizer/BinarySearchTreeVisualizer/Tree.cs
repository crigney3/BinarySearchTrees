using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearchTreeVisualizer
{
    class Tree
    {
        protected Node root;
        protected List<int> output;
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
            Node parent;
            Node successor = Successor(toDelete);
            parent = GetParent(this.root, toDelete);
            toDelete = successor;              
            
            if(successor != null)
            {
                SetNewChild(parent, toDelete);
                Remove(successor);
            }

        }

        public void SetNewChild(Node node, Node child)
        {
            if(node.Key < child.Key)
            {
                node.NodeRight = child;
            }
            else if (node.Key > child.Key)
            {
                node.NodeLeft = child;
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

        public Node GetParent(Node node, Node child)
        {
            if(node.NodeLeft == child || node.NodeRight == child)
            {
                return node;
            }
            if(child.Key < node.Key)
            {
                node = node.NodeLeft;
            }
            else if(child.Key > node.Key)
            {
                node = node.NodeRight;
            }
            node = GetParent(node, child);
            return node;
        }

        public Node Successor(Node node)
        {
            Node bestLeft = node.NodeLeft;
            Node bestRight = node.NodeRight;
            if(bestLeft != null)
            {
                while (true)
                {
                    if (bestLeft.NodeRight == null)
                    {
                        break;
                    }
                    bestLeft = bestLeft.NodeRight;
                }
            }
            if(bestRight != null)
            {
                while (true)
                {
                    if (bestRight.NodeLeft == null)
                    {
                        break;
                    }
                    bestRight = bestRight.NodeLeft;
                }
            }

            if (bestLeft != null && bestRight != null)
            {
                if (Math.Abs(node.Key - bestLeft.Key) < Math.Abs(node.Key - bestRight.Key))
                {
                    return bestLeft;
                }
                else
                {
                    return bestRight;
                }
            }
            if (bestLeft == null)
            {
                return bestRight;
            }
            else if(bestRight == null)
            {
                return bestLeft;
            }
            else
            {
                return null;
            }
            
            
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

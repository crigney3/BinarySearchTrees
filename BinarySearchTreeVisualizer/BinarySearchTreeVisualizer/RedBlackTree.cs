using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearchTreeVisualizer
{
    class RedBlackTree
    {
        protected Node root;
        protected List<int> output;
        public Node Root { get { return this.root; } }
        public List<int> Output { get { return this.output; } }

        public RedBlackTree(int[] data)
        {
            this.root = AddNode(null, data[0]);
            this.output = new List<int>();
            for (int i = 0; i < data.Length; i++)
            {
                AddNode(this.root, data[i]);
            }
        }

        public Node AddNode(Node node, int key)
        {
            if (node == null)
            {
                node = new Node(key);
                return node;
            }
            if (node.Key > key)
            {
                node.NodeLeft = AddNode(node.NodeLeft, key);
            }
            else if (node.Key < key)
            {
                node.NodeRight = AddNode(node.NodeRight, key);
            }
            return node;

        }

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

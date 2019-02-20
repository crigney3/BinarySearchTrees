using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearchTreeVisualizer
{
    class RedBlackTree
    {
        protected RBNode root;
        protected List<int> output;
        public RBNode Root { get { return this.root; } }
        public List<int> Output { get { return this.output; } }

        public RedBlackTree(int[] data)
        {
            this.root = AddNode(null, data[0]);
            this.output = new List<int>();
            for (int i = 1; i < data.Length; i++)
            {
                AddNode(this.root, data[i]);
            }
        }

        public RBNode AddNode(RBNode root, int key)
        {
            RBNode newNode = new RBNode(key, Color.Black, null);
            InsertNode(root, newNode);

            RepairTree(newNode);
            return newNode;
        }

        public RBNode Search(int key, RBNode startRBNode)
        {
            while (startRBNode != null)
            {
                if (startRBNode.Key == key)
                {
                    return startRBNode;
                }
                else if (startRBNode.Key < key)
                {
                    startRBNode = startRBNode.RBNodeRight;
                }
                else
                {
                    startRBNode = startRBNode.RBNodeLeft;
                }
            }
            return null;
        }

        public void InOrder(RBNode node)
        {
            if (node == null)
            {
                return;
            }
            
            if(node.leaf != Leaf.LEAF)
            {
                InOrder(node.RBNodeLeft);
                this.output.Add(node.Key);
                InOrder(node.RBNodeRight);
            }
            else
            {
                return;
            }

            
        }

        private void InsertNode(RBNode root, RBNode n)
        {
            if(root != null && n.Key < root.Key)
            {
                if(root.RBNodeLeft.leaf != Leaf.LEAF)
                {
                    InsertNode(root.RBNodeLeft, n);
                    return;
                }
                else
                {
                    root.RBNodeLeft = n;
                }
            }
            else if(root != null)
            {
                if(root.RBNodeRight.leaf != Leaf.LEAF)
                {
                    InsertNode(root.RBNodeRight, n);
                    return;
                }
                else
                {
                    root.RBNodeRight = n;
                }
            }

            n.Parent = root;
            n.Color = Color.Red;
        }

        private void RepairTree(RBNode node)
        {
            if(node == null)
            {
                return;
            }

            try
            {
                if (node.Parent == null)
                {
                    node.Color = Color.Black;
                    return;
                }
                else if (node.Parent.Color == Color.Black)
                {
                    return;
                }
                else if ((node.Uncle().Color == Color.Red && node.Uncle().leaf != Leaf.LEAF))
                {
                    Case1(node);
                }

                else
                {
                    Case2(node);
                }
            }
            catch(Exception e)
            {
                //Nooope
            }
            
            RepairTree(node.Parent);
        }

        private void Case1(RBNode node)
        {
            node.Parent.Color = Color.Black;
            node.Uncle().Color = Color.Black;
            node.Grandparent().Color = Color.Red;
            RepairTree(node.Grandparent());
        }

        private void Case2(RBNode node)
        {
            
                if (node == node.Grandparent().RBNodeLeft.RBNodeRight)
                {
                    RotateLeft(node.Parent);
                    if (node.RBNodeLeft.leaf != Leaf.LEAF)
                    {
                        node = node.RBNodeLeft;
                    }
                }
                else if (node == node.Grandparent().RBNodeRight.RBNodeLeft)
                {
                    RotateRight(node.Parent);
                    if(node.RBNodeRight.leaf != Leaf.LEAF)
                    {
                        node = node.RBNodeRight;
                    }
                    
                }
            
            
            
            if(node == node.Parent.RBNodeLeft)
            {
                RotateRight(node.Parent);
            }
            else
            {
                RotateLeft(node.Parent);
            }
            node.Parent.Color = Color.Black;

            if(node.Grandparent() != null)
            {
                node.Grandparent().Color = Color.Red;
                
            }

        }

        private void RotateRight(RBNode node)
        {
            RBNode pivot = node;
            RBNode root = node.Parent;
            RBNode parent = root.Parent;

            pivot.Parent = parent;
            root.RBNodeLeft = pivot.RBNodeRight;
            if (parent != this.root.Parent)
            {
                parent.RBNodeRight = pivot;
            }
            else
            {
                this.root = pivot;
            }
            
            pivot.RBNodeRight = root;
            root.Parent = pivot;
        }

        private void RotateLeft(RBNode node)
        {
            RBNode pivot = node;
            RBNode root = node.Parent;
            RBNode parent = root.Parent;

            pivot.Parent = parent;
            root.RBNodeRight = pivot.RBNodeLeft;
            if (parent != this.root.Parent)
            {
                parent.RBNodeLeft = pivot;
            }
            else
            {
                this.root = pivot;
            }
            pivot.RBNodeLeft = root;
            root.Parent = pivot;
        }
    }
}

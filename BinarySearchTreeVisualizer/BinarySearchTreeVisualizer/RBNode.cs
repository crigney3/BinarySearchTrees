using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearchTreeVisualizer
{
    public enum Color
    {
        Red,
        Black
    }
    public enum Leaf
    {
        LEAF,
        not
    }
    class RBNode
    {
        protected RBNode rBNodeLeft;
        protected RBNode rBNodeRight;
        protected RBNode parent;
        protected int key;
        protected Color color;
        public Leaf leaf;
        public RBNode RBNodeLeft { get { return this.rBNodeLeft; } set { this.rBNodeLeft = value; } }
        public RBNode RBNodeRight { get { return this.rBNodeRight; } set { this.rBNodeRight = value; } }
        public RBNode Parent { get { return this.parent; } set { this.parent = value; } }
        public int Key { get { return this.key; } }
        public Color Color { get { return this.color; } set { this.color = value; } }

        public RBNode(int key, Color color, RBNode parent)
        {
            this.RBNodeLeft = new RBNode(parent);
            this.RBNodeRight = new RBNode(parent);
            this.parent = parent;
            this.key = key;
            this.color = color;
            this.leaf = Leaf.not;
        }

        /// <summary>
        /// Generates a leaf
        /// </summary>
        public RBNode(RBNode parent)
        {
            this.color = Color.Black;
            this.leaf = Leaf.LEAF;
            this.RBNodeLeft = null;
            this.RBNodeRight = null;
            this.parent = parent;
        }

        public RBNode Grandparent()
        {
            if(this.parent == null)
            {
                return null;
            }
            return this.parent.parent;
        }

        public RBNode Sibling()
        {
            if (this.parent == null)
            {
                return null;
            }
            if(this == this.parent.rBNodeLeft)
            {
                return this.parent.rBNodeRight;
            }
            else
            {
                return this.parent.rBNodeLeft;
            }
        }

        public RBNode Uncle()
        {
            if (this.parent == null)
            {
                return null;
            }
            return this.parent.Sibling();
        }


    }
}

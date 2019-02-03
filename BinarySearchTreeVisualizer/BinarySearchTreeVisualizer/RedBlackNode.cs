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
    class RedBlackNode
    {
        protected Node nodeLeft;
        protected Node nodeRight;
        protected int key;
        protected Color color;
        public Node NodeLeft { get { return this.nodeLeft; } set { this.nodeLeft = value; } }
        public Node NodeRight { get { return this.nodeRight; } set { this.nodeRight = value; } }
        public int Key { get { return this.key; } }
        public Color Color { get { return this.color; } set { this.color = value; } }

        public RedBlackNode(int key)
        {
            this.nodeLeft = null;
            this.nodeRight = null;
            this.key = key;
            this.color = Color.Black;
        }

        public RedBlackNode(int key, Color color)
        {
            this.nodeLeft = null;
            this.nodeRight = null;
            this.key = key;
            this.color = color;
        }


    }
}

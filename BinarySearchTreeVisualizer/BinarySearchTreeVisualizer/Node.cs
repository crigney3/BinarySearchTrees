using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearchTreeVisualizer
{
    class Node
    {
        /*
         * nodeAbove; nodeLeft; nodeRight; nodeValue; nodeKey;
         * 
         * public NodeAbove; public NodeLeft; public NodeRight; public NodeValue; public NodeKey;
         * 
         * Node constructor, set all to null, take a value, a key, and a Node as params
         * 
         * 
         * 
         * 
        */
        //Nodes need a left and right node, and a key
        protected Node nodeLeft;
        protected Node nodeRight;
        protected int key;
        public Node NodeLeft { get { return this.nodeLeft; } set { this.nodeLeft = value; } }
        public Node NodeRight { get { return this.nodeRight; } set { this.nodeRight = value; } }
        public int Key { get { return this.key; } }

        /// <summary>
        /// Create a default node from the key. The children may
        /// be updated later.
        /// </summary>
        /// <param name="key"></param>
        public Node(int key)
        {
            this.nodeLeft = null;
            this.nodeRight = null;
            this.key = key;
        }
    }
}

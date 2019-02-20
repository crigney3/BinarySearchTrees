using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearchTreeVisualizer
{
    class Visual
    {
        private Tree tree;
        private int currentX;
        private int currentY;
        private int depth;
        public Tree NewTree { set { this.tree = value; } }

        public Visual(Tree tree)
        {
            this.tree = tree;
            this.currentX = 0;
            this.currentY = 0;
        }

        public void DrawAt(int x, int y, int toDraw)
        {
            Console.CursorLeft = x;
            Console.CursorTop = y;
            Console.Write(toDraw);
        }

        public void DrawTree()
        {
            Console.Clear();
            this.currentX = Console.WindowWidth/2;
            this.currentY = 10;
            PrintTree(this.tree.Root);
        }

        private void PrintTree(Node node)
        {
            if(node.NodeLeft != null)
            {
                this.currentX -= 5;
                this.currentY += 5;
                this.depth += 1;
                PrintTree(node.NodeLeft);
            }
            else
            {
                DrawAt(this.currentX, this.currentY, node.Key);
                this.currentX += 5*this.depth;
                this.currentY -= 5*this.depth;
                this.depth = 0;
                return;
            }
            if(node.NodeRight != null)
            {
                this.currentX += 5;
                this.currentY += 5;
                this.depth += 1;
                PrintTree(node.NodeRight);
            }
            else
            {
                DrawAt(this.currentX, this.currentY, node.Key);
                this.currentX -= 5 * this.depth;
                this.currentY -= 5 * this.depth;
                this.depth = 0;
                return;
            }
            
        }

    }
}

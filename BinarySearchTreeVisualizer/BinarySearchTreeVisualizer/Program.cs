﻿using System;

namespace BinarySearchTreeVisualizer
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] testData = new int[10];
            testData[0] = 5;
            testData[1] = 9;
            testData[2] = 4;
            testData[3] = 1;
            testData[4] = 2;
            testData[5] = 8;
            testData[6] = 6;
            testData[7] = 7;
            testData[8] = 10;
            testData[9] = 3;

            Tree tree = new Tree(testData);
            tree.AddNode(tree.Root, 15);
            tree.AddNode(tree.Root, 0);
            tree.AddNode(tree.Root, 11);
            tree.InOrder(tree.Root);
            for (int i = 0; i < tree.Output.Count; i++)
            {
                Console.WriteLine(tree.Output[i]);
            }
            Console.WriteLine(tree.Search(11, tree.Root));
            tree.AddNode(tree.Root, 23);
            tree.Remove(tree.Search(8, tree.Root));
            tree.InOrder(tree.Root);
            for (int i = 0; i < tree.Output.Count; i++)
            {
                Console.WriteLine(tree.Output[i]);
            }
        }
    }
}

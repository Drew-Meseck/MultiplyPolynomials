﻿using System;
using System.Collections.Generic;

namespace MultiplyPolynomials
{
    class Program
    {
        static void Main(string[] args) //Give input and run the Alogorithm
        {
            int[] p1 = {4, 4, 2, 3, -3, 1, 2, 0, -6};
            int[] p2 = {4, 3, 2, 2, -3, 1, 1, 0, -2};
            PrintArray(Multiply(p1, p2));
        }

        static int[] Multiply(int[] p1, int[] p2) //The Algorithm
        {

            List<Node> temp = new List<Node>();
                
            for (int i = 1; i <= p1[1]*2 - 1; i += 2)
            {
                for(int j = 1; j <= p2[0]*2 - 1; j += 2)
                {
                    
                    Node node = new Node(p1[i] + p2[j], p1[i+1] * p2[j+1]);
                    temp.Add(node);
                }
            }
            
            return AddMerge(temp);
        }

        static int[] AddMerge(List<Node> node)//A subfunction that is part of the algorithm, adds like terms and outputs the final result
        {
            for (int i = 0; i < node.Count; i++)
            {
                for (int j = 1; j + i < node.Count; j++)
                {
                    if (node[i].exp == node[j + i].exp)
                    {
                        node[i].coef += node[j + i].coef;
                        node.RemoveAt(j + i);
                    }
                }
            }

            for(int i = 0; i < node.Count; i++)
            {
                if(node[i].coef == 0)
                {
                    node.RemoveAt(i);
                }
            }

            int[] NewPoly = new int[(node.Count*2) + 1];
            NewPoly[0] = node.Count;
            int f = 0;
            for(int i = 1; i < NewPoly.Length - 1; i += 2)
            {
                NewPoly[i] = node[f].exp;
                NewPoly[i + 1] = node[f].coef;
                f++;
            }
            return NewPoly;
        }
        public static void PrintArray(int[] arr)
        {
            Console.Write("[ ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]}, ");
            }
            Console.Write("]");
        }


    }

    class Node
    {
        public int exp { get; set; }
        public int coef { get; set; }

        public Node(int e, int c)
        {
            this.exp = e;
            this.coef = c;
        }

    }
}

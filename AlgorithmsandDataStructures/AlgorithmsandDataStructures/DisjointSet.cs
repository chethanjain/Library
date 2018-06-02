using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsandDataStructures
{
    /*
    Disjoint set : Union find algorithm with Union by rank and path compression.
    */
    public class Node
    {
        public int Val { get; set; }

        public Node Parent { get; set; }

        public int Rank { get; set; }
    }
    public class DisjointSet
    {
        Dictionary<int, Node> keys = new Dictionary<int, Node>();
        public void MakeSet(int val)
        {
            if (keys.ContainsKey(val)) return;

            Node node = new Node();
            node.Val = val;
            node.Parent = node;
            node.Rank = 0;

            keys.Add(val, node);
        }

        public void Union(int num1, int num2)
        {
            if (!keys.ContainsKey(num1) || !keys.ContainsKey(num2)) return;

            var firstnode = FindSetInternal(keys[num1]);
            var Secondnode = FindSetInternal(keys[num2]);

            if (firstnode == Secondnode) return;

            if (firstnode.Rank == Secondnode.Rank)
            {
                Secondnode.Parent = firstnode;
                firstnode.Rank += 1;
            }
            else
            {
                if (firstnode.Rank < Secondnode.Rank)
                {
                    var temp = firstnode;
                    firstnode = Secondnode;
                    Secondnode = temp;
                }

                Secondnode.Parent = firstnode;
            }
        }

        public int FindSet(int num)
        {
            if (keys.ContainsKey(num))
                return FindSetInternal(keys[num]).Val;

            return -1;
        }

        private Node FindSetInternal(Node node)
        {
            if (node.Parent == node)
            {
                return node;
            }

            var parent = FindSetInternal(node.Parent);
            node.Parent = parent;
            return parent;
        }
    }

    public class TestDisJointSet
    {
        public static void Main()
        {
            Console.WriteLine("Testing DisJoint Sets and Union Find Algorithm \n");

            var input = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var ds = new DisjointSet();

            for (int i = 0; i < input.Length; i++)
            {
                ds.MakeSet(input[i]);
            }

            Console.WriteLine();

            for (int i = 0; i < input.Length; i++)
            {
                Console.WriteLine("Parent of {0} is {1} ", input[i], ds.FindSet(input[i]));
            }

            Console.WriteLine();

            for (int i = 0; i < input.Length - 1; i++)
            {
                ds.Union(input[i], input[i + 1]);
                Console.WriteLine("Union of {0} and {1} ", input[i], input[i + 1]);
                Console.WriteLine("Parent of {0} is {1} ", input[i], ds.FindSet(input[i]));
                Console.WriteLine("Parent of {0} is {1} ", input[i + 1], ds.FindSet(input[i + 1]));
            }

            Console.ReadLine();
        }
    }
}

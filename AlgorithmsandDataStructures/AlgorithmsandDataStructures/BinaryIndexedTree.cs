using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsandDataStructures
{
    public class BinaryIndexedTree
    {
        private int[] m_bitarray;
        public BinaryIndexedTree(int[] array)
        {
            m_bitarray = new int[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
            {
                Update(i + 1, array[i]); // one based BIT
            }
        }

        public void Update(int index, int value)
        {
            while (index < m_bitarray.Length)
            {
                m_bitarray[index] += value;
                index = index + (index & -index);
            }
        }

        public int PrefixSum(int index)
        {
            int sum = 0;

            while (index > 0)
            {
                sum += m_bitarray[index];
                index -= index & -index;
            }
            return sum;
        }

        public int RangeSum(int startindex, int endindex)
        {
            return PrefixSum(endindex) - PrefixSum(startindex - 1);
        }
    }

    public class TestBinaryIndexedTree
    {
        public static void Main()
        {
            Console.WriteLine("Testing binary indexed trees \n");

            var input = new int[] { 5, 3, 2, 1, 5, 6, 6, 4, 4, 4, 3, 3, 32, 1 };

            var bit = new BinaryIndexedTree(input);

            Console.WriteLine("Prefix sum - Till 6 - " + bit.PrefixSum(6));
            Console.WriteLine("Prefix sum - Till 1 - " + bit.PrefixSum(1));

            Console.WriteLine("Range sum - From 5 to 8 - " + bit.RangeSum(5, 8));

            Console.WriteLine("Add 10 to 5th Element ");
            bit.Update(5, 10);

            Console.WriteLine("Range sum - From 5 to 8 - " + bit.RangeSum(5, 8));
            Console.ReadLine();
        }
    }
}

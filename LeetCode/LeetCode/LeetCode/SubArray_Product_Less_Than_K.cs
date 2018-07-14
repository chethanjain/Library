using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /// <summary>
    /// Problem Link https://leetcode.com/problems/subarray-product-less-than-k/description/ 
    /// </summary>
    class SubArray_Product_Less_Than_K
    {
        public int NumSubarrayProductLessThanK(int[] nums, int k)
        {
            if (nums == null || k == 0 || k == 1)
                return 0;

            int p = 1;
            int i = 0;
            int len = 0;
            int count = 0;

            while (i < nums.Length)
            {
                p *= nums[i];

                if (p < k)
                    count += ++len;
                else
                {
                    while (p >= k)
                    {
                        p /= nums[i - len];
                        len--;
                    }

                    count += ++len;
                }

                i++;
            }
            return count;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace PriteshLearning
{
    public class Array
    {
        static void Main()
        {
            int[] res = new int[4] { 1, 2, 3, 4 };
            RunningSum(res);
        }

        public static int[] RunningSum(int[] nums)
        {
            int prevSum = 0;
            int[] result = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                prevSum = prevSum + nums[i];
                result[i] = prevSum;
            }

            return result;
        }
    }
}

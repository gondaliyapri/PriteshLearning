using System;
using System.Collections.Generic;
using System.Text;

namespace PriteshLearning
{
    public class Array
    {
        static void Main()
        {
            int[] res = new int[4] { 1, 3, 5, 6 };
            SearchInsert(res, 5);
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

        public static int SearchInsert(int[] nums, int target)
        {
            int pivot;
            int left = 0;
            int right = nums.Length - 1;

            while (left <= right)
            {
                pivot = left + (right - left) / 2;
                if (nums[pivot] == target) return pivot;
                if (target < nums[pivot]) right = pivot - 1;
                else left = pivot + 1;
            }

            return left;
        }
    }
}

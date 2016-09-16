/*
 
 Given a collection of distinct numbers, return all possible permutations.

For example,
[1,2,3] have the following permutations:
[
  [1,2,3],
  [1,3,2],
  [2,1,3],
  [2,3,1],
  [3,1,2],
  [3,2,1]
]

https://leetcode.com/problems/permutations/

 */
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    class Permutations
    {
        bool IsSwapNeeded(int[] nums, int begin, int end)
        {
            int n = nums[end];
            for (int i = begin; i < end; i++)
            {
                if (nums[i] == n)
                    return false;
            }

            return true;
        }

        void swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }

        public void PermutationsArray(List<List<int>> numbers, int[] nums, int begin)
        {
            if (begin == nums.Length)
            {
                List<int> intarry = new List<int>(nums);
                numbers.Add(intarry);
            }
            else
            {
                for (int i = begin; i < nums.Length; i++)
                {
                    if (IsSwapNeeded(nums, begin, i))
                    {
                        swap(nums, i, begin);
                        PermutationsArray(numbers, nums, begin + 1);
                        swap(nums, i, begin);
                    }
                }
            }
        }

        public List<List<int>> PermuteUnique(int[] nums)
        {
            List<int> intarray = new List<int>(nums);
            List<List<int>> arraylist = new List<List<int>>();
           
            PermutationsArray(arraylist, nums, 0);

            return arraylist;
        }
    }

    [TestFixture]
    public class UTPermutations
    {
        [Test]
        public void TestPermutations()
        {
            int[] input = new int[] { 1, 2, 3 };

            var permutations = new Permutations();
            var result = permutations.PermuteUnique(input);

            //Assert.IsTrue(result[0] == 24);
            //Assert.IsTrue(result[1] == 12);
            //Assert.IsTrue(result[2] == 8);
            //Assert.IsTrue(result[3] == 6);
        }
    }
}

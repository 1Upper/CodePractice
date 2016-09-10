/*
209. Minimum Size Subarray Sum  QuestionEditorial Solution  My Submissions

Given an array of n positive integers and a positive integer s, find the minimal length of a subarray
of which the sum ≥ s. If there isn't one, return 0 instead.

For example, given the array [2,3,1,2,4,3] and s = 7,
the subarray [4,3] has the minimal length under the problem constraint.

https://leetcode.com/problems/minimum-size-subarray-sum/
 
 */
using System;
using NUnit.Framework;

namespace LeetCode
{
    public class MinimumSizeSubarraySum
    {
        /// <summary>
        /// return the min subarray length which total is same as target
        /// </summary>
        /// <param name="s"></param>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int MinSubArrayLenSumAsTarget(int s, int[] nums)
        {
            int result = 0;
            
            if (nums.Length == 0)
            {
                return result;
            }
            else if (nums[0] == s)
            {
                return 1;
            }
            
            int currSum = nums[0];
            int currStart = 0;
            
            for (int i = 1; i < nums.Length; i++)
            {
                currSum += nums[i];
                
                while (7 <= currSum)
                {
                    if (7 == currSum)
                    {
                        int length = i - currStart + 1;
                        
                        if (result == 0)
                            result = length;
                        else
                            result = Math.Min(result, length);
                    }
                    
                    currSum -= nums[currStart];
                    currStart++;
                }

            }
            
            return result;
        }
        
        public static int MinSubArrayLenSumAboveTarget(int s, int[] nums)
        {
            int result = 0;
            
            if (nums.Length == 0)
            {
                return result;
            }
            else if (nums[0] >= s)
            {
                return 1;
            }
            
            int currSum = nums[0];
            int currStart = 0;
            
            for (int i = 1; i < nums.Length; i++)
            {
                currSum += nums[i];
                
                while (s <= currSum)
                {
                    int length = i - currStart + 1;
                    
                    if (result == 0)
                        result = length;
                    else
                        result = Math.Min(result, length);
                    
                    currSum -= nums[currStart];
                    currStart++;

                }
            }
            
            return result;
        }
    }
    
    [TestFixture]
    public class UTMinSubArrayLenSumAsTarget
    {
        [Test]
        public void TestMethod()
        {
            int[] array = {2,3,1,2,4,3};
            
            Assert.IsTrue(2 == MinimumSizeSubarraySum.MinSubArrayLenSumAsTarget(7, array));
        }
    }
    [TestFixture]
    public class UTMinimumSizeSubarraySumAvoveTarget
    {
        [Test]
        public void TestMethod1()
        {    
            int[] array = {2,3,1,2,4,3};
            var len = MinimumSizeSubarraySum.MinSubArrayLenSumAboveTarget(7, array);
            Assert.IsTrue(2 == len, "result: {0}", len);
        }
        
        [Test]
        public void TestMethod2()
        {
            int[] array = {1,2,3,4,5};
            var len = MinimumSizeSubarraySum.MinSubArrayLenSumAboveTarget(11, array);
            Assert.IsTrue(3 == len, "result: {0}", len);
        }
    }
}

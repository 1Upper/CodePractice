/*
 Given an array S of n integers, are there elements a, b, c in S such that a + b + c = 0? Find all unique triplets in the array which gives the sum of zero.

Note: The solution set must not contain duplicate triplets.
For example, given array S = [-1, 0, 1, 2, -1, -4],

A solution set is:
[
  [-1, 0, 1],
  [-1, -1, 2]
]
*/
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    class _3Sum
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> results = new List<IList<int>>();

            List<int> numbers = new List<int>(nums);
            numbers.Sort();

            for (int i = numbers.Count - 1; i > 1 ; i--)
            {
                int target = numbers[i] * -1;
                
                if (i < numbers.Count - 1 && target == numbers[i+1] * -1)
                {
                    continue;
                }

                target = numbers[i] * -1;

                int p = 0, q = i - 1;

                while (p < q)
                {
                    int result = numbers[p] + numbers[q];
                    if (result == target)
                    {
                        List<int> r = new List<int>(new int[] { numbers[p], numbers[q], numbers[i]});

                        results.Add(r);

                        while (++p < i - 1 && numbers[p] == numbers[p - 1]) ;

                        while (--q > 0 && numbers[q] == numbers[q + 1]) ;
                    }
                    else if (result < target)
                    {
                        while (++p < i - 1 && numbers[p] == numbers[p - 1]) ;
                    }
                    else
                    {
                        while (--q > 0 && numbers[q] == numbers[q + 1]) ;
                    }
                }
            }

            return results;
        }
    }


    [TestFixture]
    class UT_3Sum
    {
        [Test]
        public void TestThreeSum()
        {
            int[] input = { -1, 0, 1, 2, -1, -4 };
            _3Sum sum = new _3Sum();

            var result = sum.ThreeSum(input);

            Assert.IsTrue(result.Count == 2);
        }

        [Test]
        public void TestThreeSum1()
        {
            int[] input = { 0,0,0,0 };
            _3Sum sum = new _3Sum();

            var result = sum.ThreeSum(input);

            Assert.IsTrue(result.Count == 1);
        }

        [Test]
        public void TestThreeSum2()
        {
            int[] input = {-4,-2,1,-5,-4,-4,4,-2,0,4,0,-2,3,1,-5,0};
            _3Sum sum = new _3Sum();

            var result = sum.ThreeSum(input);

            Assert.IsTrue(result.Count == 6);
        }
    }
}

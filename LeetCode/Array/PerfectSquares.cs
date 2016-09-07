/*
Given a positive integer n, find the least number of perfect square numbers
(for example, 1, 4, 9, 16, ...) which sum to n.
For example:
given n = 12, return 3 because 12 = 4 + 4 + 4;
given n = 13, return 2 because 13 = 4 + 9.

From <https://leetcode.com/problems/perfect-squares/>
 */

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace LeetCode
{
    public class PerfectSquares
    {
        public static int GetPerfectSquares(int n)
        {
            if (n <= 0)
            {
                return 0;
            }
            
            // cntPerfectSquares[i] = the least number of perfect square numbers
            // which sum to i. Note that cntPerfectSquares[0] is 0.
            int[] cntPerfectSquares = new int[n+1];
            
            for (int i = 0; i < cntPerfectSquares.Length; i++) {
                cntPerfectSquares[i] = int.MaxValue;
            } 
            
            cntPerfectSquares[0] = 0;
            
            for (int i = 1; i <= n; i++)
            {
                // For each i, it must be the sum of some number (i - j*j) and
                // a perfect square number (j*j).
                for (int j = 1; j*j <= i; j++)
                {
                    cntPerfectSquares[i] =
                        Math.Min(cntPerfectSquares[i], cntPerfectSquares[i - j*j] + 1);
                }
            }
            
            return cntPerfectSquares[n];

        }
    }
    
    [TestFixture]
    public class UTPerfectSquares
    {
        [Test]
        public void TestFunctionWith13()
        {
            int cnt  = PerfectSquares.GetPerfectSquares(13);
            Assert.IsTrue(cnt == 2, "cnt is {0}", cnt);
        }
    }
}

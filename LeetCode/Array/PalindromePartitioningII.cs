/*
 Given a string s, partition s such that every substring of the partition is a palindrome.

Return the minimum cuts needed for a palindrome partitioning of s.

For example, given s = "aab",
Return 1 since the palindrome partitioning ["aa","b"] could be produced using 1 cut.
https://leetcode.com/problems/palindrome-partitioning-ii/
*/
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Array
{
    class PalindromePartitioningII
    {
        public static int MinCut(string s)
        {
            int n = s.Length;

            bool[,] dp = new bool[n,n];
            int[] cut = new int[n];

            for (int j = 0; j < n; j++)
            {
                cut[j] = j; //set maximum # of cut
                for (int i = 0; i <= j; i++)
                {
                    if (s[i] == s[j] && (j - i <= 1 || dp[i + 1,j - 1]))
                    {
                        dp[i,j] = true;

                        // if need to cut, add 1 to the previous cut[i-1]
                        if (i > 0)
                        {
                            cut[j] = Math.Min(cut[j], cut[i - 1] + 1);
                        }
                        else
                        {
                            // if [0...j] is palindrome, no need to cut    
                            cut[j] = 0;
                        }
                    }
                }
            }

            return cut[n - 1];
        }
    }

    [TestFixture]
    public class UTPalindromePartitioningII
    {
        [Test]
        public void TestPalindromePartitioningII()
        {
            string input = "aab";
            int nCut = PalindromePartitioningII.MinCut(input);

            Assert.IsTrue(nCut == 1);

        }
    }
}

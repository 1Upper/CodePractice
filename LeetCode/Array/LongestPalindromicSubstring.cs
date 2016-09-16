/*
 Given a string S, find the longest palindromic substring in S. You may assume that the maximum length of S is 1000, and there exists one unique longest palindromic substring.

From <https://oj.leetcode.com/problems/longest-palindromic-substring/> 

 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Array
{
    class LongestPalindromicSubstring
    {
        public string PreProcess(string s)
        {
            string result = string.Empty;

            result += "^";

            foreach (char c in s)
            {
                result += c;
                result += "#";
            }

            result += "$";

            return result;
        }

        public string LongestPalindrome(string s)
        {
            if (s.Length <= 1)
            {
                return s;
            }

            string processedString = PreProcess(s);

            int[] p = new int[processedString.Length];
            int mx = 0, id = 0;

            for (int i = 0; i<processedString.Length; i++)
            {
                p[i] = mx > i ? Math.Min(p[2 * id - i], mx - i) : 1;
                while (s[i + p[i]] == s[i - p[i]]) p[i]++;
                if (i + p[i] > mx)
                {
                    mx = i + p[i];
                    id = i;
                }
            }

            // Find the maximum element in P.
            int maxLen = 0;
            int centerIndex = 0;
            for (int i = 1; i < processedString.Length - 1; i++)
            {
                if (p[i] > maxLen)
                {
                    maxLen = p[i];
                    centerIndex = i;
                }
            }

            return s.Substring((centerIndex - 1 - maxLen) / 2, maxLen);
        }
    }
}

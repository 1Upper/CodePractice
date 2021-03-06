﻿/*
 [Need more work ]
 Given a string S and a string T, find the minimum window in S which will contain all the characters in T in complexity O(n).

For example,
S = "ADOBECODEBANC"
T = "ABC"
Minimum window is "BANC".

Note:
If there is no such window in S that covers all characters in T, return the empty string "".

If there are multiple such windows, you are guaranteed that there will always be only one unique minimum window in S.


 */
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    public class MinimumWindowSubstring
    {
        public static string MinWindow(string s, string t)
        {
            if (t.Length> s.Length)
                return "";
            string result = "";

            //character counter for t
            Dictionary<char, int> target = new Dictionary<char, int>();
            for (int i = 0; i < t.Length; i++)
            {
                char c = t[i];
                if (target.ContainsKey(c))
                {
                    target[c] = target[c] + 1;
                }
                else
                {
                    target[c] = 1;
                }
            }

            // character counter for s
            Dictionary<char, int> map = new Dictionary<char, int>();
            int left = 0;
            int minLen = s.Length+ 1;

            int count = 0; // the total of mapped characters

            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];

                if (target.ContainsKey(c))
                {
                    if (map.ContainsKey(c))
                    {
                        if (map[c] < target[c])
                        {
                            count++;
                        }
                        map[c] = map[c] + 1;
                    }
                    else
                    {
                        map[c] = 1;
                        count++;
                    }
                }

                if (count == t.Length)
                {
                    char sc = s[left];

                    // Check if the left most char of substring has another instance in current string
                    while (!map.ContainsKey(sc) || map[sc] > target[sc])
                    {
                        // Move away from current left most char and
                        // find the next matching char in targeted string
                        if (map.ContainsKey(sc) && map[sc] > target[sc])
                        {
                            map[sc]--;
                        }

                        left++;
                        sc = s[left];
                    }

                    // Calculate the substring and its length
                    if (i - left + 1 < minLen)
                    {
                        minLen = i - left + 1;
                        result = s.Substring(left, minLen);
                    }
                }
            }

            return result;
        }
    }

    [TestFixture]
    public class UTMinimumWindowSubstring
    {
        [Test]
        public void TestMinimumWindowSubstring()
        {
            string input = "helloe";
            string target = "eo";

            var result = MinimumWindowSubstring.MinWindow(input, target);
            Assert.IsTrue(result == "oe");
        }
    }
}

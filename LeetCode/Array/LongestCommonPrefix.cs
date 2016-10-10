/*
 Longest Common Prefix  QuestionEditorial Solution  My Submissions
Total Accepted: 126566
Total Submissions: 423802
Difficulty: Easy
Write a function to find the longest common prefix string amongst an array of strings.

Subscribe to see which companies asked this question
 */
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    class GetLongestCommonPrefix
    {
        public string LongestCommonPrefix(string[] strs)
        {

            string result = string.Empty;
            char ch = '\n';
            int pos = 0;

            if (strs.Length == 0)
            {
                return string.Empty;
            }
            else if (strs.Length == 1)
            {
                return strs[0];
            }

            // check every char 
            while (pos < strs[0].Length)
            {
                for (int i = 0; i < strs.Length; i++)
                {
                    if (i == 0)
                    {
                        if (strs[i].Length > pos)
                        {
                            ch = strs[i][pos];
                        }
                        else
                        {
                            return result;
                        }
                    }
                    else if (strs[i].Length <= pos || strs[i][pos] != ch)
                    {
                        return result;
                    }

                    if (i == strs.Length - 1)
                    {
                        result += ch;
                    }
                }
                pos++;
            }

            return result;
        }
    }

    [TestFixture]
    public class UTGetLongestCommonPrefix
    {
        [Test]
        public void TestLongestCommonPrefix()
        {
            GetLongestCommonPrefix p = new GetLongestCommonPrefix();

            string[] input = { "aa", "aa" };

            string result = p.LongestCommonPrefix(input);
            Assert.IsTrue(result == "aa");
        }
    }
}

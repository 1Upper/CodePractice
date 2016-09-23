/*
 Implement regular expression matching with support for '.' and '*'.

'.' Matches any single character.
'*' Matches zero or more of the preceding element.

The matching should cover the entire input string (not partial).

The function prototype should be:
bool isMatch(const char *s, const char *p)

Some examples:
isMatch("aa","a") return false
isMatch("aa","aa") return true
isMatch("aaa","aa") return false
isMatch("aa", "a*") return true
isMatch("aa", ".*") return true
isMatch("ab", ".*") return true
isMatch("aab", "c*a*b") return true

1. Analysis

First of all, this is one of the most difficulty problems. It is hard to think through all different cases. The problem should be simplified to handle 2 basic cases:

the second char of pattern is "*"
the second char of pattern is not "*"
For the 1st case, if the first char of pattern is not ".", the first char of pattern and string should be the same. Then continue to match the remaining part.

For the 2nd case, if the first char of pattern is "." or first char of pattern == the first i char of string, continue to match the remaining part.
 https://leetcode.com/submissions/detail/75487720/
 */
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    class RegularExpressionMatching
    {
        public static bool IsMatch(string s, string p)
        {
            if (p.Length == 0)
            {
                return (s.Length == 0);
            }
            else if (p.Length == 1 || p[1] != '*')
            {
                if (s.Length == 0 || p[0] != '.' && s[0] != p[0])
                {
                    return false;
                }

                return IsMatch(s.Substring(1), p.Substring(1));
            }
            else
            {
                int len = s.Length;

                int i = -1;
                while (i < len && (i < 0 || p[0] == '.' || p[0] == s[i]))
                {
                    if (IsMatch(s.Substring(i + 1), p.Substring(2)))
                        return true;
                    i++;
                }
                return false;
            }
        }
    }

    [TestFixture]
    public class UTRegularExpressionMatching
    {
        [Test]
        public void TestRegularExpressionMatching()
        {
            Assert.IsTrue(RegularExpressionMatching.IsMatch("aa", "a") == false);
            Assert.IsTrue(RegularExpressionMatching.IsMatch("aa", "aa") == true);
            Assert.IsTrue(RegularExpressionMatching.IsMatch("aaa", "aa") == false);
            Assert.IsTrue(RegularExpressionMatching.IsMatch("aa", "a*") == true);
            Assert.IsTrue(RegularExpressionMatching.IsMatch("ab", ".*") == true);
            Assert.IsTrue(RegularExpressionMatching.IsMatch("aab", "c*a*b") == true);
        }
    }
}

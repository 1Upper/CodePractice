/*
 44. Wildcard Matching   QuestionEditorial Solution  My Submissions
Total Accepted: 72754
Total Submissions: 391586
Difficulty: Hard
Contributors: Admin
Implement wildcard pattern matching with support for '?' and '*'.

'?' Matches any single character.
'*' Matches any sequence of characters (including the empty sequence).

The matching should cover the entire input string (not partial).

The function prototype should be:
bool isMatch(const char *s, const char *p)

Some examples:
isMatch("aa","a") → false
isMatch("aa","aa") → true
isMatch("aaa","aa") → false
isMatch("aa", "*") → true
isMatch("aa", "a*") → true
isMatch("ab", "?*") → true
isMatch("aab", "c*a*b") → false


[a]  [a  b] [c]
[a]  [ *  ] [c] 

*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    class WildcardMatching
    {
        public static bool IsMatch(string s, string p)
        {
            int i = 0; // position in s
            int j = 0; // position in p

            int starIndex = -1;
            int iIndex = -1;

            while (i < s.Length)
            {
                if (j < p.Length && (p[j] == '?' || p[j] == s[i]))
                {
                    // 一个字符的正常匹配
                    ++i;
                    ++j;
                }
                else if (j < p.Length && p[j] == '*')
                {
                    // *的匹配,用startIndex记录*的位置， 用iIndex记录当前字符的位置
                    starIndex = j;
                    iIndex = i;

                    // 继续扫描下一个匹配字符， 因为*可以是很多，也可以是没有
                    j++;
                }
                else if (starIndex != -1)
                {
                    // 扫描到*后的匹配字符，而且是一个正常的字符
                    j = starIndex + 1;
                    i = iIndex + 1;
                    iIndex++;
                }
                else
                {
                    return false;
                }
            }

            while (j < p.Length && p[j] == '*')
            {
                ++j;
            }

            return j == p.Length;
        }
    }
}

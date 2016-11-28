/*
 32. Longest Valid Parentheses   Add to List QuestionEditorial Solution  My Submissions
Total Accepted: 80027
Total Submissions: 347638
Difficulty: Hard
Contributors: Admin
Given a string containing just the characters '(' and ')', find the length of the longest valid (well-formed) parentheses substring.

For "(()", the longest valid parentheses substring is "()", which has length = 2.

Another example is ")()())", where the longest valid parentheses substring is "()()", which has length = 4.

Subscribe to see which companies asked this question

https://leetcode.com/problems/longest-valid-parentheses/

解题思路： 首先考虑最基本的匹配原则，一个正常的组合，应该是 ( 和 ) 数量相同，并且leading with (. 进一步考虑，除了数量相同，在这个字符串的任何位置
‘(’的数量都应该不小于 ‘)’的数量。如果出现列外，那么这个字符串应该算作无效。 
例如  ((()()()())) 符合条件   (())) 不符合条件
根据这个原则，可以在程序中，统计出现的 次数，当发现不符合条件时，立刻停下来，计算已经发现字符串的长度

困难的地方是最后 字符串没有了， 但是队列中的 number of '(' > number of ')' 例如 ((((((  或者 ()()((), 着这种情况下，我们可以从右向左检查它的有效substring。
注意，从左向右检查，会难以判断结束‘)‘的位置
*/
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    class LongestValidParentheses
    {
        public int GetLongestValidParentheses(string s)
        {
            Stack<char> stack = new Stack<char>();
            int len = 0;
            int cLeft = 0;
            int cRight = 0;

            // step 1, 根据数量和规则统计
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];

                if (c == '(')
                {
                    stack.Push(c);

                    cLeft++;
                }
                else if (c == ')')
                {
                    if (cRight + 1 > cLeft)
                    {
                        len = Math.Max(len, stack.Count);

                        //reset
                        stack.Clear();
                        cLeft = 0;
                        cRight = 0;

                        continue;
                    }
                    else
                    {
                        stack.Push(c);
                        cRight++;
                    }
                }
            }

            if (cLeft == cRight)
            {
                return Math.Max(len, cLeft + cRight);
            }

            int  crLeft = 0;
            int crRight = 0;

            while (stack.Count > 0)
            {
                char c = stack.Pop();
                if (c == ')')
                {
                    crRight++;
                }
                else if (c == '(')
                {
                    if (crLeft + 1 > crRight)
                    {
                        len = Math.Max(len, crLeft + crRight);
                        crLeft = 0;
                        crRight = 0;
                    }
                    else
                    {
                        crLeft++;
                    }
                }
            }

            if (crLeft == crRight)
            {
                return Math.Max(len, crLeft + crRight);
            }

            return len;
        }
    }



    [TestFixture]
    class UTLongestValidParentheses
    {
        [Test]
        public void TestGetLongestValidParentheses1()
        {
            string a = "(()";
            LongestValidParentheses testObject = new LongestValidParentheses();

            Assert.AreEqual(testObject.GetLongestValidParentheses(a), 2);
        }

        [Test]
        public void TestGetLongestValidParentheses2()
        {
            string a = "(())";
            LongestValidParentheses testObject = new LongestValidParentheses();

            Assert.AreEqual(testObject.GetLongestValidParentheses(a), 4);
        }

        [Test]
        public void TestGetLongestValidParentheses3()
        {
            string a = "(((())))))";
            LongestValidParentheses testObject = new LongestValidParentheses();

            Assert.AreEqual(testObject.GetLongestValidParentheses(a), 8);
        }
    }
}

/*
 20. Valid Parentheses  
Question
Editorial Solution 
My Submissions 

Total Accepted: 140613
Total Submissions: 449829
Difficulty: Easy
Contributors: Admin 

Given a string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
The brackets must close in the correct order, "()" and "()[]{}" are all valid but "(]" and "([)]" are not.

Subscribe to see which companies asked this question
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace LeetCode.Array
{
    class ValidParentheses
    {
        public bool IsValid(string s)
        {
            Stack<char> q = new Stack<char>();

            foreach (var ch in s)
            {
                if (ch == '(' || ch == '{' || ch == '[')
                {
                    q.Push(ch);
                }
                else if (ch == ')')
                {
                    if (q.Count==0 || q.Pop() != '(') return false;
                }
                else if (ch == '}')
                {
                    if (q.Count == 0 || q.Pop() != '{') return false;
                }
                else if (ch == ']')
                {
                    if (q.Count == 0 || q.Pop() != '[') return false;
                }
            }

            return q.Count == 0;
        }
    }

    [TestFixture]
    class TestvalidParentheses
    {
        [Test]
        public void TestIsValid()
        {
            string c = "(({{[[]]}}))";
            ValidParentheses vp = new ValidParentheses();
            Assert.IsTrue(vp.IsValid(c));
        }
    }
}

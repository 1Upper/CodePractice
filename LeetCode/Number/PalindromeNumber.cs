/*
 * https://leetcode.com/problems/palindrome-number/
 */

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    class PalindromeNumber
    {
        public bool IsPalindrome(int x)
        {
            if (x < 0) return false;
            else if (x < 10) return true;

            int n = x;
            int rev = 0;

            while (n > 0)
            {
                int g = n % 10;
                rev = rev * 10 + g;
                n /= 10;
            }

            return rev == x;
        }
    }

    [TestFixture]
    public class UTPalindromeNumber
    {
        [Test]
        public void TestPalindromeNumber()
        {
            PalindromeNumber p = new PalindromeNumber();

            Assert.IsTrue(p.IsPalindrome(1));
            Assert.IsTrue(p.IsPalindrome(11));
            Assert.IsTrue(p.IsPalindrome(121));
            Assert.IsFalse(p.IsPalindrome(1231));
            Assert.IsTrue(p.IsPalindrome(1001));
        }
    }
}


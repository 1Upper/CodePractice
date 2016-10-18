/*
 LeetCode – Divide Two Integers (Java)
 
Divide two integers without using multiplication, division and mod operator. If it is overflow, return MAX_INT.

Analysis

This problem can be solved based on the fact that any number can be converted to the format of the following:

num=a_0*2^0+a_1*2^1+a_2*2^2+...+a_n*2^n
The time complexity is O(logn).
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace LeetCode.Number
{
    class DivideTwoIntegers
    {
        public int Divide(int dividend, int divisor)
        {
            if (divisor == 0) return int.MinValue;
            if (divisor == -1 && dividend == int.MinValue) return int.MaxValue;

            Int64 pDividend = Math.Abs((Int64)dividend);
            Int64 pDivisor = Math.Abs((Int64)divisor);

            int result = 0;

            while (pDividend >= pDivisor)
            {
                int numShift = 0;
                while (pDividend >= (pDivisor << numShift))
                {
                    numShift++;
                }

                result += 1 << (numShift - 1);
                pDividend -= pDivisor << (numShift - 1);
            }

            if ((dividend >= 0 && divisor >= 0) || (dividend < 0 && divisor < 0))
            {
                return result;
            }
            else
            {
                return -result;
            }
        }
    }

    [TestFixture]
    class TestDivideTwoIntegers
    {
        [Test]
        public void UTDivideTwoIntegers()
        {
            DivideTwoIntegers d = new DivideTwoIntegers();
            int result = d.Divide(1, -1);
            Assert.IsTrue(result == -1);
        }
    }
}

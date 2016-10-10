/*
 Given two numbers represented as strings, return multiplication of the numbers as a string.

Analysis

The key to solve this problem is multiplying each digit of the numbers at the corresponding positions and
get the sum values at each position. That is how we do multiplication manually.
 */
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    class MultiplyStrings
    {
        public static string Multiply(string num1, string num2)
        {
            var n1 = num1.Reverse().ToArray();
            var n2 = num2.Reverse().ToArray();

            int[] numbers = new int[n1.Length + n2.Length];

            for (int i = 0; i < n1.Length; i++)
            {
                for (int j = 0; j < n2.Length; j++)
                {
                    numbers[i + j] += (n1[i] - '0') * (n2[j] - '0');
                }
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < numbers.Length; i++)
            {
                int m = numbers[i] % 10;
                int c = numbers[i] / 10;

                if (i + 1 < numbers.Length)
                    numbers[i + 1] += c;
                sb.Insert(0, m);
            }

            while (sb[0] == '0' && sb.Length > 1)
                sb.Remove(0, 1);

            return sb.ToString();
        }
    }

    [TestFixture]
    public class UTMultiplyStrings
    {
        [Test]
        public void TestMultiplyStrings()
        {
            var result = MultiplyStrings.Multiply("0", "0");

            Assert.IsTrue(result == "0");
        }
    }
}

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    public class ZigZagConversion
    {
        public static string Convert(string s, int numRows)
        {
            if (numRows == 1)
                return s;

            string[] strs = new string[numRows];

            int col = 0;
            int index = 0;

            while (index < s.Length)
            {
                if (col % (numRows - 1) == 0)
                {
                    for (int i = 0; i < strs.Length && index < s.Length; i++, index++)
                    {
                        strs[i] += s[index];
                    }
                }
                else
                {
                    strs[numRows - 1 - col % (numRows - 1)] += s[index++];
                }

                col++;
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < strs.Length; i++)
            {
                sb.Append(strs[i]);
            }

            return sb.ToString();
        }
    }

    [TestFixture]
    public class UTZigZagConversion
    {
        [Test]
        public void TestZigZagConversion()
        {
            string input = "PAYPALISHIRING";
            var result = ZigZagConversion.Convert(input, 3);

            Assert.IsTrue(result == "PAHNAPLSIIGYIR");
        }

        [Test]
        public void TestZigZagConversion1()
        {
            string input = "ABC";
            var result = ZigZagConversion.Convert(input, 2);

            Assert.IsTrue(result == "ACB");
        }
    }
}

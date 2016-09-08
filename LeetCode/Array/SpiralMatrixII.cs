/*
Given an integer n, generate a square matrix filled with elements from 1 to n2 in spiral order.

For example,
Given n = 3,

You should return the following matrix:
[
 [ 1, 2, 3 ],
 [ 8, 9, 4 ],
 [ 7, 6, 5 ]
]

https://leetcode.com/problems/spiral-matrix-ii/
*/
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    class SpiralMatrixII
    {
        public static int[,] GenerateMatrix(int n)
        {
            if (n<1)
            {
                return new int[0,0];
            }

            int[,] result = new int[n, n];

            int xStart = 0, xStop = n - 1;
            int yStart = 0, yStop = n - 1;
            int value = 1;

            while (xStart <= xStop && yStart <= yStop)
            {
                for (int i = yStart; i <= yStop; i++)
                {
                    result[xStart, i] = value++;
                }

                xStart++;

                if (xStart > xStop)
                {
                    break;
                }

                for (int i = xStart; i <= xStop; i++)
                {
                    result[i, yStop] = value++;
                }

                yStop--;

                if (yStart > yStop)
                {
                    break;
                }

                for (int i = yStop; i >= yStart; i--)
                {
                    result[xStop, i] = value++;
                }

                xStop--;

                if (xStart > xStop)
                {
                    break;
                }

                for (int i = xStop; i >= xStart; i--)
                {
                    result[i, yStart] = value++;
                }

                yStart++;

                if (yStart > yStop)
                {
                    break;
                }
            }

            return result;
        }
    }

    [TestFixture]
    class UTSpiralMatrixII
    {
        [Test]
        public void TestSpiralMatrixII()
        {
            var result = SpiralMatrixII.GenerateMatrix(3);

            int[,] exp = {
                { 1, 2, 3 },
                { 8, 9, 4 },
                { 7, 6, 5 },
            };

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Assert.IsTrue(result[i, j] == exp[i, j]);
                }
            }
        }
    }
}

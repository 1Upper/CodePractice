/*
Given a matrix of m x n elements (m rows, n columns), return all elements of the matrix in spiral order.

For example,
Given the following matrix:

[
 [ 1, 2, 3 ],
 [ 4, 5, 6 ],
 [ 7, 8, 9 ]
]
You should return [1,2,3,6,9,8,7,4,5].

URL: https://leetcode.com/problems/spiral-matrix/
*/

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterviewProject
{
    public class SpiralMatrix
    {
        public static IList<int> SpiralOrder(int[,] matrix)
        {
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);
            IList<int> result = new List<int>();

            if (row <= 0 || col <= 0)
            {
                return result;
            }

            int xStart = 0, xStop = row - 1;
            int yStart = 0, yStop = col - 1;

            while (xStart <= xStop && yStart <= yStop)
            {
                for (int i = yStart; i <= yStop; i++)
                {
                    result.Add(matrix[xStart, i]);
                }
                xStart ++;

                if (xStart > xStop) break;

                for (int i = xStart; i <= xStop; i++)
                {
                    result.Add(matrix[i, yStop]);
                }
                yStop--;

                if (yStart > yStop) break;

                for (int i = yStop; i >= yStart; i--)
                {
                    result.Add(matrix[xStop, i]);
                }
                xStop--;

                if (xStart > xStop) break;

                for (int i = xStop; i >= xStart; i--)
                {
                    result.Add(matrix[i, yStart]);
                }
                yStart++;

                if (yStart > yStop) break;
            }

            return result;
        }
    }

    [TestFixture]
    public class UTSpiralMatrix
    {
        [Test]
        public void TestSpiralMatrix()
        {
            int[,] input = {
                 { 1, 2, 3 }, 
                 { 4, 5, 6 }, 
                 { 7, 8, 9 }
            };

            var list = SpiralMatrix.SpiralOrder(input);

            string exp = "123698745";

            for (int i = 0; i< exp.Length; i++)
            {
                Assert.IsTrue(list[i] == int.Parse(exp[i].ToString()));
            }
        }

        [Test]
        public void TestSpiralMatrix2()
        {
            int[,] input = {
                 { 1, 2},
            };

            var list = SpiralMatrix.SpiralOrder(input);

            string exp = "12";

            for (int i = 0; i < exp.Length; i++)
            {
                Assert.IsTrue(list[i] == int.Parse(exp[i].ToString()));
            }

            Assert.IsTrue(list.Count == exp.Length);
        }


        [Test]
        public void TestSpiralMatrix3()
        {
            int[,] input = {
                 { 2, 3},
            };

            var list = SpiralMatrix.SpiralOrder(input);

            string exp = "23";

            for (int i = 0; i < exp.Length; i++)
            {
                Assert.IsTrue(list[i] == int.Parse(exp[i].ToString()));
            }

            Assert.IsTrue(list.Count == exp.Length);
        }

    }
}

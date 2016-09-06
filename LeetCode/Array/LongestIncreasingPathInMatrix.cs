/*
 Given an integer matrix, find the length of the longest increasing path. From each cell, you can either move to four directions: 
 left, right, up or down. You may NOT move diagonally or move outside of the boundary (i.e. wrap-around is not allowed).

Example 1:
nums = [
[9,9,4],
[6,6,8],
[2,1,1]
]

Return 4
The longest increasing path is [1, 2, 6, 9].

Example 2:
nums = [
[3,4,5],
[3,2,6],
[2,2,1]
]

Return 4
The longest increasing path is [3, 4, 5, 6]. Moving diagonally is not allowed.
 */
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterviewProject.Array
{
    public class LongestIncreasingPathInMatrix
    {
        public static int GetLongestIncreasingPath(int[,] matrix)
        {
            int max = 0;
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (rows <= 0 || cols <= 0)
            {
                return 0;
            }

            // Remember the intermediate searching result for each cell
            int[,] cache = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    max = Math.Max(max, maxLen(matrix, Int32.MinValue, i, j, cache));
                }
            }

            return max;
        }

        /// <summary>
        /// Using DFS - depth first search
        /// memorization - use cache array to store the result
        ///  checkpoints:
        ///  1. Run time problem - array out of index
        ///  2. Value - wrong value
        ///  3. logic checking 
        ///  4. memorization - remove duplication calculation
        /// </summary>
        /// <param name="matrix">targeted matrix</param>
        /// <param name="nodeValue">previous node's value - so, it is minimum value to compare</param>
        /// <param name="startX">X position to start</param>
        /// <param name="startY">Y position to start</param>
        /// <param name="cache">matrix to cache the intermediate result</param>
        /// <returns></returns>
        public static int maxLen(int[,] matrix, int nodeValue, int startX, int startY, int[,] cache)
        {
            // base cases: 
            if (startX < 0 ||
                startY < 0 ||
                startX >= matrix.GetLength(0) ||
                startY >= matrix.GetLength(1))
            {
                return 0;
            }

            // increasing path - next node should be bigger value 
            if (matrix[startX, startY] <= nodeValue)
            {
                return 0;
            }

            // memorization 
            if (cache[startX,startY] != 0)
            {
                return cache[startX,startY];
            }

            nodeValue = matrix[startX, startY];

            // Four neighbors - left, right, up, down 
            int[][] neighbors = new int[4][]{
                new int[2]{-1, 0},
                new int[2]{0, -1},
                new int[2]{0, 1},
                new int[2]{1, 0}
            };

            // get maximum value from 4 neighbors 
            int maxValue = 0;
            for (int i = 0; i < neighbors.Length; i++)
            {
                int nextX = startX + neighbors[i][0];
                int nextY = startY + neighbors[i][1];

                // Value increments by one for current 
                maxValue = Math.Max(maxValue, maxLen(matrix, nodeValue, nextX, nextY, cache) + 1);
            }

            cache[startX,startY] = maxValue;

            return cache[startX,startY];
        }
    }

    [TestFixture]
    public class UTLongestIncreasingPathInMatrix
    {
        [Test]
        public void TestLongestIncreasingPathInMatrix1()
        {
            int[,] input = {
                { 9, 9, 4 },
                { 6, 6, 8 },
                { 2, 1, 1 }
            };

            var length = LongestIncreasingPathInMatrix.GetLongestIncreasingPath(input);

            Assert.IsTrue(length == 4);
        }

        [Test]
        public void TestLongestIncreasingPathInMatrix2()
        {
            int[,] input = {
                { 3,4,5 },
                { 3,2,6 },
                { 2,2,1 }
            };

            var length = LongestIncreasingPathInMatrix.GetLongestIncreasingPath(input);

            Assert.IsTrue(length == 4);
        }
    }
}

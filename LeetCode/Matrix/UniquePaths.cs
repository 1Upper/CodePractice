/*
 Unique Paths  QuestionEditorial Solution  My Submissions

 A robot is located at the top-left corner of a m x n grid (marked 'Start' in the diagram below).

The robot can only move either down or right at any point in time. The robot is trying to reach the bottom-right corner of the grid (marked 'Finish' in the diagram below).

How many possible unique paths are there?
https://leetcode.com/problems/unique-paths/
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Matrix
{
    class UniquePaths
    {
        public int GetUniquePaths(int m, int n)
        {
            if (m==0 || n==0)
            {
                return 0;
            }

            if (m == 1 || n == 1)
            {
                return 1;
            }

            int[,] matrix = new int[m, n];

            for (int i = 0; i < m; i++)
            {
                matrix[i, 0] = 1;
            }

            for (int j = 0; j < n; j++)
            {
                matrix[0, j] = 1;
            }

            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    matrix[i, j] = matrix[i - 1, j] + matrix[i, j - 1];
                }
            }

            return matrix[m -1, n -1];
        }
    }
}

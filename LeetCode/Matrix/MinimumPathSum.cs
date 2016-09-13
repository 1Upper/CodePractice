/*
 64. Minimum Path Sum  QuestionEditorial Solution  My Submissions

 Given a m x n grid filled with non-negative numbers, find a path from top left to bottom 
 right which minimizes the sum of all numbers along its path.

 Note: You can only move either down or right at any point in time.

 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Matrix
{
    public class MinimumPathSum
    {
        public int GetMinPathSum(int[,] grid)
        {
            int row = grid.GetLength(0);
            int col = grid.GetLength(1);

            if (row == 0 || col == 0)
            {
                return 0;
            }

            int[,] sums = new int[row, col];
            sums[0, 0] = grid[0, 0];

            for (int i = 1; i < row; i++)
            {
                sums[i, 0] += sums[i - 1, 0] + grid[i, 0];
            }

            for (int j = 1; j < col; j++)
            {
                sums[0, j] += sums[0, j - 1] + grid[0, j];
            }

            for (int i = 1; i < row; i++)
            {
                for (int j = 1; j < col; j++)
                {
                    sums[i, j] = Math.Min(sums[i - 1, j], sums[i, j - 1]) + grid[i, j];
                }
            }

            return sums[row - 1, col - 1];
        }
    }
}

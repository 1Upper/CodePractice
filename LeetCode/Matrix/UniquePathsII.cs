/*
 63. Unique Paths II  QuestionEditorial Solution 

Now consider if some obstacles are added to the grids. How many unique paths would there be?

An obstacle and empty space is marked as 1 and 0 respectively in the grid.

For example,
There is one obstacle in the middle of a 3x3 grid as illustrated below.

[
  [0,0,0],
  [0,1,0],
  [0,0,0]
]
The total number of unique paths is 2.

Note: m and n will be at most 100.

https://leetcode.com/problems/unique-paths-ii/
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Matrix
{
    class UniquePathsII
    {
        public int UniquePathsWithObstacles(int[,] obstacleGrid)
        {
            int row = obstacleGrid.GetLength(0);
            int col = obstacleGrid.GetLength(1);

            if (obstacleGrid[0, 0] == 1 || obstacleGrid[row - 1, col - 1] == 1)
                return 0;

            int[,] matrix = new int[row, col];
            matrix[0, 0] = 1;

            for (int i = 1; i < row; i++)
            {
                matrix[i, 0] = (obstacleGrid[i, 0] == 1 || matrix[i - 1, 0] == 0) ? 0 : 1;
            }

            for (int j = 1; j < col; j++)
            {
                matrix[0, j] = (obstacleGrid[0, j] == 1 || matrix[0, j - 1] == 0) ? 0 : 1;
            }

            for (int i = 1; i < row; i++)
            {
                for (int j = 1; j < col; j++)
                {
                    matrix[i, j] = obstacleGrid[i, j] == 1 ? 0 : matrix[i - 1, j] + matrix[i, j - 1];
                }
            }

            return matrix[row - 1, col - 1];
        }
    }
}

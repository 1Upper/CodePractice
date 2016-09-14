/*
 74. Search a 2D Matrix  QuestionEditorial Solution  My Submissions

 Write an efficient algorithm that searches for a value in an m x n matrix. This matrix has the following properties:

Integers in each row are sorted from left to right.
The first integer of each row is greater than the last integer of the previous row.
For example,

Consider the following matrix:

[
  [1,   3,  5,  7],
  [10, 11, 16, 20],
  [23, 30, 34, 50]
]
Given target = 3, return true.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Matrix
{
    class Search2DMatrix
    {
        public bool SearchMatrix(int[,] matrix, int target)
        {
            int m = matrix.GetLength(0) - 1;
            int n = matrix.GetLength(1) - 1;

            int i = m;
            int j = 0;

            while (i >= 0 && j <= n)
            {
                if (target < matrix[i,j])
                {
                    i--;
                }
                else if (target > matrix[i,j])
                {
                    j++;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }
    }
}

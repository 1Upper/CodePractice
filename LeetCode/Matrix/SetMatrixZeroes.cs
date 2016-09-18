/*
 73. Set Matrix Zeroes  QuestionEditorial Solution  My Submissions

 Given a m x n matrix, if an element is 0, set its entire row and column to 0. 
Do it in place.

click to show follow up.

Follow up:
Did you use extra space?
A straight forward solution using O(mn) space is probably a bad idea.
A simple improvement uses O(m + n) space, but still not the best solution.
Could you devise a constant space solution?

Subscribe to see which companies asked this question
 https://leetcode.com/problems/set-matrix-zeroes/
 
  */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Matrix
{
    class SetMatrixZeroes
    {
        public void SetZeroes(int[,] matrix)
        {
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);
            bool xclear = false;
            bool yclear = false;


            for (int i = 0; i < row; i++)
            {
                if (matrix[i, 0] == 0)
                {
                    xclear = true;
                }
            }

            for (int i = 0; i < col; i++)
            {
                if (matrix[0, i] == 0)
                {
                    yclear = true;
                }
            }

            for (int i = 1; i < row; i++)
            {
                for (int j = 1; j < col; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        matrix[0, j] = 0;
                        matrix[i, 0] = 0;
                    }
                }
            }

            for (int i = 1; i < row; i++)
            {
                if (matrix[i, 0] == 0)
                {
                    for (int j = 0; j < col; j++)
                    {
                        matrix[i, j] = 0;
                    }
                }
            }

            for (int i = 1; i < col; i++)
            {
                if (matrix[0, i] == 0)
                {
                    for (int j = 1; j < row; j++)
                    {
                        matrix[j, i] = 0;
                    }
                }
            }

            if (xclear)
            {
                for (int i = 0; i < row; i++)
                {
                    matrix[i, 0] = 0;
                }
            }

            if (yclear)
            {
                for (int i = 0; i < col; i++)
                {
                    matrix[0, i] = 0;
                }
            }

        }
    }
}

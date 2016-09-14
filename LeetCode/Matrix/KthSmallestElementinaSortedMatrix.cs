/*
 Given a n x n matrix where each of the rows and columns are sorted in ascending order, find the kth smallest element in the matrix.

Note that it is the kth smallest element in the sorted order, not the kth distinct element.

Example:

matrix = [
   [ 1,  5,  9],
   [10, 11, 13],
   [12, 13, 15]
],
k = 8,

return 13.
Note: 
You may assume k is always valid, 1 ≤ k ≤ n2.

https://leetcode.com/problems/kth-smallest-element-in-a-sorted-matrix/

 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Matrix
{
    class KthSmallestElementinaSortedMatrix
    {
        public int SmallestNumber(int[,] matrix, int[] array)
        {
            int index = -1;
            int value = int.MaxValue;
            int length = matrix.GetLength(0);

            for (int i = 0; i < length; i++)
            {
                if (array[i] < length)
                {
                    if (value > matrix[i, array[i]])
                    {
                        value = matrix[i, array[i]];
                        index = i;
                    }
                }
            }

            if (index >= 0)
            {
                array[index] ++;
            }

            return value;
        }

        public int KthSmallest(int[,] matrix, int k)
        {
            int[] array = new int[matrix.GetLength(0)];
            int num = matrix[0,0];

            for (int i = 0; i < k; i++)
            {
                num = SmallestNumber(matrix, array);
            }

            return num;

        }
    }
}

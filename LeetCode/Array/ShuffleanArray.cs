/*
 Shuffle an Array

Shuffle a set of numbers without duplicates.

Example:
// Init an array with set 1, 2, and 3.
int[] nums = {1,2,3};
Solution solution = new Solution(nums);

// Shuffle the array [1,2,3] and return its result. Any permutation of [1,2,3]
// must equally likely to be returned.

solution.shuffle();

// Resets the array back to its original configuration [1,2,3].
solution.reset();

// Returns the random shuffling of array [1,2,3].
solution.shuffle();

https://leetcode.com/problems/shuffle-an-array/
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    class ShuffleanArray
    {
        private List<int> backup;
        ShuffleanArray(List<int> nums) 
        {
            backup = new List<int>();
            backup.AddRange(nums);
        }
        
        /** Resets the array to its original configuration and return it. */
        List<int> reset() {
            return backup;
        }
        
        /** Returns a random shuffling of the array. */
        List<int> shuffle() {
            Random rand = new Random();
            rand.Next();
            
            List<int> result = new List<int>(backup);
            for (int i = 0; i < result.Count; i++) 
            {
                int position = rand.Next(0,backup.Count - 1);
                int temp = result[i];
                result[i] = result[position];
                result[position] = temp;
            }
            
            return result;
        }
    }
}

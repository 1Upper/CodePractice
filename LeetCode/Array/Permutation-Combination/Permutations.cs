/*
 
 Given a collection of distinct numbers, return all possible permutations.

For example,
[1,2,3] have the following permutations:
[
  [1,2,3],
  [1,3,2],
  [2,1,3],
  [2,3,1],
  [3,1,2],
  [3,2,1]
]

思路：Permutations I

方法1：插入法

与subset I的方法2很相近。以题中例子说明：
当只有1时候：[1]
当加入2以后：[2, 1],                           [1, 2]
当加入3以后：[3, 2, 1], [2, 3, 1], [2, 1, 3],  [3, 1, 2], [1, 3, 2], [1, 2, 3]

前3个permutation分别对应将3插入[2, 1]的0, 1, 2的位置。同理后3个为插入[1, 2]的。因此可以用逐个插入数字来构造所有permutations。
class Solution {
public:
    vector<vector<int> > permute(vector<int> &num) {
        vector<vector<int>> allPer;
        if(num.empty()) return allPer;
        allPer.push_back(vector<int>(1,num[0]));
        
        for(int i=1; i<num.size(); i++) {
            int n = allPer.size();
            for(int j=0; j<n; j++) {
                for(int k=0; k<allPer[j].size(); k++) {
                    vector<int> per = allPer[j];
                    per.insert(per.begin()+k, num[i]);
                    allPer.push_back(per);
                }
                allPer[j].push_back(num[i]);
            }
        }
        return allPer;
    }
};

方法2：backtracking法

本质上，这个问题就是把 Nth 数字后的N-1个数字交换。所以，可以用递归的来解决

和combination/subset不同，数字不同的排列顺序算作不同的permutation。所以我们需要用一个辅助数组来记录当前递归层时，哪些数字已经在上层的递归使用过了。
数字不同的排列顺序算作不同的permutation。所以我们需要用一个辅助数组来记录当前递归层时，哪些数字已经在上层的递归使用过了。

https://leetcode.com/problems/permutations/

 */
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    class Permutations
    {
        bool IsSwapNeeded(int[] nums, int begin, int end)
        {
            int n = nums[end];
            for (int i = begin; i < end; i++)
            {
                if (nums[i] == n)
                    return false;
            }

            return true;
        }

        void swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }

        public void PermutationsArray(List<List<int>> numbers, int[] nums, int begin)
        {
            if (begin == nums.Length)
            {
                List<int> intarry = new List<int>(nums);
                numbers.Add(intarry);
            }
            else
            {
                for (int i = begin; i < nums.Length; i++)
                {
                    if (IsSwapNeeded(nums, begin, i))
                    {
                        swap(nums, i, begin);
                        PermutationsArray(numbers, nums, begin + 1);
                        swap(nums, i, begin);
                    }
                }
            }
        }

        public List<List<int>> PermuteUnique(int[] nums)
        {
            List<int> intarray = new List<int>(nums);
            List<List<int>> arraylist = new List<List<int>>();
           
            PermutationsArray(arraylist, nums, 0);

            return arraylist;
        }
    }

    [TestFixture]
    public class UTPermutations
    {
        [Test]
        public void TestPermutations()
        {
            int[] input = new int[] { 1, 2, 3 };

            var permutations = new Permutations();
            var result = permutations.PermuteUnique(input);

            //Assert.IsTrue(result[0] == 24);
            //Assert.IsTrue(result[1] == 12);
            //Assert.IsTrue(result[2] == 8);
            //Assert.IsTrue(result[3] == 6);
        }
    }
}

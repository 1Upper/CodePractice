/*
 22. Generate Parentheses   QuestionEditorial Solution  My Submissions
Total Accepted: 111432
Total Submissions: 276041
Difficulty: Medium
Contributors: Admin
Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.

For example, given n = 3, a solution set is:

[
  "((()))",
  "(()())",
  "(())()",
  "()(())",
  "()()()"
]

思路：

通过向string插入"("和")"直到两者的数量都为n，则一个combination构建完成。如何保证这个combination是well-formed？在插入过程中的任何时候：

1. 只要"("的数量没有超过n，都可以插入"("。
2. 而可以插入")"的前提则是当前的"("数量必须要多余当前的")"数量。
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    class GenerateParentheses
    {
        public IList<string> GetGenerateParenthesis(int n)
        {
            IList<string> results = new List<string>();
            int left = 0;
            int right = 0;
            Helper(results, "", left, right, n);

            return results;
        }

        public void Helper(IList<string> results, string result, int left, int right, int n)
        {
            if (result.Length == n*2)
            {
                results.Add(result);
            }

            if (left < n)
            {
                Helper(results, result + "(", left + 1, right, n);
            }

            if (right < left)
            {
                Helper(results, result + ")", left, right +1, n);
            }
        }
    }
}

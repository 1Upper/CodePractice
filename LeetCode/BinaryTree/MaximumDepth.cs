using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    class MaximumDepth
    {
        public int MaxDepth(TreeNode root)
        {
            if (root == null)
                return 0;

            int leftDepth = MaxDepth(root.left) + 1;

            int rightDepth = MaxDepth(root.right) + 1;

            return Math.Max(leftDepth, rightDepth);
        }
    }
}

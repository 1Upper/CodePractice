/*
Invert a binary tree.

     4
   /   \
  2     7
 / \   / \
1   3 6   9
to
     4
   /   \
  7     2
 / \   / \
9   6 3   1
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    class InvertBinaryTree
    {
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
            {
                return null;
            }

            InvertTree(root.left);
            InvertTree(root.right);

            var temp = root.left;
            root.left = root.right;
            root.right = temp;

            return root;
        }
    }
}

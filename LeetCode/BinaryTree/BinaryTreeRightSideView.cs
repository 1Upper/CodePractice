/*
Given a binary tree, imagine yourself standing on the right side of it, return the values of the nodes you can see ordered from top to bottom.
For example:
Given the following binary tree,
   1            <---
 /   \
2     3         <---
 \     \
  5     4       <---
You should return [1, 3, 4]. 
Credits:
Special thanks to @amrsaqr for adding this problem and creating all test cases.

From <https://leetcode.com/problems/binary-tree-right-side-view/> 
 */
using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace LeetCode
{
    public class BinaryTreeRightSideView
    {
        public static IList<int> RightSideView(TreeNode root) 
        {
            IList<int> rightSideNodesList = new List<int>();
            Queue<TreeNode> cache = new Queue<TreeNode>();

            if (root == null)
            {
                return rightSideNodesList;
            }
            else
            {
                cache.Enqueue(root);
            }

            while (cache.Count > 0)
            {
                int queueSize = cache.Count;

                for (int i = 0; i < queueSize; i++)
                {
                    var node = cache.Dequeue();

                    if (node.left != null)
                    {
                        cache.Enqueue(node.left);
                    }

                    if (node.right != null)
                    {
                        cache.Enqueue(node.right);
                    }

                    if (i == queueSize - 1)
                    {
                        rightSideNodesList.Add(node.val);
                    }
                }

            }
            
            return rightSideNodesList;
        }
    }
    
    [TestFixture]
    public class UTBinaryTreeRightSideView
    {
        [Test]
        public void TestBinaryTreeRightSideView()
        {
            TreeNode root = new TreeNode(1);
            TreeNode l1 = new TreeNode(2);
            TreeNode r1 = new TreeNode(3);
            TreeNode l2 = new TreeNode(5);
            TreeNode r2 = new TreeNode(4);

            root.left = l1;
            root.right = r1;
            l1.right = l2;
            r1.right = r2;

            var list = BinaryTreeRightSideView.RightSideView(root);
            int[] results = { 1, 3, 4 };

            for (int i = 0; i < 3; i++)
            {
                Assert.IsTrue(list[i] == results[i]);
            }

            Assert.IsTrue(list.Count == results.Length);
        }
    }
}

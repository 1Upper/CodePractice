/*
Given a binary tree, return all root-to-leaf paths. 
For example, given the following binary tree: 
   1
 /   \
2     3
 \
  5
All root-to-leaf paths are: 
["1->2->5", "1->3"]

From <https://leetcode.com/problems/binary-tree-paths/> 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace LeetCode
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }


    public class ListAllBinaryTreePath
    {
        public static IList<string> BinaryTreePaths(TreeNode root)
        {
            IList<string> paths = new List<string>();

            // if root is null, return an empty path list
            if (root == null)
            {
                return paths;
            }

            // left nodes
            IList<string> leftPaths = BinaryTreePaths(root.left);

            foreach (string s in leftPaths)
            {
                paths.Add(root.val.ToString() + "->" + s);
            }

            // right nodes
            IList<string> rightPaths = BinaryTreePaths(root.right);

            foreach (var s in rightPaths)
            {
                paths.Add(root.val.ToString() + "->" + s);
            }

            // root only
            if (paths.Count == 0)
            {
                paths.Add(root.val.ToString());
            }

            return paths;
        }
    }

    [TestFixture]
    public class UTListAllBinaryTreePath
    {
        [Test]
        public void ListNormalTree()
        {
            TreeNode root = new TreeNode(1);
            TreeNode l1 = new TreeNode(2);
            TreeNode r1 = new TreeNode(3);
            TreeNode l2 = new TreeNode(5);
            root.left = l1;
            root.right = r1;
            l1.right = l2;

            var List = ListAllBinaryTreePath.BinaryTreePaths(root);

            Assert.IsTrue(List[0] == "1->2->5");
            Assert.IsTrue(List[1] == "1->3");
        }
    }
}

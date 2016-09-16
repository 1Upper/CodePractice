/*
 331. Verify Preorder Serialization of a Binary Tree  QuestionEditorial Solution  My Submissions

One way to serialize a binary tree is to use pre-order traversal. When we encounter a non-null node, 
we record the node's value. If it is a null node, we record using a sentinel value such as #.

     _9_
    /   \
   3     2
  / \   / \
 4   1  #  6
/ \ / \   / \
# # # #   # #
For example, the above binary tree can be serialized to the string "9,3,4,#,#,1,#,#,2,#,6,#,#", where # represents a null node.

Given a string of comma separated values, verify whether it is a correct preorder traversal serialization of a binary tree. Find an algorithm without reconstructing the tree.

Each comma separated value in the string must be either an integer or a character '#' representing null pointer.

You may assume that the input format is always valid, for example it could never contain two consecutive commas such as "1,,3".

Example 1:
"9,3,4,#,#,1,#,#,2,#,6,#,#"
Return true

Example 2:
"1,#"
Return false

Example 3:
"9,#,#,1"
Return false

https://leetcode.com/problems/verify-preorder-serialization-of-a-binary-tree/
 */
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    /// <summary>
    /// Breadth first
    /// </summary>
    public class VerifyPreorderSerializationBinaryTree
    {
        public static bool IsValidSerialization(string preorder)
        {
            List<string> stack = new List<string>();

            string[] arr = preorder.Split(',');

            /// We can keep removing the leaf node until there is no one to remove. If a sequence is like "4 # #", 
            /// change it to "#" and continue. We need a stack so that we can record previous removed nodes.
            /// http://www.programcreek.com/wp-content/uploads/2016/04/verify-preorder-serialization-of-a-binary-tree-leetcode-java-400x256.jpg
            for (int i = 0; i < arr.Length; i++)
            {
                stack.Add(arr[i]);

                while (stack.Count >= 3
                    && stack[stack.Count - 1].Equals("#")
                    && stack[stack.Count - 2].Equals("#")
                    && !stack[stack.Count - 3].Equals("#"))
                {
                    stack.RemoveAt(stack.Count - 1);
                    stack.RemoveAt(stack.Count - 1);
                    stack.RemoveAt(stack.Count - 1);

                    stack.Add("#");
                }
            }

            if (stack.Count() == 1 && stack[0].Equals("#"))
                return true;
            else
                return false;
        }
    }

    [TestFixture]
    public class UTVerifyPreorderSerializationBinaryTree
    {
        [Test]
        public void TestPreorderSerializationBinaryTree1()
        {
            string input = "9,3,4,#,#,1,#,#,2,#,6,#,#";

            Assert.IsTrue(VerifyPreorderSerializationBinaryTree.IsValidSerialization(input));
        }

        [Test]
        public void TestPreorderSerializationBinaryTree2()
        {
            string input = "1,#";

            Assert.IsFalse(VerifyPreorderSerializationBinaryTree.IsValidSerialization(input));
        }

        [Test]
        public void TestPreorderSerializationBinaryTree3()
        {
            string input = "9,#,#,1";

            Assert.IsFalse(VerifyPreorderSerializationBinaryTree.IsValidSerialization(input));
        }
    }
}

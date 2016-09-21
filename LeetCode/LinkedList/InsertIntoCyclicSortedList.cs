/*
 Given a sorted circular linked list, insert a newnode so that it remains a sorted circular linked list.

Input:

In this problem, method takes two argument: the address of the head of the linked list and the data which you have to insert. 
The function should not read any input from stdin/console.

The Node structure has a data part which stores the data and a next pointer which points to the next element of the linked list. 
There are multiple test cases. For each test case, this method will be called individually.

Output:
Set the * head_ref to head of resultant linked list.

Note: If you use "Test" or "Expected Output Button" use below example format

Constraints:

1<=T<=100
0<=N<=200

Example:

Input:
2
3                           Size of Linked List
1 2 4                    Elements of Linked List
2                           Element to be inserted
4
1 4 7 9
5

Output:

1 2 2 4
1 4 5 7 9

http://www.practice.geeksforgeeks.org/problem-page.php?pid=700127
 */

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    public class LinkNode
    {
        public int val;
        public LinkNode next;
        public LinkNode(int x) { val = x; }
    }

    class InsertIntoCyclicSortedList
    {
        public static void InsertNodeToSortedList(ref LinkNode node, int val)
        {
            LinkNode linkNode = new LinkNode(val);

            if (node == null)
            {
                linkNode.next = linkNode;
                node = linkNode;
                return;
            }

            LinkNode p = node.next;
            while (p != node)
            {
                if (p.val <= val && p.next.val >= val)
                {
                    break;
                }
                else if (p.val > p.next.val && p.val <= val)
                {
                    break;
                }
                else if (p.val > p.next.val && p.next.val >= val )
                {
                    break;
                }
            }

            linkNode.next = p.next;
            p.next = linkNode;
        }
    }

    [TestFixture]
    public class UTInsertIntoCyclicSortedList
    {
        [Test]
        public void TestInsertIntoCyclicSortedList()
        {
            LinkNode node = null;
            InsertIntoCyclicSortedList.InsertNodeToSortedList(ref node, 1);
            InsertIntoCyclicSortedList.InsertNodeToSortedList(ref node, 4);
            InsertIntoCyclicSortedList.InsertNodeToSortedList(ref node, 8);
            InsertIntoCyclicSortedList.InsertNodeToSortedList(ref node, 4);
            Assert.IsTrue(node != null && node.val == 1);
            Assert.IsTrue(node.next != null && node.next.val == 4);
            Assert.IsTrue(node.next.next != null && node.next.next.val == 4);
        }
    }
}

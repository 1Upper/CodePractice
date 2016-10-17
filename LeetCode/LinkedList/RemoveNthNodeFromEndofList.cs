/*
 19. Remove Nth Node From End of List  
Question
Editorial Solution 
My Submissions 

Total Accepted: 137957
Total Submissions: 438394
Difficulty: Easy
Contributors: Admin 

Given a linked list, remove the nth node from the end of list and return its head.
For example,
   Given linked list: 1->2->3->4->5, and n = 2.

   After removing the second node from the end, the linked list becomes 1->2->3->5.
Note:
Given n will always be valid.
Try to do this in one pass. 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace LeetCode
{
    class RemoveNthNodeFromEndofList
    {
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            if (head == null || n < 1)
            {
                return head;
            }

            ListNode p1 = new ListNode(0);
            p1.next = head;

            ListNode p2 = head;
            int distance = 1;

            while (p2.next != null)
            {
                p2 = p2.next;
                
                if (distance < n)
                {
                    distance++;
                }
                else
                {
                    p1 = p1.next;
                }
            }

            if (distance == n)
            {
                if (p1.next == head)
                {
                    return head.next;
                }
                else
                {
                    p1.next = p1.next.next;
                    return head;
                }
            }

            return head;
        }
    }

    [TestFixture]
    class TestRemoveNthNodeFromEndofList
    {
        [Test]
        public void TestRemoveNthFromEnd()
        {
            ListNode n = new ListNode(1);

            RemoveNthNodeFromEndofList solution = new RemoveNthNodeFromEndofList();
            var result = solution.RemoveNthFromEnd(n, 1);

            Assert.IsTrue(result == null);
        }
    }
}

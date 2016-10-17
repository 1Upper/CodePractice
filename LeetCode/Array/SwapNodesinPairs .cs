/*
 24. Swap Nodes in Pairs  
Question
Editorial Solution 
My Submissions 

Total Accepted: 127150
Total Submissions: 346531
Difficulty: Easy
Contributors: Admin 

Given a linked list, swap every two adjacent nodes and return its head. 
For example,
Given 1->2->3->4, you should return the list as 2->1->4->3. 
Your algorithm should use only constant space. You may not modify the values in the list, only nodes itself can be changed. 
 */
 
 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Array
{
    class SwapNodesinPairs
    {
        public ListNode SwapPairs(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            ListNode slow = head;
            ListNode fast = head.next;

            slow.next = fast.next;
            fast.next = slow;
            head = fast;

            slow.next = SwapPairs(slow.next);
            return head;
        }
    }
}

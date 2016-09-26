/*
 You are given two linked lists representing two non-negative numbers. The digits are stored in reverse order and each of their nodes contain a single digit. Add the two numbers and return it as a linked list.

Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
Output: 7 -> 0 -> 8
*/

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Array
{
    class AddTwoNumbers
    {
        public static ListNode AddTwoNumbersI(ListNode l1, ListNode l2)
        {
            ListNode n1 = l1;
            ListNode n2 = l2;

            ListNode head = new ListNode(0);
            ListNode pEnd = head;
            int left = 0;

            while (n1 != null || n2 != null)
            {
                int t = left;
                t += (n1 == null) ? 0 : n1.val;
                t += (n2 == null) ? 0 : n2.val;

                ListNode n = new ListNode(t % 10);
                left = t / 10;

                pEnd.next = n;
                pEnd = pEnd.next;

                if (n1 != null) n1 = n1.next;
                if (n2 != null) n2 = n2.next;
            }

            if (left > 0)
            {
                ListNode n = new ListNode(left);

                pEnd.next = n;
                pEnd = pEnd.next;
            }

            return head.next;
        }
    }


    [TestFixture]
    class UTAddTwoNumbers
    {
        ListNode CreateListNodes(int[] nums)
        {
            ListNode head = new ListNode(0);
            ListNode p = head;
            for (int i = 0; i < nums.Length; i++)
            {
                ListNode n = new ListNode(nums[i]);
                p.next = n;
                p = p.next;
            }

            return head.next;
        }
        [Test]
        public void TestUTAddTwoNumbers()
        {
            int[] string1 = { 2, 4, 3 };
            int[] string2 = { 5, 6, 7 };

            var result = AddTwoNumbers.AddTwoNumbersI(CreateListNodes(string1), CreateListNodes(string2));

            Assert.IsTrue(result.val == 7);
        }
    }
}

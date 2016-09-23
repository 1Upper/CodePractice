using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    };

    class MergekSortedLists
    {
        public static ListNode MergeKLists(ListNode[] lists)
        {
            ListNode[] listIndex = new ListNode[lists.Length];
            for (int i = 0; i < lists.Length; i++)
            {
                listIndex[i] = lists[i];
            }

            ListNode head = new ListNode(int.MinValue);
            ListNode pHead = head;

            if (lists.Length > 0)
            {
                while (true)
                {
                    int selectedNodeIndex = -1;
                    for (int i = 0; i < lists.Length; i++)
                    {
                        if (listIndex[i] != null)
                        {
                            if (selectedNodeIndex ==  -1)
                            {
                                selectedNodeIndex = i;
                            }
                            else if (listIndex[selectedNodeIndex].val > listIndex[i].val)
                            {
                                selectedNodeIndex = i;
                            }
                        }
                    }

                    if (selectedNodeIndex != -1)
                    {
                        pHead.next = listIndex[selectedNodeIndex];
                        pHead = pHead.next;

                        listIndex[selectedNodeIndex] = listIndex[selectedNodeIndex].next;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return head.next;
        }
    };

    [TestFixture]
    public class UTMergekSortedLists
    {
        [Test]
        public void TestMergekSortedLists()
        {
            ListNode[] lists = new ListNode[1];
            lists[0] = new ListNode(1);

            var result = MergekSortedLists.MergeKLists(lists);
        }
    }
}

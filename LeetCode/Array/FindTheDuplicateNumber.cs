/*
Given an array nums containing n + 1 integers where each integer is between 1 and n (inclusive), prove that at least one duplicate number must exist. Assume that there is only one duplicate number, find the duplicate one. 

Note:

1.You must not modify the array (assume the array is read only).
2.You must use only constant, O(1) extra space.
3.Your runtime complexity should be less than O(n2).
4.There is only one duplicate number in the array, but it could be repeated more than once.

To identify whether there is a loop, you set off two pointers, n1 & n2 from beginning.
n1 has speed of 1, n2 has speed of 2, then you know n1 n2 are going to meet each other some time. 
Think about a fast runner and a slow runner running on a circular lap.

One thing is important, if n1 n2 start from the a point on a loop, say i, they are going to meet 
at the same point. Because n2 has twice speed. So when they start off from k nodes ahead of i ON THE LOOP, 
they are going to meet at the same position again.

Now you set off two pointers, n1 n2 from beginning, n2 will go along green arrow, n1 will go along orange. 
If beginning point is k nodes from the loop entry point i. It’s the same as two pointers set off from k 
nodes ahead of i ON THE LOOP, i.e., from the start of red arrow.

So what you know is when you set n1, n2 off from beginning, they are going to meet at same point j. 
The distance of j to i is equal to the list's beginning to i. Now you leave the pointer n1 at j. 
You set off a n3 which has speed of 1 at beginning. n1 and n3 go together, and they are going to finally 
meet i together.

Now you find i, which is the entry of the loop.

在p2和p1第一次相遇的时候，假定p1走了n步骤，环路的入口是在p步的时候经过的，那么有

p1走的路径： p+c = n；         c为p1和p2相交点，距离环路入口的距离

p2走的路径： p+c+k*L = 2*N；   L为环路的周长，k是整数

so: k*L = p + c               领先的路程是 K个圆周长，这个距离等于p1走的路程，也就是k个圆周长。

显然，如果从p+c点开始，p1再走n步骤的话，还可以回到p+c这个点。

同时p2从头开始走的话，经过n不，也会达到p+c这点

显然在这个步骤当中p1和p2只有前p步骤走的路径不同，所以当p1和p2再次重合的时候，必然是在链表的环路入口点上
Graphic: https://postimg.cc/image/k1zvaj0xr/

https://leetcode.com/problems/find-the-duplicate-number/
 */
using System;
using NUnit.Framework;

namespace LeetCode
{
    public class FindTheDuplicateNumber
    {
        public static int FindDuplicate(int[] nums)
        {
            if (nums.Length > 1)
            {
                int slow = nums[0];
                int fast = nums[nums[0]];
                
                while (slow != fast)
                {
                    slow = nums[slow];
                    fast = nums[nums[fast]];
                }

                fast = 0;
                while (fast != slow)
                {
                    fast = nums[fast];
                    slow = nums[slow];
                }
                return slow;
            }
            return -1;
        }
        
    };
    
    [TestFixture]
    public class UTFindTheDuplicateNumber
    {
        [Test]
        public void TestFindTheDuplicateNumber()
        {
            int[] input = {1,2,3,1};
            var result = FindTheDuplicateNumber.FindDuplicate(input);
            Assert.IsTrue(result == 1);
        }
    }
}

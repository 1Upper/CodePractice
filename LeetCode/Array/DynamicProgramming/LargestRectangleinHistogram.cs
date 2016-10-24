/*
84. Largest Rectangle in Histogram   QuestionEditorial Solution  My Submissions

Given n non-negative integers representing the histogram's bar height where the width of each bar is 1, find the area of largest rectangle in the histogram.
Above is a histogram where width of each bar is 1, given height = [2,1,5,6,2,3].
The largest rectangle is shown in the shaded area, which has area = 10 unit.

For example,
Given heights = [2,1,5,6,2,3],
return 10.
some reference: 
http://chuansong.me/n/996770152239
http://www.cnblogs.com/lichen782/p/leetcode_Largest_Rectangle_in_Histogram.html

基本解题思路：
1. 如果当前bar的高度大于栈顶bar的高度，则将当前bar的下标入栈；
2. 否则执行出栈操作，记录弹出下标对应的bar的高度，并计算出一个面积，然后用这个面积更新最大面积。

原理：
面积最大的那个矩形好像都包含至少一个完整的bar，那么这条规律适用于所有的直方图吗？我们用反证法来证明，假设某个最大矩形中每个竖直块都是所在的bar的一小段，
那么这个矩形高度增加1后仍然是一个合法的矩形，但新的矩形面积更大，与假设矛盾，所以面积最大的矩形必须至少有一个竖直块是整个bar。

至此我们找到了面积最大矩形的一个特性：各组成竖直块中至少有一个是完整的Bar。有了这条特性，我们再找面积最大的矩形时，就有了一个比较小的范围。具体来说就是
针对每个bar，我们找出包含这个bar的面积最大的矩形，然后只需要比较这N个矩形即可（N为bar的个数）。
https://leetcode.com/problems/largest-rectangle-in-histogram/
 */
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using NUnit.Framework;

namespace LeetCode
{
    class LargestRectangleinHistogram
    {
        public int LargestRectangleArea(int[] heights)
        {
            if (heights.Length <= 0)
                return 0;

            Stack<int> stack = new Stack<int>();
            int[] h = new int[heights.Length + 1];
            System.Array.Copy(heights, h, heights.Length);

            stack.Push(0);
            int maxArea = h[0];

            for (int i = 1; i < h.Length; i++)
            {
                if (stack.Count == 0 || h[stack.Peek()] <= h[i])
                {
                    stack.Push(i);
                }
                else
                {
                    while (stack.Count > 0 && h[i] < h[stack.Peek()])
                    {
                        int t = stack.Pop();
                        maxArea = Math.Max(maxArea, h[t]*(stack.Count == 0 ? t : i - stack.Peek() - 1));
                    }

                    stack.Push(i);
                }
            }

            return maxArea;
        }

        public int LargestRectangleAreaClean(int[] heights)
        {
            Stack<int> stack = new Stack<int>();
            int i = 0;
            int maxArea = 0;
            int[] h = new int[heights.Length + 1];
            System.Array.Copy(heights, h, heights.Length);
            while (i < h.Length)
            {
                if (stack.Count == 0 || h[stack.Peek()] <= h[i])
                {
                    stack.Push(i++);
                }
                else
                {
                    int t = stack.Pop();
                    maxArea = Math.Max(maxArea, h[t]*(stack.Count == 0 ? i : i - stack.Peek() - 1));
                }
            }
            return maxArea;
        }
    }

    [TestFixture]
    class UTLargestRectangleArea
    {
        [Test]
        public void TestLargestRectangleArea()
        {
            int[] bars = new[] {2, 1, 5, 6, 2, 3};
            LargestRectangleinHistogram obj = new LargestRectangleinHistogram();
            var result = obj.LargestRectangleAreaClean(bars);

            Assert.IsTrue(result == 10);
        }

        [Test]
        public void TestLargestRectangleArea1()
        {
            int[] bars = new[] { 1, 2, 3, 4, 5 };
            LargestRectangleinHistogram obj = new LargestRectangleinHistogram();
            var result = obj.LargestRectangleAreaClean(bars);

            Assert.IsTrue(result == 9);
        }

        [Test]
        public void TestLargestRectangleArea2()
        {
            int[] bars = new[] { 0 , 0, 0, 0 };
            LargestRectangleinHistogram obj = new LargestRectangleinHistogram();
            var result = obj.LargestRectangleAreaClean(bars);

            Assert.IsTrue(result == 0);
        }
    }
}

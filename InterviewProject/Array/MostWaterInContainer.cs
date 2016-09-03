using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterviewProject
{
    public class MostWaterInContainer
    {
        public static int MaxArea(int[] height)
        {
            int leftIndex = 0;
            int rightIndex = height.Length - 1;
            int maxArea = 0;

            while (rightIndex > leftIndex)
            {
                // for performance if needed...
                //if (leftIndex > 0 && height[leftIndex] <= height[leftIndex-1])
                //{
                //    leftIndex++;
                //    continue;
                //}

                //if (rightIndex < height.Length - 1 && height[rightIndex] >= height[rightIndex+1] )
                //{
                //    rightIndex--;
                //    continue;
                //}

                if (height[leftIndex] > height[rightIndex])
                {
                    maxArea = Math.Max(maxArea, height[rightIndex] * (rightIndex - leftIndex));
                    rightIndex--;
                }
                else if (height[leftIndex] < height[rightIndex])
                {
                    maxArea = Math.Max(maxArea, height[leftIndex] * (rightIndex - leftIndex));
                    leftIndex++;
                }
                else
                {
                    maxArea = Math.Max(maxArea, height[leftIndex] * (rightIndex - leftIndex));
                    leftIndex++;
                    rightIndex--;
                }
            }

            return maxArea;
        }
    }

    [TestFixture]
    public class UTMostWaterInContainer
    {
        [Test]
        public void TestMostWaterInContainer()
        {
            int[] testArray = { 1, 1, 1};

            var result = MostWaterInContainer.MaxArea(testArray);
            Assert.IsTrue(result == 2);
        }
    }
}

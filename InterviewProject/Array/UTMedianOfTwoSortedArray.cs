/*
 * Created by SharpDevelop.
 * User: malei
 * Date: 8/22/2016
 * Time: 8:17 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using NUnit.Framework;

namespace InterviewProject
{
    [TestFixture]
    public class UTMedianOfTwoSortedArray
    {
        [Test]
        public void GetMedianOfTwoSortedArray()
        {
            int[] arr1 = {1, 2};
            int[] arr2 = {3, 4};
            
            double value = MedianOfTwoSortedArray.GetMedianOfTwoSortedArray(arr1, arr2);
            Assert.IsTrue(value == 2.5);
        }
        
        [Test]
        public void GetMedianOfTwoSortedArray2()
        {
            int[] arr1 = {1, 2};
            int[] arr2 = {};
            
            double value = MedianOfTwoSortedArray.GetMedianOfTwoSortedArray(arr1, arr2);
            Assert.IsTrue(value == 1.5);
        }
    }
}

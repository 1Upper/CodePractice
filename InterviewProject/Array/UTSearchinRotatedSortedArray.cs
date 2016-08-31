/*
 * Created by SharpDevelop.
 * User: malei
 * Date: 8/29/2016
 * Time: 8:37 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using NUnit.Framework;

namespace InterviewProject
{
    [TestFixture]
    public class UTSearchinRotatedSortedArray
    {
        [Test]
        public void TestSigleElementArrayNoTarget()
        {
            int[] test = {1};
            const int target = 0;
            
            var result = SearchinRotatedSortedArray.Search(test, target);
            
            Assert.IsTrue(result == -1);
        }
        
        [Test]
        public void TestTwoElementsArrayWithTarget()
        {
            int[] test2 = {1, 3};
            const int target = 3;
            var result = SearchinRotatedSortedArray.Search(test2, target);
            
            Assert.IsTrue(result == 1);
        }

        [Test]
        public void TestThreeElementsArrayWithTarget()
        {
            int[] test2 = {1, 3, 5};
            const int target = 5;
            var result = SearchinRotatedSortedArray.Search(test2, target);
            
            Assert.IsTrue(result == 2);
        }
        
        [Test]
        public void TestSigleElementArrayNoTarget2()
        {
            int[] test = {1};
            const int target = 2;
            
            var result = SearchinRotatedSortedArray.Search(test, target);
            
            Assert.IsTrue(result == -1);
        }
                
        [Test]
        public void TestTwoElementsArrayNoTarget()
        {
            int[] test2 = {1, 3};
            const int target = 0;
            var result = SearchinRotatedSortedArray.Search(test2, target);
            
            Assert.IsTrue(result == -1);
        }
        
        [Test]
        public void TestSevenElementsArrayWithTarget()
        {
            int[] test2 = {4,5,6,7,0,1,2};
            const int target = 0;
            var result = SearchinRotatedSortedArray.Search(test2, target);
            
            Assert.IsTrue(result == 4);
        }
        
        [Test]
        public void TestEightElementsArrayWithTarget()
        {
            int[] test2 = {4,5,6,7,8,1,2,3};
            const int target = 8;
            var result = SearchinRotatedSortedArray.Search(test2, target);
            
            Assert.IsTrue(result == 4);
        }
        
        [Test]
        public void TestThreeElementsArrayWithTarget2()
        {
            int[] test2 = {3,5,1};
            const int target = 3;
            var result = SearchinRotatedSortedArray.Search(test2, target);
            
            Assert.IsTrue(result == 0);
        }
    }
}

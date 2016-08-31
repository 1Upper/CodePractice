/*
 * Created by SharpDevelop.
 * User: malei
 * Date: 8/21/2016
 * Time: 2:45 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using NUnit.Framework;

namespace InterviewProject
{
    [TestFixture]
    public class UTFindTwoNumbersWithValidNumbers
    {
        [Test]
        public void TestFindTwoNumbersWithValidNumbers()
        {
            int[] testArray = {-10,-9,-8,-7,-6,-5,-4,-3,-2,-1,-0,1,2,3,4,5,6,7,8,9,10};
            int indexA = -1;
            int indexB = -1;
            const int Target = 5;
            
            FindTwoNumbers.FindTwoNumbersInTarget(testArray, Target, ref indexA, ref indexB);
            
            Assert.IsTrue(indexA == 6, "indexA={0}", indexA);
            Assert.IsTrue(indexB == 21, "indexB={0}", indexB);
        }

        [Test]
        public void TestFindTwoNumbersWithInvalidNumbers()
        {
            int[] testArray = {-10,-9,-8,-7,-6,-5,-4,-3,-2,-1,-0};
            int indexA = -1;
            int indexB = -1;
            const int Target = 5;
            
            FindTwoNumbers.FindTwoNumbersInTarget(testArray, Target, ref indexA, ref indexB);
            
            Assert.IsTrue(indexA == -1, "indexA={0}", indexA);
            Assert.IsTrue(indexB == -1, "indexB={0}", indexB);
        }
    }
}

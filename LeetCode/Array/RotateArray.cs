/*
 * Created by SharpDevelop.
 * User: malei
 * Date: 9/10/2016
 * Time: 4:42 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using NUnit.Framework;

namespace LeetCode.Array
{
    public class RotateArray
    {
        public void Rotate(int[] nums, int k)
        {
            if (nums.Length == 0 || k == 0)
                return;
            
            int[] buffer = new int[nums.Length];
            nums.CopyTo(buffer, 0);
            
            for (int i = 0; i < nums.Length; i++)
            {
                nums[(i+k)%nums.Length] = buffer[i];
            }
        }
    }
    
    [TestFixture]
    public class UTRotateArray
    {
        [Test]
        public void TestMethod()
        {
            // TODO: Add your test.
        }
    }
}

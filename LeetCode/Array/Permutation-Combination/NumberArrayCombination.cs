/*
 //从头扫描字符串得到第一个字符，针对第一个字符，有两种选择  
//把这个字符放到组合中去，接下来我们需要在剩下的n-1个字符中选取m-1个字符；  
//如果不把这个字符放到组合中去，则需要在剩下的n-1个字符中选取m个字符   
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace LeetCode
{
    class NumberArrayCombination
    {
        public IList<string> Combination(char[] charArray)
        {
            IList<string> results = new List<string>();

            if (charArray.Length == 0)
                return results;

            string result = string.Empty;

            for (int i = 1; i <= charArray.Length; i++)
            {
                GetCombinations(charArray,0,i, ref result, results);
            }

            return results;
        }   

        public void GetCombinations(char[] charArray, int start, int length, ref string s, IList<string> results)
        {
            if (length == 0)
            {
                results.Add(s);
                return;
            }

            if (start >= charArray.Length)
                return;

            //不把这个字符放到组合中去，则需要在剩下的n-1个字符中选取m个字符   
            GetCombinations(charArray, start+1, length, ref s, results);

            //把这个字符放到组合中去，接下来我们需要在剩下的n-1个字符中选取m-1个字符  
            s += charArray[start]; 
            GetCombinations(charArray, start+1, length-1, ref s, results);
        }
    }

    [TestFixture]
    public class UTNumberArrayCombination
    {
        [Test]
        public void TestNumberArrayCombination()
        {
            char[] arr = new char[]{'1', '2', '3'};

            NumberArrayCombination obj = new NumberArrayCombination();
            var results = obj.Combination(arr);

            Assert.IsTrue(results.Count == 7);
        }
    }
}

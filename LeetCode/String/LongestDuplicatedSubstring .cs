/*
 
Given the string, such as "aabbbcccc", find the longgest duplicated substring in this string.

 for exmaple: the longgest duplicated string in aabbbcccc is "ccc"

 The question of searching longest duplicated substring in given string can be solved with an academic way 
 which time complexity is just O(n). It is called “Suffix array” which is detailed in following webpage: https://en.wikipedia.org/wiki/Suffix_array

Take an example of the string we used for discussion: aabbbcccc, it is very easy to find the longest dup string “ccc” with a suffix array.

i	1	2	3	4	5	6	7	8	9	10
A[i]1	2	3	4	5	6	7	8	9	10
1	a	a	b	b	b	c	c	c	c	$
2	a	b	b	b	c	c	c	c	$	
3	b	b	b	c	c	c	c	$		
4	b	b	c	c	c	c	$			
5	b	c	c	c	c	$				
6	c	c	c	c	$					
7	c	c	c	$						
8	c	c	$							
9	c	$								
10	$									



 */
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    public class LongestDuplicatedSubstring
    {
        public static string FindLongestDupSubString(string s)
        {
            IList<string> sc = new List<string>();

            for (int i =0; i<s.Length; i++)
            {
                sc.Add(s.Substring(i));
            }

            string sub = sc[0];
            string comdup = string.Empty;

            for (int i = 1; i < sc.Count; i++)
            {
                string cmn = string.Empty;
                string nextSub = sc[i];

                for (int j=0; j<sub.Length && j<nextSub.Length; j++)
                {
                    if (sub[j] == nextSub[j])
                    {
                        cmn += sub[j];
                    }
                    else
                    {
                        break;
                    }
                }

                sub = nextSub;

                if (comdup.Length < cmn.Length)
                    comdup = cmn;
            }

            return comdup;
        }
    }


    [TestFixture]
    public class UTLongestDuplicatedSubstring
    {
        [Test]
        public void TestLongestDuplicatedSubstring()
        {
            string input = "aabbbcccc";

            var result = LongestDuplicatedSubstring.FindLongestDupSubString(input);
            Assert.IsTrue(result == "ccc");
        }
    }
}

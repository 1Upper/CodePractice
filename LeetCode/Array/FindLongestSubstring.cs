/*
Given a string, find the length of the longest substring without repeating characters.
 For example, the longest substring without repeating letters for "abcabcbb" is "abc",
 which the length is 3. For "bbbbb" the longest substring is "b", with the length of 1.
From <https://oj.leetcode.com/problems/longest-substring-without-repeating-characters/> 
*/

using System;
using NUnit.Framework;

namespace InterviewProject
{
    public static class FindLongestSubstring
    {
        public static int GetLengthOfLongestSubstring(string input)
        {
            if (input.Length == 0)
            {
                return 0;
            }
            
            int startSubstring = 1;
            int currntlength = 0;
            int maxLength = 0;
            
            // we use this char map to track the last position of each char
            int[] charPosition = new int[256];
            
            for (int index = 0; index < input.Length; index ++)
            {
                int charCode = Convert.ToInt16(input[index]);
                
                if (currntlength > 0 && charPosition[charCode] >= startSubstring)
                {
                    startSubstring = charPosition[charCode] + 1;
                    currntlength = index + 1 - charPosition[charCode];
                    charPosition[charCode] = index + 1;
                }
                else
                {
                    currntlength ++;
                    charPosition[charCode] = index + 1;
                    
                    maxLength = maxLength < currntlength ? currntlength : maxLength;
                }
            }
            
            return maxLength;
        }
    }
    
    [TestFixture]
    public class UTFindLongestSubstring
    {
        [Test]
        public void TestStringWithSameCharacter()
        {
            const string s = "bbbbbbb";
            var len = FindLongestSubstring.GetLengthOfLongestSubstring(s);
            Assert.IsTrue(len == 1, "length is {0}", len);
        }
        
        [Test]
        public void TestStringWithDifferentCharacter()
        {
            const string s = "ab";
            var len = FindLongestSubstring.GetLengthOfLongestSubstring(s);
            Assert.IsTrue(len == 2, "length is {0}", len);
        }
        
        [Test]
        public void TestStringWithDuplicatedChar()
        {
            const string s = "ababababababab";
            var len = FindLongestSubstring.GetLengthOfLongestSubstring(s);
            Assert.IsTrue(len == 2, "length is {0}", len);
        }
    }
}

/*30. Substring with Concatenation of All Words  QuestionEditorial Solution  My Submissions

You are given a string, s, and a list of words, words, that are all of the same length.Find all starting
 indices of substring(s) in s that is a concatenation of each word in words exactly once and without any 
intervening characters.

For example, given:
s: "barfoothefoobarman"
words: ["foo", "bar"]

You should return the indices: [0,9].
(order does not matter).

 https://leetcode.com/problems/substring-with-concatenation-of-all-words/
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace LeetCode
{
    public class SubstringWithConcatenationAllWords
    {

        // Valid if target string contains all words in collection
        // 0: Match, -1: Not match and stop, N: try from N
        public static int IsStringCollectionValid(IList<string> words, string dest, int keyLength)
        {
            if (words.Count == 0)
            {
                return 0;
            }

            string subString = dest.Substring(0, keyLength);
            
            if (words.Contains(subString))
            {
                words.Remove(subString);
                
                return keyLength + IsStringCollectionValid(
                    words, 
                    dest.Substring(keyLength),
                    keyLength);
            }
            else
            {
                return 0;
            }
        }

        public static IList<int> FindSubstring(string s, string[] words)
        {
            IList<string> ws = new List<string>(words);
            IList<int> lists = new List<int>();
            
            if (s.Length ==0 || words.Length == 0 || s.Length < words.Length * words[0].Length)
            {
                return lists;
            }
            
            int keyLength = words[0].Length;
            
            for (int i = 0; s.Length-i >= words.Length * keyLength; i++)
            {
                IList<string> hs = new List<string>(ws);
                
                int result = IsStringCollectionValid(hs, s.Substring(i), keyLength);
                
                if (hs.Count == 0)
                {
                    lists.Add(i);
                }
            }
            
            return lists;
        }
    }
    
/*
     public class SubstringWithConcatenationAllWords
    {
        // Valid if target string contains all words in collection
        public static bool IsStringCollectionValid(IList<string> words, string dest, int keyLength)
        {
            if (words.Count == 0)
                return true;
            else if (dest.Length < words.Count * keyLength) 
                return false;

            string subString = dest.Substring(0, keyLength);
            
            if (words.Contains(subString))
            {
                words.Remove(subString);
                return IsStringCollectionValid(
                    words, 
                    dest.Substring(keyLength),
                   keyLength);
            }
            else
            {
                return false;
            }
        }

        public static IList<int> FindSubstring(string s, string[] words)
        {
            IList<string> ws = new List<string>(words);
            IList<int> lists = new List<int>();
            
            if (s.Length ==0 || words.Length == 0 || s.Length < words.Length * words[0].Length)
            {
                return lists;
            }
            
            int keyLength = words[0].Length;
            
            for (int i = 0; i < s.Length; i++) {
                IList<string> hs = new List<string>(ws);
                if (IsStringCollectionValid(hs, s.Substring(i), keyLength))
                {
                        lists.Add(i);
                }
            }
            
            return lists;
        }
    }
 */
    
    [TestFixture]
    public class UTSubstringWithConcatenationAllWords
    {
        [Test]
        public void TestSubstringWithConcatenationAllWords()
        {
            string input = "barfoothefoobarman";
            IList<string> words = new List<string>();
            words.Add("foo");
            words.Add("bar");

            var result = SubstringWithConcatenationAllWords.FindSubstring(input, words.ToArray());
            
            Assert.IsTrue(result.Count == 2);
        }
        
        [Test]
        public void TestSubstringWithConcatenationAllWords1()
        {
            string input = "barfoofoobarthefoobarman";
            IList<string> words = new List<string>();
            words.Add("foo");
            words.Add("bar");
            words.Add("the");

            var result = SubstringWithConcatenationAllWords.FindSubstring(input, words.ToArray());
            
            Assert.IsTrue(result.Count == 3, "result {0}", result.Count);
        }

        [Test]
        public void TestSubstringWithConcatenationAllWords2()
        {
            string input = "lingmindraboofooowingdingbarrwingmonkeypoundcake";
            IList<string> words = new List<string>();
            words.Add("fooo");
            words.Add("barr");
            words.Add("wing");
            words.Add("ding");
            words.Add("wing");

            var result = SubstringWithConcatenationAllWords.FindSubstring(input, words.ToArray());
            
            Assert.IsTrue(result.Count == 1, "result {0}", result.Count);
        }
    }
}

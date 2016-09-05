/*
Given a digit string, return all possible letter combinations that the number could represent. 
A mapping of digit to letters (just like on the telephone buttons) is given below.

Note:
Although the above answer is in lexicographical order, your answer could be in any order you want. 

From <https://leetcode.com/problems/letter-combinations-of-a-phone-number/> 

 */
using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace InterviewProject
{
    public class LetterCombinationsOfPhoneNumber
    {
        // Get the possible letters for a digit.
        private static string GetLettersForDigit(char digit)
        {
            switch (digit)
            {
            case '2':
                return "abc";
            case '3':
                return "def";
            case '4':
                return "ghi";
            case '5':
                return "jkl";
            case '6':
                return "mno";
            case '7':
                return "pqrs";
            case '8':
                return "tuv";
            case '9':
                return "wxyz";
            case '0':
            default:
                return "";
            }
        }

        public static IList<string> LetterCombinations(string digits)
        {
            IList<string> res = new List<string>();
            if (digits.Length == 0)
            {
                return res;
            }
            
            res.Add(string.Empty);
            int resSize = 1;
            
            for (int i = 0; i < digits.Length; i++) 
            {
                string letters = GetLettersForDigit(digits[i]);
                
                if (letters.Length >0)
                {
                    for (int j = 0; j < resSize; j++) {
                        string tmp = res[j];
                        
                        res[j] += letters[0];
                        
                        for (int k = 1; k < letters.Length; k++) {
                            res.Add(tmp + letters[k]);
                        }
                    }
                }
                
                resSize = res.Count;
            }
            
            return res;
        }
    }
    
    [TestFixture]
    public class UTLetterCombinationsOfPhoneNumber
    {
        [Test]
        public void TestTwoDigits()
        {
            const string s = "23";
            IList<string> result = LetterCombinationsOfPhoneNumber.LetterCombinations(s);
            
            Assert.IsTrue(result.Count == 9, "find {0} combinations", result.Count);
        }
    }
}

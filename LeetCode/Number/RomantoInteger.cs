/*
 Roman to Integer  QuestionEditorial Solution  My Submissions
Given a roman numeral, convert it to an integer.

Input is guaranteed to be within the range from 1 to 3999.

思路：

这题需要一些背景知识，首先要知道罗马数字是怎么表示的：

http://en.wikipedia.org/wiki/Roman_numerals

I: 1
V: 5
X: 10
L: 50
C: 100
D: 500
M: 1000

字母可以重复，但不超过三次，当需要超过三次时，用与下一位的组合表示：
I: 1, II: 2, III: 3, IV: 4
C: 100, CC: 200, CCC: 300, CD: 400

举例： s = 3978
    3978/1000 = 3: MMM
    978>(1000-100), 998/900 = 1: CM
    78<(100-10), 78/50 = 1 :L
    28<(50-10), 28/10 = XX
    8<(100-1), 8/5 = 1: V
    3<(5-1), 3/1 = 3: III
    ret = MMMCMLXXVIII

所以可以将单个罗马字符扩展成组合形式，来避免需要额外处理类似IX这种特殊情况。
I: 1
IV: 4
V: 5
IX: 9
X: 10
XL: 40
L: 50
XC: 90
C: 100
CD: 400
D: 500
CM: 900
M: 1000
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Number
{
    class RomantoInteger
    {
        public int RomanToInt(string s)
        {
            string[] dict = {  "M", "CM",  "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
            int[] val =     { 1000,  900,  500,  400, 100,   90,  50,   40,  10,    9,   5,    4,   1 };

            int result = 0;
            int pos = 0;

            for (int i = 0; i < dict.Length; i++)
            { 
                while (pos < s.Length && string.Compare(s, pos, dict[i], 0, dict[i].Length, true) == 0)
                {
                    result += val[i];

                    pos += dict[i].Length;
                }
            }

            return result;
        }
    }
}

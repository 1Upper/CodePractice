using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Array
{
    class ReverseInteger
    {
        public int Reverse(int x)
        {
            Int64 y = x;

            bool flag = x < 0;

            y = Math.Abs(y);

            string s = y.ToString();
            string result = string.Concat<char>(s.Reverse<char>());
            
            if (flag)
            {
                result = '-' + result;
            }

            try
            {
               return int.Parse(result.Trim());
                
            }
            catch
            {
                return 0;
            }
        }
    }
}

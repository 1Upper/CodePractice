﻿/*
 Say you have an array for which the ith element is the price of a given stock on day i.

If you were only permitted to complete at most one transaction (ie, buy one and sell one share of the stock), design an algorithm to find the maximum profit.

Example 1:
Input: [7, 1, 5, 3, 6, 4]
Output: 5

max. difference = 6-1 = 5 (not 7-1 = 6, as selling price needs to be larger than buying price)
Example 2:
Input: [7, 6, 4, 3, 1]
Output: 0

In this case, no transaction is done, i.e. max profit = 0.
From <https://oj.leetcode.com/problems/best-time-to-buy-and-sell-stock/> 
 */
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    class BestTimeToBuySellStock
    {
        public static int MaxProfit(int[] prices)
        {
            int minPrice = int.MaxValue;
            int maxProfit = 0;

            for (int i =0; i< prices.Length; i++)
            {
                if (prices[i] < minPrice)
                {
                    minPrice = prices[i];
                }

                if (prices[i] - minPrice > maxProfit)
                {
                    maxProfit = prices[i] - minPrice;
                }
            }

            return maxProfit;
        }
    }

    [TestFixture]
    class UTBestTimeToBuySellStock
    {
        [Test]
        public void TestBestTimeToBuySellStockWithNormalInput()
        {
            int[] input = { 7, 1, 5, 3, 6, 4 };

            int profit = BestTimeToBuySellStock.MaxProfit(input);

            Assert.IsTrue(profit == 5);
        }

        [Test]
        public void TestBestTimeToBuySellStockWithBadInput()
        {
            int[] input = { 7, 6, 4, 3, 1 };

            int profit = BestTimeToBuySellStock.MaxProfit(input);

            Assert.IsTrue(profit == 0);
        }
    }
}

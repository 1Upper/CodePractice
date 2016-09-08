#pragma once
/*
Onsite Interview Questions

Write a program to sort the numbers read from file

Assume there are many numbers saved in the file, which range are from 0 to 32000. 
We want to load them into memory and sort them, then write them back.

Known functions
1. getnum() (EOF = -1)
2. Savenum(int n)


*/


using namespace System;
using namespace NUnit::Framework;

ref class SortNumbersInArray
{
public:
    SortNumbersInArray();

    static void SortNumbers(int *numberList, size_t length)
    {
        // the range is from 0 to 32000, so we only need 32000 / 8 = 4000 bytes
        BYTE numbers[4000] = { 0 };

        // Build the numbers using map
        for (size_t i = 0; i < length; i++)
        {
            int number = numberList[i];

            int bytePos = number / 8;
            int bitPos = number % 8;

            numbers[bytePos] |= 1 << bitPos;
        }

        // Save the map back
        int pos = 0;
        for (size_t i = 0; i < _ARRAYSIZE(numbers); i++)
        {
            for (size_t j = 0; j < 8; j++)
            {
                if (numbers[i] & (1 << j))
                {
                    numberList[pos++] = i * 8 + j;
                }
            }
        }
    }
};

[TestFixture]
public ref class UTSortNumbersInArray
{
public:

    [Test] 
    void TestSortNumbersInArray()
    {
        int nums[] = { 2, 5,  99, 1, 7 };
        SortNumbersInArray::SortNumbers(nums, _ARRAYSIZE(nums));

        for (size_t i = 0; i< _ARRAYSIZE(nums) - 1; i++)
        {
            Assert::IsTrue(nums[i] < nums[i + 1]);
        }
    }

    [Test]
    void TestSortNumbersInArray2()
    {
        int nums[] = { 2, 5,  99, 1, 7, 98, 19999, 20001, 3200};
        SortNumbersInArray::SortNumbers(nums, _ARRAYSIZE(nums));

        for (size_t i = 0; i< _ARRAYSIZE(nums) - 1; i++)
        {
            Assert::IsTrue(nums[i] < nums[i + 1]);
        }
    }

    [Test]
    void TestSortNumbersInArray3()
    {
        int nums[] = { 2, 0 };
        SortNumbersInArray::SortNumbers(nums, _ARRAYSIZE(nums));

        for (size_t i = 0; i< _ARRAYSIZE(nums) - 1; i++)
        {
            Assert::IsTrue(nums[i] < nums[i + 1]);
        }
    }
};
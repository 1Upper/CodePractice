#pragma once

using namespace System;
using namespace NUnit::Framework;

ref class SortNumbersInArray
{
public:
    SortNumbersInArray();

    static void SortNumbers(int *numberList, size_t length)
    {
        BYTE numbers[4000] = { 0 };

        // Build the numbers using map
        for (size_t i = 0; i < length; i++)
        {
            int number = numberList[i];

            int bytePos = number / 8;
            int bitPos = number % 8;

            numbers[bytePos] |= 1 << bitPos;
        }

        int pos = 0;
        // Save the map back
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

        for (size_t i = 0; i< _ARRAYSIZE(nums) - 2; i++)
        {
            Assert::IsTrue(nums[i] < nums[i + 1]);
        }
    }
};




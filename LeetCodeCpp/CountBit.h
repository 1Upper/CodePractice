#pragma once
/*
Given a non negative integer number num. For every numbers i in the range 0 ¡Ü i ¡Ü num calculate the number of 1's in their binary representation and return them as an array.

Example:
For num = 5 you should return [0,1,1,2,1,2].

Follow up:

It is very easy to come up with a solution with run time O(n*sizeof(integer)). But can you do it in linear time O(n) /possibly in a single pass?
Space complexity should be O(n).
Can you do it like a boss? Do it without using any builtin function like __builtin_popcount in c++ or in any other language.
*/
#include <vector>
using namespace System;
using namespace NUnit::Framework;
using namespace std;

public ref class CountBit
{
public:
	CountBit();
	
	static vector<int> countBits(int num)
	{
		vector<int> result(num + 1);
		result[0] = 0;

		for (int i = 1; i <= num; i++)
		{
			result[i] = result[i / 2] + (i & 1);
		}

		return result;
	}
};

[TestFixture]
public ref class UTCountBit
{
public:

	[Test]
	void TestCountBits()
	{
		int number = 5;
		
		auto result = CountBit::countBits(number);

		Assert::IsTrue(result[0] == 0);
		Assert::IsTrue(result[1] == 1);
		Assert::IsTrue(result[2] == 1);
		Assert::IsTrue(result[3] == 2);
		Assert::IsTrue(result[4] == 1);
		Assert::IsTrue(result[5] == 2);
	}
};


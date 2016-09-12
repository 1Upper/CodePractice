#pragma once
/*
201. Bitwise AND of Numbers Range  QuestionEditorial Solution  My Submissions
Given a range [m, n] where 0 <= m <= n <= 2147483647, return the bitwise AND of all numbers in this range, inclusive.

For example, given the range [5, 7], you should return 4.
*/
using namespace System;
using namespace NUnit::Framework;

public ref class BitwiseANDofNumbersRange
{
public:
	BitwiseANDofNumbersRange();

	static int rangeBitwiseAnd(int m, int n) {
		int i = 0;

		while (m != n)
		{
			i++;
			m >>= 1;
			n >>= 1;
		}

		return m << i;
	}
};

[TestFixture]
public ref class UTBitwiseANDofNumbersRange
{
public:

	[Test]
	void TestBitwiseANDofNumbersRange()
	{
		int n = 5, m = 7;

		auto result = BitwiseANDofNumbersRange::rangeBitwiseAnd(m, n);

		Assert::IsTrue(result == 4);
	}

};



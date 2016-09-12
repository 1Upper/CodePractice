#pragma once
/*
Reverse bits of a given 32 bits unsigned integer.

For example, given input 43261596 (represented in binary as 00000010100101000001111010011100), 
return 964176192 (represented in binary as 00111001011110000010100101000000).

Follow up:
*/
using namespace System;
using namespace NUnit::Framework;

public ref class ReverseBits
{
public:
	ReverseBits();

	static UINT reverseBits(UINT n)
	{
		UINT result = 0;

		for (size_t i = 1; i <= 32; i++)
		{
			if (n & 1)
			{
				result |= 1 << (32 - i);
			}
			
			n >>= 1;
		}

		return result;
	}
};


[TestFixture]
public ref class UTReverseBits
{
public:

	[Test]
	void TestReverseBits1()
	{
		UINT input = 43261596;

		auto result = ReverseBits::reverseBits(input);

		
		Assert::IsTrue(result == 964176192);
	}

};


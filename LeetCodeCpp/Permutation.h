#pragma once

using namespace System;
using namespace NUnit::Framework;

public ref class Permutation
{
public:
    Permutation();

    static void swap(char* a, char* b)
    {
		if (a != b)
		{
			char temp = *a;
			*a = *b;
			*b = temp;
		}
    }

    static void _Permutation(char* pStr, char* pBegin)
    {
		if (*pBegin == '\0')
		{
			char* s = pStr;
            //printf("%s\n", pStr);
		}
        else
        {
            for (char* pCh = pBegin; *pCh != '\0'; pCh++)
            {
                swap(pBegin, pCh);
                _Permutation(pStr, pBegin + 1);
                swap(pBegin, pCh);
            }
        }
    }

};


public ref class PermutationWithDup
{
public:
	PermutationWithDup();

	static bool IsSwap(char* pBegin, char* pEnd)
	{
		char *p;
		for (p = pBegin; p < pEnd; p++)
		{
			if (*p == *pEnd)
				return false;
		}
		return true;
	}

	static void swap(char* a, char* b)
	{
		if (a != b)
		{
			char temp = *a;
			*a = *b;
			*b = temp;
		}
	}

	static void _Permutation(char* pStr, char* pBegin)
	{
		if (*pBegin == '\0')
		{
			char* s = pStr;
			//printf("%s\n", pStr);
		}
		else
		{
			for (char* pCh = pBegin; *pCh != '\0'; pCh++)
			{
				if (IsSwap(pBegin, pCh))
				{
					swap(pBegin, pCh);
					_Permutation(pStr, pBegin + 1);
					swap(pBegin, pCh);
				}
			}
		}
	}
};

[TestFixture]
public ref class UTPermutation
{
public:

	[Test]
	void TestPermutation()
	{
		char test[10] = "123";

		Permutation::_Permutation(test, test);
	}

};

#pragma once

using namespace System;
using namespace NUnit::Framework;

public ref class ReverseString
{
public:
	ReverseString();

	char* reverseString(char* s) {
		char* begin = s;
		char* end = &(s[strlen(s) - 1]);

		while (begin < end)
		{
			char ch = *begin;
			*begin = *end;
			*end = ch;

			begin++;
			end--;
		}

		return s;
	}
};


#pragma once
#include<iostream>  
#include<vector>  
#include<string.h>  
using namespace std;
using namespace NUnit::Framework;
ref class NumberArrayCombination
{
public:
	NumberArrayCombination();

	void Combination(char* string, int number, wstring result, vector<wstring>& results)
	{
		if (number == 0)
		{
			results.push_back(result);
			return;
		}
		if (*string == '\0')
			return;

		Combination(string + 1, number, result, results);//不把这个字符放到组合中去，则需要在剩下的n-1个字符中选取m个字符   
		result.push_back(*string);
		Combination(string + 1, number - 1, result, results);//把这个字符放到组合中去，接下来我们需要在剩下的n-1个字符中选取m-1个字符  
	}

	void Combination(char* string, vector<wstring>& results)
	{
		if (string == NULL)
			return;
		int length = strlen(string);
		
		wstring result;
		for (int i = 1; i <= length; i++)
		{
			Combination(string, i, result, results);
		}

	}
};


[TestFixture]
public ref class UTNumberArrayCombination
{
public:

	[Test]
	void TestNumberArrayCombination()
	{
		vector<wstring> results;
		char test[] = "123";
		NumberArrayCombination^ testobj =  gcnew NumberArrayCombination();
		testobj->Combination(test, results);

		Assert::IsTrue(results.size() == 7);
	}

};


#pragma once
/*
Reverse bits of a given 32 bits unsigned integer.

For example, given input 43261596 (represented in binary as 00000010100101000001111010011100),
return 964176192 (represented in binary as 00111001011110000010100101000000).

Follow up:
https://leetcode.com/problems/reverse-nodes-in-k-group/
*/
#include <vector>

using namespace System;
using namespace NUnit::Framework;

struct ListNode {
	int val;
	ListNode *next;
	ListNode(int x) : val(x), next(NULL) {}
};

public ref class ReverseNodeInKGroup
{
public:
	static ListNode* reverseKNodes(ListNode* pStart, int k)
	{
		std::vector<ListNode*> nodeList;
		int len = 0;
		while (pStart && len < k)
		{
			nodeList.push_back(pStart);
			len++;
			pStart = pStart->next;
		}

		if (len < k)
		{
			return nullptr;
		}
		else
		{
			for (size_t i = 0; i < nodeList.size()/2; i++)
			{
				auto temp = nodeList[i]->val;
				nodeList[i]->val = nodeList[nodeList.size() -1 - i]->val;
				nodeList[nodeList.size() - 1 - i]->val = temp;
			}

			return pStart;
		}
	}

	static ListNode* reverseKGroup(ListNode* head, int k) 
	{
		ListNode* p = head;

		p = reverseKNodes(p, k);

		while (p)
		{
			p = reverseKNodes(p, k);
		}

		return head;
	}
};


[TestFixture]
public ref class UTReverseNodeInKGroup
{
public:

	[Test]
	void TestReverseNodeInKGroup1()
	{
		ListNode* n = new ListNode(1);
		ListNode* p = ReverseNodeInKGroup::reverseKGroup(n, 1);
		Assert::IsTrue(p->val == 1);
		Assert::IsTrue(p->next== nullptr);
	}

	[Test]
	void TestReverseNodeInKGroup2()
	{
		ListNode* n1 = new ListNode(1);
		ListNode* n2 = new ListNode(2);
		ListNode* n3 = new ListNode(3);
		ListNode* n4 = new ListNode(4);
		n1->next = n2;
		n2->next = n3;
		n4->next = nullptr;

		ListNode* p = ReverseNodeInKGroup::reverseKGroup(n1, 2);
		Assert::IsTrue(p->val == 2);
	}
};

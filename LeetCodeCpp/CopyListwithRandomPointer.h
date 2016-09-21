/*
A linked list is given such that each node contains an additional random pointer which could point to any node in the list or null.

Return a deep copy of the list.
*/
#pragma once

struct RandomListNode {
	int label;
	RandomListNode *next, *random;
	RandomListNode(int x) : label(x), next(NULL), random(NULL) {}
};

public ref class CopyListwithRandomPointer
{
public:
	CopyListwithRandomPointer();

	RandomListNode *copyRandomList(RandomListNode *head) {
		
		RandomListNode* pCurr = head;

		// dup all the node and insert them into the list
		while (pCurr)
		{
			RandomListNode* tempNode = new RandomListNode(pCurr->label);
			tempNode->next = pCurr->next;
			pCurr->next = tempNode;
			pCurr = tempNode->next;
		}

		// Copy the random pointer
		pCurr = head;
		while (pCurr)
		{
			RandomListNode* pNew = pCurr->next;

			if (pCurr->random)
			{
				pNew->random = pCurr->random->next;
			}

			pCurr = pNew->next;
		}

		// Decopy two links
		pCurr = head;
		RandomListNode* pNew = (head) ? head->next : NULL;

		while (pCurr)
		{
			RandomListNode* pNode = pCurr->next;
			pCurr->next = pNode->next;
			
			if (pNode->next)
			{
				pNode->next = pNode->next->next;
			}

			pCurr = pCurr->next;
		}

		return pNew;
	}

};


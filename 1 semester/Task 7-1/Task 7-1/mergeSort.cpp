#include <iostream>
#include "mergeSort.h"
#include "list.h"
#include <string>

using namespace std;

LinkedList* mergeSort(LinkedList* list, bool isSortPhone)
{
	if (sizeLinkedList(list) < 2)
	{
		return list;
	}

	LinkedList *listFirst = createLinkedList();
	LinkedList *listSecond = createLinkedList();
	ListElement *current = firstElement(list);

	int count = 1;

	while (count <= sizeLinkedList(list) / 2)
	{
		listFirst = addElementLinkedList(valueCurrentElement(list, current), nameCurrentElement(list, current), listFirst);
		current = nextElement(current);
		count++;
	}

	while (current != nullptr)
	{
		listSecond = addElementLinkedList(valueCurrentElement(list, current), nameCurrentElement(list, current), listSecond);
		current = nextElement(current);
	}

	deleteLinkedList(list);
	return merge(mergeSort(listFirst, isSortPhone), mergeSort(listSecond, isSortPhone), isSortPhone);
}

LinkedList* merge(LinkedList* listFirst, LinkedList* listSecond, bool isSortPhone)
{
	listFirst = invertLinkedList(listFirst);
	listSecond = invertLinkedList(listSecond);

	LinkedList *newList = createLinkedList();
	ListElement *currentFirst = firstElement(listFirst);
	ListElement *currentSecond = firstElement(listSecond);

	while ((currentFirst != nullptr) && (currentSecond != nullptr))
	{
		if (isSortPhone)
		{
			if (valueCurrentElement(listFirst, currentFirst) >= valueCurrentElement(listSecond, currentSecond))
			{
				newList = addElementLinkedList(valueCurrentElement(newList, currentFirst), nameCurrentElement(newList, currentFirst), newList);
				currentFirst = nextElement(currentFirst);
			}
			else
			{
				newList = addElementLinkedList(valueCurrentElement(newList, currentSecond), nameCurrentElement(newList, currentSecond), newList);
				currentSecond = nextElement(currentSecond);
			}
		}
		else
		{
			if (comparisonString(currentFirst, currentSecond))
			{
				newList = addElementLinkedList(valueCurrentElement(newList, currentFirst), nameCurrentElement(newList, currentFirst), newList);
				currentFirst = nextElement(currentFirst);
			}
			else
			{
				newList = addElementLinkedList(valueCurrentElement(newList, currentSecond), nameCurrentElement(newList, currentSecond), newList);
				currentSecond = nextElement(currentSecond);
			}
		}
	}

	if (currentFirst == nullptr)
	{
		while (currentSecond != nullptr)
		{
			newList = addElementLinkedList(valueCurrentElement(newList, currentSecond), nameCurrentElement(newList, currentSecond), newList);
			currentSecond = nextElement(currentSecond);
		}
	}
	else
	{
		while (currentFirst != nullptr)
		{
			newList = addElementLinkedList(valueCurrentElement(newList, currentFirst), nameCurrentElement(newList, currentFirst), newList);
			currentFirst = nextElement(currentFirst);
		}
	}

	deleteLinkedList(listFirst);
	deleteLinkedList(listSecond);
	return newList;
}
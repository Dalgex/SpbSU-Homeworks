#include <iostream>
#include "mergeSort.h"
#include "arrayList.h"

using namespace std;

ListType* merge(ListType* listFirst, ListType* listSecond)
{
	listFirst = invertList(listFirst);
	listSecond = invertList(listSecond);

	ListType *newList = createLinkedList();
	//ListType *newList = createArrayList();

	while ((sizeList(listFirst) != 0) && (sizeList(listSecond) != 0))
	{
		if (valueElement(listFirst) >= valueElement(listSecond))
		{
			addElementList(deleteElement(listFirst), newList);
		}
		else
		{
			addElementList(deleteElement(listSecond), newList);
		}
	}

	if (sizeList(listFirst) == 0)
	{
		while (sizeList(listSecond) != 0)
		{
			addElementList(deleteElement(listSecond), newList);
		}
	}
	else
	{
		while (sizeList(listFirst) != 0)
		{
			addElementList(deleteElement(listFirst), newList);
		}
	}

	deleteList(listFirst);
	deleteList(listSecond);
	return newList;
}

ListType* mergeSort(ListType* list)
{
	if (sizeList(list) < 2)
	{
		return list;
	}

	ListType *listFirst = createLinkedList();
	ListType *listSecond = createLinkedList();
	//ListType *listFirst = createArrayList();
	//ListType *listSecond = createArrayList();

	int count = sizeList(list) / 2;

	while (sizeList(list) > count)
	{
		addElementList(deleteElement(list), listFirst);
	}

	while (sizeList(list) != 0)
	{
		addElementList(deleteElement(list), listSecond);
	}

	deleteList(list);
	return merge(mergeSort(listFirst), mergeSort(listSecond));
}
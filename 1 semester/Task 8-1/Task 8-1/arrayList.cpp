#include <iostream>
#include <vector>
#include "arrayList.h"

using namespace std;

struct ArrayList
{
	vector<int> value;
};

ArrayList* createArrayList()
{
	return new ArrayList;
}

void addElementList(int value, ArrayList* arrayList)
{
	arrayList->value.push_back(value);
}

int valueElement(ArrayList* arrayList)
{
	return arrayList->value.back();
}

int sizeList(ArrayList* arrayList)
{
	return arrayList->value.size();
}

ArrayList* invertList(ArrayList* arrayList)
{
	ArrayList *newList = createArrayList();
	int size = sizeList(arrayList);

	for (int i = 0; i < size; i++)
	{
		newList->value.push_back(valueElement(arrayList));
		arrayList->value.pop_back();
	}

	deleteList(arrayList);
	return newList;
}

void printList(ArrayList* arrayList)
{
	int size = sizeList(arrayList);

	for (int i = size - 1; i >= 0; i--)
	{
		cout << arrayList->value[i] << " ";
	}

	cout << endl;
}

int deleteElement(ArrayList* arrayList)
{
	int number = valueElement(arrayList);
	arrayList->value.pop_back();
	return number;
}

void deleteList(ArrayList* arrayList)
{
	delete arrayList;
}

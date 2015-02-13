#include <iostream>
#include "list.h"

using namespace std;

struct ListElement
{
	int value;
	ListElement *next;
};

struct LinkedList
{
	ListElement *head;
};

ListElement* createNewElement(int value, ListElement* next)
{
	ListElement *newElement = new ListElement;
	newElement->next = next;
	newElement->value = value;
	return newElement;
}

LinkedList* createLinkedList()
{
	LinkedList *list = new LinkedList;
	list->head = createNewElement(0, nullptr);
	return list;
}

LinkedList* addElementLinkedList(int value, LinkedList* list)
{
	list->head->next = createNewElement(value, list->head->next);
	return list;
}

ListElement* firstElement(LinkedList *list)
{
	return list->head->next;
}

ListElement* nextElement(ListElement *current)
{
	return current->next;
}

ListElement* nextField(LinkedList* list, ListElement *firstElementList, ListElement* current)
{
	firstElementList = current->next;
	list->head->next = firstElementList;
	return firstElementList;
}

int valueElement(ListElement *current)
{
	return current->value;
}

void appendNextField(ListElement *current, ListElement *next)
{
	current->next = next;
}

LinkedList* convertToCyclicLinkedList(LinkedList* list)
{
	ListElement *current = list->head;

	while (current->next != nullptr)
	{
		current = current->next;
	}

	current->next = list->head->next;
	return list;
}

void printCyclicLinkedList(LinkedList* list)
{
	ListElement* current = list->head->next;
	cout << current->value;

	while (current->next != list->head->next)
	{
		current = current->next;
		cout << current->value << " ";
	}

	cout << endl;
}

void deleteLinkedList(LinkedList *list)
{
	delete list->head->next;
	delete list->head;
	delete list;
}

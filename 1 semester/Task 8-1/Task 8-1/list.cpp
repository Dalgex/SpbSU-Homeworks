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
	int size = 0;
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

void addElementList(int value, LinkedList* list)
{
	list->head->next = createNewElement(value, list->head->next);
	list->size++;
}

int valueElement(LinkedList* list)
{
	return list->head->next->value;
}

int sizeList(LinkedList* list)
{
	return list->size;
}

LinkedList* invertList(LinkedList* list)
{
	LinkedList *newList = createLinkedList();

	while (list->head->next != nullptr)
	{
		ListElement *current = list->head->next;
		addElementList(current->value, newList);
		list->head->next = current->next;
		delete current;
	}

	return newList;
}

void printList(LinkedList* list)
{
	ListElement *current = list->head;

	while (current->next != nullptr)
	{
		current = current->next;
		cout << current->value << " ";
	}

	cout << endl;
}

int deleteElement(LinkedList* list)
{
	ListElement *current = list->head->next;
	int number = current->value;
	list->head->next = list->head->next->next;
	delete current;
	list->size--;
	return number;
}

void deleteList(LinkedList *list)
{
	ListElement *following = list->head->next;
	ListElement *current = list->head;

	while (current->next != nullptr)
	{
		delete current;
		current = following;
		following = current->next;
	}

	delete current;
	delete list;
}
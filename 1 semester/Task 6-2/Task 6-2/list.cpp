#include <iostream>
#include "list.h"

using namespace std;

// ������� ����� ������� � ������

ListElement* createNewElement(int value, ListElement* next)
{
	ListElement *newElement = new ListElement;
	newElement->next = next;
	newElement->value = value;
	return newElement;
}

// ������� ���������������� ������

LinkedList* createLinkedList()
{
	LinkedList *list = new LinkedList;
	list->head = createNewElement(0, nullptr);
	return list;
}

// ��������� ������� � ������

LinkedList* addElementLinkedList(int value, LinkedList* list)
{
	list->head->next = createNewElement(value, list->head->next);
	return list;
}

// ������� ������

void printedList(LinkedList *list)
{
	ListElement *current = list->head;

	if (current->next == nullptr)
	{
		cout << "������ ����\n";
		return;
	}

	cout << "������: ";

	while (current->next != nullptr)
	{
		current = current->next;
		cout << current->value << " ";
	}

	cout << endl;
}

// ��������� �������� � ������������� ������

LinkedList* addElementSortedList(int value, LinkedList* list)
{
	ListElement *current = list->head->next;
	ListElement *previous = list->head;

	while ((current != nullptr) && (value > current->value))
	{
		previous = current;
		current = current->next;
	}

	previous->next = createNewElement(value, current);
	return list;
}

// ������� ��������� ������� �� ������

LinkedList* removeElementLinkedList(int value, LinkedList *list)
{
	ListElement *current = list->head->next;
	ListElement *previous = list->head;

	if (current == nullptr)
	{
		cout << "��� ����� � ���� ������\n";
		return list;
	}

	while ((current->value != value) && (current->next != nullptr))
	{
		previous = current;
		current = current->next;
	}

	if (current->value == value)
	{
		previous->next = current->next;
		delete current;
	}

	else
	{
		cout << "����� ������� �� ������\n";
	}

	return list;
}

// ����������� ������, ���������� ��� ��� �������� ������

void deleteLinkedList(LinkedList *list)
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

void printOut()
{
	cout << "\n������� �������:\n0 - �����\n1 - �������� �������� � ������������� ������\n2 - ������� �������� �� ������\n3 - ����������� ������\n\n";
}
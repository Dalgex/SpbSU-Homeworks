#include <iostream>
#include "list.h"
#include <string>
#include <fstream>

using namespace std;

struct ListElement
{
	string name;
	int value;
	ListElement *next;
};

struct LinkedList
{
	ListElement *head;
	int size = 0;
};

ListElement* createNewElement(int value, string const &name, ListElement* next)
{
	ListElement *newElement = new ListElement;
	newElement->next = next;
	newElement->value = value;
	newElement->name = name;
	return newElement;
}

LinkedList* createLinkedList()
{
	LinkedList *list = new LinkedList;
	list->head = createNewElement(0, "", nullptr);
	return list;
}

LinkedList* addElementLinkedList(int value, string const &name, LinkedList* list)
{
	list->head->next = createNewElement(value, name, list->head->next);
	list->size++;
	return list;
}

void reading(LinkedList* list)
{
	ifstream file("book.txt", ios::in);

	if (file.is_open())
	{
		while (!file.eof())
		{
			string name;
			int phone = 0;
			file >> name;
			file >> phone;
			if (phone != 0)
			{
				list = addElementLinkedList(phone, name, list);
			}
		}
	}

	file.close();
}

bool comparisonString(ListElement* currentFirst, ListElement* currentSecond)
{
	int i = 0;

	while ((currentFirst->name.size() > i) && (currentSecond->name.size() > i))
	{
		if (currentFirst->name[i] == currentSecond->name[i])
		{
			i++;
		}
		else
		{
			return (currentFirst->name[i] > currentSecond->name[i]);
		}
	}

	return true;
}

ListElement* firstElement(LinkedList* list)
{
	return list->head->next;
}

ListElement* nextElement(ListElement* current)
{
	return current->next;
}

int valueCurrentElement(LinkedList* list, ListElement* current)
{
	return current->value;
}

string nameCurrentElement(LinkedList* list, ListElement* current)
{
	return current->name;
}

int sizeLinkedList(LinkedList* list)
{
	return list->size;
}

LinkedList* invertLinkedList(LinkedList* list)
{
	LinkedList *newList = createLinkedList();

	while (list->head->next != nullptr)
	{
		ListElement *current = list->head->next;
		newList = addElementLinkedList(current->value, current->name, newList);
		list->head->next = current->next;
		delete current;
	}

	return newList;
}

void printList(LinkedList* list)
{
	ListElement *current = list->head;

	if (current->next == nullptr)
	{
		cout << "Список пуст\n";
		return;
	}

	cout << "Список:\n";

	while (current->next != nullptr)
	{
		current = current->next;
		cout << current->name << " " << current->value << "\n";
	}

	cout << endl;
}

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
	cout << "Введите команду:\n0 - выйти\n1 - отсортировать список по номеру телефона\n2 - отсортировать список по именам\n\n";
}
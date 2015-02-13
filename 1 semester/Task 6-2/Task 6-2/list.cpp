#include <iostream>
#include "list.h"

using namespace std;

// Создаем новый элемент в списке

ListElement* createNewElement(int value, ListElement* next)
{
	ListElement *newElement = new ListElement;
	newElement->next = next;
	newElement->value = value;
	return newElement;
}

// Создаем однонаправленный список

LinkedList* createLinkedList()
{
	LinkedList *list = new LinkedList;
	list->head = createNewElement(0, nullptr);
	return list;
}

// Добавляем элемент в список

LinkedList* addElementLinkedList(int value, LinkedList* list)
{
	list->head->next = createNewElement(value, list->head->next);
	return list;
}

// Выводим список

void printedList(LinkedList *list)
{
	ListElement *current = list->head;

	if (current->next == nullptr)
	{
		cout << "Список пуст\n";
		return;
	}

	cout << "Список: ";

	while (current->next != nullptr)
	{
		current = current->next;
		cout << current->value << " ";
	}

	cout << endl;
}

// Добавляем значение в сортированный список

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

// Удаляем указанный элемент из списка

LinkedList* removeElementLinkedList(int value, LinkedList *list)
{
	ListElement *current = list->head->next;
	ListElement *previous = list->head;

	if (current == nullptr)
	{
		cout << "Нет чисел в этом списке\n";
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
		cout << "Такой элемент не найден\n";
	}

	return list;
}

// Освобождаем память, выделенную под все элементы списка

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
	cout << "\nВведите команду:\n0 - выйти\n1 - добавить значение в сортированный список\n2 - удалить значение из списка\n3 - распечатать список\n\n";
}
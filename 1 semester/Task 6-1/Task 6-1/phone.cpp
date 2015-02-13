#include <iostream>
#include "phone.h"
#include <fstream>
#include <string>

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
	return list;
}

string reading(LinkedList* list)
{
	string fileName;
	cout << "Введите имя файла: ";
	cin >> fileName;
	cout << endl;
	ifstream file(fileName, ios::in);

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
	return fileName;
}

void searchPhone(LinkedList* list, string const &name)
{
	ListElement *current = list->head->next;

	if (current == nullptr)
	{
		cout << "База номеров пуста\n";
		return;
	}

	bool isNotName = true;

	while (current != nullptr)
	{
		if (current->name == name)
		{
			isNotName = false;
			int value = current->value;
			cout << "Телефон: " << value << "\n";
		}

		current = current->next;
	}

	if (isNotName)
	{
		cout << "Такого имени не существует\n";
	}

	return;
}

void searchName(LinkedList* list, int value)
{
	ListElement *current = list->head->next;

	if (current == nullptr)
	{
		cout << "База номеров пуста\n";
		return;
	}

	while ((current->value != value) && (current->next != nullptr))
	{
		current = current->next;
	}

	if (current->value == value)
	{
		string name = current->name;
		cout << "Имя: " << name << "\n";
	}

	else
	{
		cout << "Такого телефона не существует\n";
	}

	return;
}

void saveToFile(LinkedList* list, string const &fileName)
{
	ListElement *current = list->head->next;
	ofstream file(fileName, ios::out);

	while (current != nullptr)
	{
		file << current->name << " " << current->value << endl;
		current = current->next;
	}

	file.close();
	cout << "Телефонная книга сохранена\n";
}

void deleteLinkedList(LinkedList* list)
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
	cout << "\nВведите команду:\n0 - выйти\n1 - добавить запись(имя и телефон)\n2 - найти телефон по имени\n3 - найти имя по телефону\n4 - сохранить текущие данные в файл\n\n";
}

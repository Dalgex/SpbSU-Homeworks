#include <iostream>
#include <string>
#include "list.h"

using namespace std;

struct ListElement
{
	string word;
	ListElement *next;
	int counter = 0;  // переменная счетчик. Записываем, сколько раз встретилось нам данное слово
};

struct LinkedList
{
	ListElement *head;
	int size = 0;
};

ListElement* createNewElement(string word, ListElement* next)
{
	ListElement *newElement = new ListElement;
	newElement->word = word;
	newElement->next = next;
	return newElement;
}

LinkedList* createList()
{
	LinkedList *list = new LinkedList;
	list->head = createNewElement("", nullptr);
	return list;
}

void addElementList(string word, LinkedList* list)
{
	ListElement *current = list->head->next;
	while ((current != nullptr) && (current->word != word)) // пока не дошли до конца списка и нашего слова не было
	{
		current = current->next;
	}

	if (current == nullptr) // если current == nullptr, это означает, что слово имеет такой же ключ, как и другое слово, которое лежит в этом спике или этот список еще пуст.
	{
		list->head->next = createNewElement(word, list->head->next);
		list->size++;
		list->head->next->counter++;
	}
	else
	{
		current->counter++; // current != nullptr, т.е. мы нашли слово в списке, которое встретилось в тексте, тогда увеличиваем его количество
	}
}

int listSize(LinkedList* list)
{
	return list->size;
}

int numberOfWords(LinkedList* list)
{
	return list->head->next->counter;
}

string deleteListElement(LinkedList* list)
{
	ListElement *cursor = list->head->next;
	string word = cursor->word;
	list->head->next = list->head->next->next;
	delete cursor;
	list->size--;
	return word;
}

void deleteList(LinkedList* list)
{
	while (list->size > 0)
	{
		deleteListElement(list);
	}

	delete list->head;
	delete list;
}

#pragma once;

struct ListElement {

	int value;
	ListElement *next;
};

struct LinkedList {

	ListElement *head;
};

LinkedList* createLinkedList();

LinkedList* addElementLinkedList(int value, LinkedList* list);

void printedList(LinkedList *list);

LinkedList* addElementSortedList(int value, LinkedList *list);

LinkedList* removeElementLinkedList(int value, LinkedList *list);

void deleteLinkedList(LinkedList *list);

void printOut();
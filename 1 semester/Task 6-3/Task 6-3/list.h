#pragma once

// ���������, ����������� ��� ������ ������
struct ListElement;

// ��� ��� ������
struct LinkedList;

// ������� ����� ������� � ������
ListElement* createNewElement(int value, ListElement* next);

// ������� ���������������� ������
LinkedList* createLinkedList();

// ��������� ������� � ������
LinkedList* addElementLinkedList(int value, LinkedList* list);

// ���������� ��������� �� ������ �������
ListElement* firstElement(LinkedList* list);

// ���������� ��������� �� ��������� �������
ListElement* nextElement(ListElement* current);

// ��������������� ��������� ������
ListElement* nextField(LinkedList* list, ListElement *firstElementList, ListElement* current);

// ���������� �������� �������� ��������
int valueElement(ListElement* current);

// ���������� ���� next � �������� current
void appendNextField(ListElement* current, ListElement* next);

// ��������� ������� ������ ����� ��������� �� ������
LinkedList* convertToCyclicLinkedList(LinkedList* list);

// �������� ����������� ������ (������ �������� � ����������� � ����� �������� ������������ �������� ��������� �� ������������ ������)
void printCyclicLinkedList(LinkedList *list);

// ������� ������
void deleteLinkedList(LinkedList* list);
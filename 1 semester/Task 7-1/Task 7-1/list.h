#pragma once
#include <string>

// ���������, ����������� ��� �������� ������
struct ListElement;

// ��� ��� ������
struct LinkedList;

// ������� ���������������� ������
LinkedList* createLinkedList();

// ��������� ������� � ������
LinkedList* addElementLinkedList(int value, std::string const &name, LinkedList* list);

// ���������� ��������� �� ������ �������
ListElement* firstElement(LinkedList* list);

// ���������� ��������� �� ��������� �������
ListElement* nextElement(ListElement* current);

// ���������� �������� �� ���� value
int valueCurrentElement(LinkedList* list, ListElement* current);

// ���������� �������� �� ���� name
std::string nameCurrentElement(LinkedList* list, ListElement* current);

// ���������� ������ ������
int sizeLinkedList(LinkedList* list);

// �������������� ������
LinkedList* invertLinkedList(LinkedList* list);

// ���������� �����
bool comparisonString(ListElement* currentFirst, ListElement* currentSecond);

// ������ �� �����
void reading(LinkedList* list);

// �������� ������
void printList(LinkedList *list);

// ������� ������
void deleteLinkedList(LinkedList *list);

// ����� �������
void printOut();
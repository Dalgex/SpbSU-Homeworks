#pragma once

// ���������, ����������� ��� �������� ������
struct ListElement;

// ��� ��� ������
struct LinkedList;

// ������� ���������������� ������
LinkedList* createLinkedList();

// ��������� ������� � ������
void addElementList(int value, LinkedList* list);

// ���������� �������� �� ���� value
int valueElement(LinkedList* list);

// ���������� ������ ������
int sizeList(LinkedList* list);

// �������������� ������
LinkedList* invertList(LinkedList* list);

// �������� ������
void printList(LinkedList *list);

// ������� ������� � ���������� ��� ��������
int deleteElement(LinkedList* list);

// ������� ������
void deleteList(LinkedList *list);
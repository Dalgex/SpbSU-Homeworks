#pragma once
#include <string>

struct ListElement;

struct LinkedList;

// ������� ������
LinkedList* createList();

// ��������� ����� � ������
void addElementList(std::string word, LinkedList* list);

// ������ ������
int listSize(LinkedList* list);

// �������, ����� ���������� ����������� ������ ����� � ������
int numberOfWords(LinkedList* list);

// ������� ������� � ���������� �����
std::string deleteListElement(LinkedList* list);

// ������� ������
void deleteList(LinkedList* list);


#pragma once

// ���������, ����������� ��� ������ ������

struct ListElement;

// ��� ��� ������

struct LinkedList;

// ������� ����� ������� � ������

ListElement* createNewElement(int value, std::string const &name, ListElement* next);

// ������� ���������������� ������

LinkedList* createLinkedList();

// ��������� ������� � ������

LinkedList* addElementLinkedList(int value, std::string const &name, LinkedList* list);

// ������ �� �����

std::string reading(LinkedList* list);

// ����� �������� �� �����

void searchPhone(LinkedList* list, std::string const &name);

// ����� ����� �� ��������

void searchName(LinkedList* list, int value);

// ��������� � ����

void saveToFile(LinkedList* list, std::string const &fileName);

// ����������� ������, ���������� ��� ��� �������� ������

void deleteLinkedList(LinkedList* list);

// ����� ������� �� �����

void printOut();


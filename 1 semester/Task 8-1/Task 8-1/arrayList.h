#pragma once

// ��� ��� ������
struct ArrayList;

// ������� ������ �� �������
ArrayList* createArrayList();

// ��������� ������� � ������
void addElementList(int value, ArrayList* arrayList);

// ���������� �������� ���������� ��������
int valueElement(ArrayList* arrayList);

// ���������� ������ ������
int sizeList(ArrayList* arrayList);

// �������������� ������
ArrayList* invertList(ArrayList* arrayList);

// �������� ������
void printList(ArrayList* arrayList);

// ������� ������ � ���������� ��� ��������
int deleteElement(ArrayList* arrayList);

// ������� ������
void deleteList(ArrayList* arrayList);
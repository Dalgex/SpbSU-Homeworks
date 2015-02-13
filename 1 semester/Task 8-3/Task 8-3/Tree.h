#pragma once

typedef char ElementType;

struct TreeElement;

struct Tree;

// ������� ������
Tree* createTree();

// ��������� �������
void addElement(Tree* tree, ElementType value);

// ���������� �������� �����, �.�. ���-� ������ ��������������� ���������. 
int calculateNums(Tree* tree);

// ��������, ��������� �� ������� ��������� � ����
bool isCorrectReading(Tree* tree);

// �������� ������
void printTree(Tree* tree);

// ����������� ������, ���������� ��� ������
void deleteTree(Tree* tree);
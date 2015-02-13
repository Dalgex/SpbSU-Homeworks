#pragma once

typedef int ElementType;

struct TreeElement;

struct Tree;

// ������� ������
Tree* createTree();

// ��������� �������
void addTreeElement(Tree* tree, ElementType value);

// ���������, �������� �� ������ ��������� ��������
bool isContains(Tree* tree, ElementType value);

// �������� ������ � ������� ����������� ��� �������� (������� �� ��������� descending)
void printTree(Tree* tree, bool descending);

// ������ ��������� �������
void removeElement(Tree* tree, ElementType value);

// ��������������� ������� ��� removeElement
void removeElement(TreeElement* &current, ElementType value);

// ������� ��� ��������
void deleteAllElements(Tree* tree);

// ����������� ������, ���������� ��� ������
void deleteTree(Tree* tree);


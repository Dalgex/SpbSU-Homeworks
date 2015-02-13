#pragma once

typedef int ElementType;

struct TreeElement;

struct Tree;

// Создаем дерево
Tree* createTree();

// Добавляем элемент
void addTreeElement(Tree* tree, ElementType value);

// Проверяем, содержит ли дерево указанное значение
bool isContains(Tree* tree, ElementType value);

// Печатаем дерево в порядке возрастания или убывания (зависит от параметра descending)
void printTree(Tree* tree, bool descending);

// Удалем указанный элемент
void removeElement(Tree* tree, ElementType value);

// Вспомогательная функция для removeElement
void removeElement(TreeElement* &current, ElementType value);

// Удаляем все элементы
void deleteAllElements(Tree* tree);

// Освобождаем память, выделенную под дерево
void deleteTree(Tree* tree);


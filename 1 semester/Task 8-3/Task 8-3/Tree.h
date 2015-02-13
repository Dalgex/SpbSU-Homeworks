#pragma once

typedef char ElementType;

struct TreeElement;

struct Tree;

// Создаем дерево
Tree* createTree();

// Добавляем элемент
void addElement(Tree* tree, ElementType value);

// Возвращает значение корня, т.е. рез-т нашего арифметического выражения. 
int calculateNums(Tree* tree);

// Проверка, корректно ли введено выражение в файл
bool isCorrectReading(Tree* tree);

// Печатаем дерево
void printTree(Tree* tree);

// Освобождаем память, выделенную под дерево
void deleteTree(Tree* tree);
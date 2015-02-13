#pragma once
#include <string>

struct ListElement;

struct LinkedList;

// Создаем список
LinkedList* createList();

// Добалвяем слово в список
void addElementList(std::string word, LinkedList* list);

// Размер списка
int listSize(LinkedList* list);

// Находим, какое количество встретилось данное слово в тексте
int numberOfWords(LinkedList* list);

// Удаляем элемент и возвращаем слово
std::string deleteListElement(LinkedList* list);

// Удаляем список
void deleteList(LinkedList* list);


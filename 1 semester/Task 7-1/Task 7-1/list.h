#pragma once
#include <string>

// Структура, описывающая тип элемента списка
struct ListElement;

// Сам тип списка
struct LinkedList;

// Создаем однонаправленный список
LinkedList* createLinkedList();

// Добавляем элемент в список
LinkedList* addElementLinkedList(int value, std::string const &name, LinkedList* list);

// Возвращаем указатель на первый элемент
ListElement* firstElement(LinkedList* list);

// Возвращаем указатель на следующий элемент
ListElement* nextElement(ListElement* current);

// Возвращаем значение из поля value
int valueCurrentElement(LinkedList* list, ListElement* current);

// Возвращаем значение из поля name
std::string nameCurrentElement(LinkedList* list, ListElement* current);

// Возвращаем размер списка
int sizeLinkedList(LinkedList* list);

// Переворачиваем список
LinkedList* invertLinkedList(LinkedList* list);

// Сравниваем имена
bool comparisonString(ListElement* currentFirst, ListElement* currentSecond);

// Читаем из файла
void reading(LinkedList* list);

// Печатаем список
void printList(LinkedList *list);

// Удаляем список
void deleteLinkedList(LinkedList *list);

// Вывод условия
void printOut();
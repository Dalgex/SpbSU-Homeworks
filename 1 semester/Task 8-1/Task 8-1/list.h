#pragma once

// Структура, описывающая тип элемента списка
struct ListElement;

// Сам тип списка
struct LinkedList;

// Создаем однонаправленный список
LinkedList* createLinkedList();

// Добавляем элемент в список
void addElementList(int value, LinkedList* list);

// Возвращаем значение из поля value
int valueElement(LinkedList* list);

// Возвращаем размер списка
int sizeList(LinkedList* list);

// Переворачиваем список
LinkedList* invertList(LinkedList* list);

// Печатаем список
void printList(LinkedList *list);

// Удаляем элемент и возвращаем его значение
int deleteElement(LinkedList* list);

// Удаляем список
void deleteList(LinkedList *list);
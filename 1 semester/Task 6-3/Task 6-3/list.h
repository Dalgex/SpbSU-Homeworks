#pragma once

// Структура, описывающая тип ячейки списка
struct ListElement;

// Сам тип списка
struct LinkedList;

// Создаем новый элемент в списке
ListElement* createNewElement(int value, ListElement* next);

// Создаем однонаправленный список
LinkedList* createLinkedList();

// Добавляем элемент в список
LinkedList* addElementLinkedList(int value, LinkedList* list);

// Возвращаем указатель на первый элемент
ListElement* firstElement(LinkedList* list);

// Возвращаем указатель на следующий элемент
ListElement* nextElement(ListElement* current);

// Восстанавливаем структуру списка
ListElement* nextField(LinkedList* list, ListElement *firstElementList, ListElement* current);

// Возвращаем значение текущего элемента
int valueElement(ListElement* current);

// Прицепляем поле next к элементу current
void appendNextField(ListElement* current, ListElement* next);

// Последний элемент теперь будет указывать на первый
LinkedList* convertToCyclicLinkedList(LinkedList* list);

// Печатаем циклический список (данной функцией я пользовался с целью проверки корректности удаления элементов из циклического списка)
void printCyclicLinkedList(LinkedList *list);

// Удаляем список
void deleteLinkedList(LinkedList* list);
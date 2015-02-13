#pragma once

// Структура, описывающая тип ячейки списка

struct ListElement;

// Сам тип списка

struct LinkedList;

// Создаем новый элемент в списке

ListElement* createNewElement(int value, std::string const &name, ListElement* next);

// Создаем однонаправленный список

LinkedList* createLinkedList();

// Добавляем элемент в список

LinkedList* addElementLinkedList(int value, std::string const &name, LinkedList* list);

// Читаем из файла

std::string reading(LinkedList* list);

// Поиск телефона по имени

void searchPhone(LinkedList* list, std::string const &name);

// Поиск имени по телефону

void searchName(LinkedList* list, int value);

// Сохраняем в файл

void saveToFile(LinkedList* list, std::string const &fileName);

// Освобождаем память, выделенную под все элементы списка

void deleteLinkedList(LinkedList* list);

// Вывод условия на экран

void printOut();


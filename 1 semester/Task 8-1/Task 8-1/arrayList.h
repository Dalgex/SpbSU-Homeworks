#pragma once

// Сам тип списка
struct ArrayList;

// Создаем список на массиве
ArrayList* createArrayList();

// Добавляем элемент в список
void addElementList(int value, ArrayList* arrayList);

// Возвращаем значение последнего элемента
int valueElement(ArrayList* arrayList);

// Возвращаем размер списка
int sizeList(ArrayList* arrayList);

// Переворачиваем список
ArrayList* invertList(ArrayList* arrayList);

// Печатаем список
void printList(ArrayList* arrayList);

// Удаляем список и возвращаем его значение
int deleteElement(ArrayList* arrayList);

// Удаляем список
void deleteList(ArrayList* arrayList);
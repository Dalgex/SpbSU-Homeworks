#pragma once

// Структура, описывающая тип элемента стека
struct StackElement;

// Сам тип стека
struct Stack;

// Создаем стек
Stack* createStack();

// Добавляем в конец стека новый элемент
void push(Stack* stack, char value);

// Удаляем из стека последний элемент и возвращаем его значение 
char pop(Stack* stack);

// Проверка, пустой ли стек
bool isEmpty(Stack* stack);

// Возвращаем значение первого элемента
char valueElement(Stack* stack);

// Очищаем стек
void deleteStack(Stack* stack);


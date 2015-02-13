#pragma once

// Структура, описывающая тип элемента стека
struct StackElement;

// Сам тип стека
struct Stack;

// Создаем стек
Stack* createStack();

// Добавляем в конец стека новый элемент
void push(Stack *stack, int value);

// Удаляем из стека последний элемент и возвращаем его значение 
int pop(Stack *stack);

// Проверка, пустой ли стек
bool isEmpty(Stack *stack);

// Указатель на первый элемент стека
StackElement* firstElement(Stack* stack);

// Указатель на второй элемент стека
StackElement* secondElement(Stack* stack);

// Очищаем стек
void deleteStack(Stack *stack);
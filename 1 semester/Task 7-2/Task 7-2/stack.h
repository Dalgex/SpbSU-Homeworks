#pragma once

// ���������, ����������� ��� �������� �����
struct StackElement;

// ��� ��� �����
struct Stack;

// ������� ����
Stack* createStack();

// ��������� � ����� ����� ����� �������
void push(Stack *stack, int value);

// ������� �� ����� ��������� ������� � ���������� ��� �������� 
int pop(Stack *stack);

// ��������, ������ �� ����
bool isEmpty(Stack *stack);

// ��������� �� ������ ������� �����
StackElement* firstElement(Stack* stack);

// ��������� �� ������ ������� �����
StackElement* secondElement(Stack* stack);

// ������� ����
void deleteStack(Stack *stack);
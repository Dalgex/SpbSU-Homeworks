#pragma once

// ���������, ����������� ��� �������� �����
struct StackElement;

// ��� ��� �����
struct Stack;

// ������� ����
Stack* createStack();

// ��������� � ����� ����� ����� �������
void push(Stack *stack, char value);

// ������� �� ����� ��������� ������� � ���������� ��� �������� 
int pop(Stack *stack);

// ��������, ������ �� ����
bool isEmpty(Stack *stack);

// �������� ���������� ��������
char value(Stack* stack);

// ������� ����
void deleteStack(Stack* stack);
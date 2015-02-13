#pragma once

// ���������, ����������� ��� �������� �����
struct StackElement;

// ��� ��� �����
struct Stack;

// ������� ����
Stack* createStack();

// ��������� � ����� ����� ����� �������
void push(Stack* stack, char value);

// ������� �� ����� ��������� ������� � ���������� ��� �������� 
char pop(Stack* stack);

// ��������, ������ �� ����
bool isEmpty(Stack* stack);

// ���������� �������� ������� ��������
char valueElement(Stack* stack);

// ������� ����
void deleteStack(Stack* stack);


#pragma once

// ��������, �������� �� ������ ������ ������
bool isDigit(char digit);

// ��������, �������� �� ������ ������ �������������� ������
bool isOperation(char operation);

// ��������, �������� �� ������ ������ ����������� �������
bool isOpenBracket(char token);

// ��������, �������� �� ������ ������ ����������� �������
bool isCloseBracket(char token);

// ��������, �������� �� ������ ������ ������� �������
bool isBracket(char token);

// ��������, �������� �� ������ ���������� �������� ����� ����������� �������
bool isOpenBracketStack(Stack* stack);

// ��������, �������� �� ������ ������ ��������
bool isSpace(char token);

// ���������� ������
char space();

// ��������� ��������� ���������� 
int checkPriority(char token);

// �������� �� ������������ ���������� ���������
bool isStringCorrect(Stack* stack, std::string expression);

// ������� �� ��������� ������ � �����������
void postfixNotation(std::string infix, char* postfix, Stack* stack);
#pragma once

bool isDigit(char digit);

bool isOperation(char operation);

bool isAddition(char token);

bool isSubtraction(char token);

bool isMultiplication(char token);

bool isDivision(char token);

// �������� �� ������������ ���������� ���������
bool isCorrectString(std::string expression);
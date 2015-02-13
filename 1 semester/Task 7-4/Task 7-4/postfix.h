#pragma once

// Проверка, является ли данный символ цифрой
bool isDigit(char digit);

// Проверка, является ли данный символ арифметическим знаком
bool isOperation(char operation);

// Проверка, является ли данный символ открывающей скобкой
bool isOpenBracket(char token);

// Проверка, является ли данный символ закрывающей скобкой
bool isCloseBracket(char token);

// Проверка, является ли данный символ круглой скобкой
bool isBracket(char token);

// Проверка, является ли символ последнего элемента стека открывающей скобкой
bool isOpenBracketStack(Stack* stack);

// Проверка, является ли данный символ пробелом
bool isSpace(char token);

// Возвращаем пробел
char space();

// Проверяем приоритет операторов 
int checkPriority(char token);

// Проверка на корректность введенного выражения
bool isStringCorrect(Stack* stack, std::string expression);

// Перевод из инфиксной записи в постфиксную
void postfixNotation(std::string infix, char* postfix, Stack* stack);
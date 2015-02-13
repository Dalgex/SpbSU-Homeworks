#pragma once

// Вычисляем значение
void calculateValues(char operation, Stack* stack);

// Если символ является цифрой, добавляем его в стек
void addNumericalDigit(char digit, Stack* stack);
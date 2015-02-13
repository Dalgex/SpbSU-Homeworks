#pragma once

// Возвращение закрывающей скобки
char getBracket(char bracket);

// Если текущий символ равен закрывающей скобке, то возвращаем true, иначе false
bool closeBracket(char symbol);

// Проверка на корректность скобочной последовательности
bool isStringCorrect(std::string const &str);
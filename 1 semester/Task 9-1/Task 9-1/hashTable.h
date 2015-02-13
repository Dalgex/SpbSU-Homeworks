#pragma once

// Размер хеш-таблицы задаем как константу
int const hashTableSize = 20000;

struct HashTable;

// Создаем хеш-таблицу
HashTable* createHashTable();

// Чтение из файла
HashTable* readingFile(HashTable* hashTable);

// Какое кол-во раз встретилось каждое слово, записываем все в файл
void numberOfWords(HashTable* hashTable);

// Удаляем хеш-таблицу
void deleteHashTable(HashTable* hashTable);


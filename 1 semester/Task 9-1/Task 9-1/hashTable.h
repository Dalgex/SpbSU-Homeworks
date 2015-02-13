#pragma once

// ������ ���-������� ������ ��� ���������
int const hashTableSize = 20000;

struct HashTable;

// ������� ���-�������
HashTable* createHashTable();

// ������ �� �����
HashTable* readingFile(HashTable* hashTable);

// ����� ���-�� ��� ����������� ������ �����, ���������� ��� � ����
void numberOfWords(HashTable* hashTable);

// ������� ���-�������
void deleteHashTable(HashTable* hashTable);


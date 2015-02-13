#include <iostream>
#include <string>
#include "hashTable.h"
#include "list.h"
#include <fstream>

using namespace std;

struct HashTable
{
	LinkedList* hashTableList[hashTableSize];
	int amountOfWords = 0;  // ���������� ���� ���� � ���-�������
};

HashTable* createHashTable()
{
	HashTable *hashTable = new HashTable;

	for (int i = 0; i < hashTableSize; i++)
	{
		hashTable->hashTableList[i] = createList();
	}

	return hashTable;
}

// ���-�������
int hashFunction(string word)
{
	int result = 0;

	for (unsigned int i = 0; i < word.size(); i++)
	{
		srand(word[i]);
		result += rand() * (i + 3);
	}

	return result  % hashTableSize;
}

HashTable* addElementHashTable(string word, HashTable* hashTable)
{
	addElementList(word, hashTable->hashTableList[hashFunction(word)]);
	hashTable->amountOfWords++;
	return hashTable;
}

// ��������, �������� �� ������ ������ ���������� ��� �����, �.�. ��������� �������: ; " ? , . !  � �.�.
bool isWord(char symbol)
{
	return (symbol >= 'a' && symbol <= 'z') || (symbol >= 'A' && symbol <= 'Z') || (symbol >= '0' && symbol <= '9') || (symbol == '-') || (symbol == '\'');
}

HashTable* readingFile(HashTable* hashTable)
{
	ifstream file("Text.txt", ios::in);

	if (!file.is_open())
	{
		cout << "���� �� ������!" << endl;
		return hashTable;
	}

	/*
	��������� �� ����� ����� � ���������� word. ������� �������������� ���������� Word.
	���� ������ �������� ���������� ��� �����, ��������� � Word. ���� ���, �� ���� ������.
	*/
	while (!file.eof())
	{
		string word;
		file >> word;
		string Word;

		for (unsigned int i = 0; i < word.size(); i++)
		{
			if (!isWord(word[i]))
			{
				if (Word.size() > 0)  // ����������� �������� �������� ���: table,book. �� ����� �� �������, ���� ������ �� ������ � �����, ����� ������ ��������: ���� ������ Word ���������, �.�. ��� �������� �����-���� ����� ����, �� ��������� ��� � ���-������� � �������� Word. � ���������� ������ ������
				{
					hashTable = addElementHashTable(Word, hashTable);
					Word = "\0";
				}
			}
			else
			{
				Word += word[i]; 
			}
		}

		if (Word.size() > 0)   // �������� � �������, ���������� ����: table, book. �� �������� ����� table � �������, ����� ���������� ������� � ������� ����� book. �����, ��� ����� ������ 0, ������, ��������� � ��� � ���-�������
		{
			hashTable = addElementHashTable(Word, hashTable);
		}
	}

	file.close();
	return hashTable;
}

void numberOfWords(HashTable* hashTable)
{
	cout << "���������� ����: " << hashTable->amountOfWords << endl;
	ofstream file("hashTable.txt", ios::out);

	for (int i = 0; i < hashTableSize; i++)
	{
		while (listSize(hashTable->hashTableList[i]) != 0)
		{
			int number = numberOfWords(hashTable->hashTableList[i]);
			string word = deleteListElement(hashTable->hashTableList[i]);
			file << word << "  " << number << endl;
		}
	}

	cout << "���� ��������\n";
	file.close();
}

void deleteHashTable(HashTable* hashTable)
{
	for (int i = 0; i < hashTableSize; i++)
	{
		deleteList(hashTable->hashTableList[i]);
	}

	delete hashTable;
}
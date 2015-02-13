#include <iostream>
#include <string>
#include "hashTable.h"
#include "list.h"
#include <fstream>

using namespace std;

struct HashTable
{
	LinkedList* hashTableList[hashTableSize];
	int amountOfWords = 0;  // количество всех слов в хэш-таблице
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

// Хэш-функция
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

// Проверка, является ли данный символ подходящим для слова, т.е. убираются символы: ; " ? , . !  и т.д.
bool isWord(char symbol)
{
	return (symbol >= 'a' && symbol <= 'z') || (symbol >= 'A' && symbol <= 'Z') || (symbol >= '0' && symbol <= '9') || (symbol == '-') || (symbol == '\'');
}

HashTable* readingFile(HashTable* hashTable)
{
	ifstream file("Text.txt", ios::in);

	if (!file.is_open())
	{
		cout << "Файл не найден!" << endl;
		return hashTable;
	}

	/*
	Считываем из файла слово в переменную word. Создаем дополнительную переменную Word.
	Если символ является подходящим для слова, добавляем в Word. Если нет, то идем дальше.
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
				if (Word.size() > 0)  // необходимая проверка например для: table,book. Мы дошли до запятой, этот символ не входит в слово, тогда делаем проверку: если строка Word ненулевая, т.е. уже записано какое-либо слово туда, то добавляем его в хэш-таблицу и обнуляем Word. И продолжаем читать дальше
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

		if (Word.size() > 0)   // вернемся к примеру, описанному выше: table, book. Мы добавали слово table в таблицу, далее пропустили запятую и считали слово book. Видим, что длина больше 0, значит, добавляем и его в хэш-таблицу
		{
			hashTable = addElementHashTable(Word, hashTable);
		}
	}

	file.close();
	return hashTable;
}

void numberOfWords(HashTable* hashTable)
{
	cout << "Количество слов: " << hashTable->amountOfWords << endl;
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

	cout << "Файл сохранен\n";
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
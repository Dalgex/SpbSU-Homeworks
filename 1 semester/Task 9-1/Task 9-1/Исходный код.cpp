#include <iostream>
#include "list.h"
#include "hashTable.h"

using namespace std;

int main()
{
	setlocale(0, "");
	HashTable *hashTable = createHashTable();
	hashTable = readingFile(hashTable);
	numberOfWords(hashTable);
	deleteHashTable(hashTable);
	return 0;
}
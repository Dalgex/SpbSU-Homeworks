#include <iostream>
#include "mergeSort.h"
#include <ctime>

using namespace std;

// Добавляем рандомные элементы в список
void addRandomElements(int length, ListType* list)
{
	srand(time(nullptr));

	for (int i = 0; i < length; i++)
	{
		addElementList(rand() % 30, list);
	}
}

int main()
{
	setlocale(0, "");
	cout << "Введите количество элементов в массиве: ";
	int length = 0;
	cin >> length;

	if (length < 0)
	{
		cout << "Некорректный ввод\n";
		return 0;
	}

	if (length == 0)
	{
		cout << "Список пуст\n";
		return 0;
	}

	ListType *list = createLinkedList();
	//ListType *list = createArrayList();
	addRandomElements(length, list);
	cout << "Список:\n";
	printList(list);
	list = mergeSort(list);
	cout << "Отсортированный список:\n";
	printList(list);
	deleteList(list);
	return 0;
}
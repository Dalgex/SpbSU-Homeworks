#include <iostream>
#include "list.h"

using namespace std;

int main()
{
	setlocale(0, "");
	LinkedList *list = createLinkedList();
	bool isWorking = true;
	printOut();

	while (isWorking)
	{
		int choice = 0;
		cin >> choice;
		switch (choice)
		{
		case 0:
		{
				  isWorking = false;
				  break;
		}

		case 1:
		{
				  int value = 0;
				  cout << "Введите ваше число: ";
				  cin >> value;
				  list = addElementSortedList(value, list);
				  break;
		}

		case 2:
		{
				  int value = 0;
				  cout << "Введите число, которое хотели бы удалить: ";
				  cin >> value;
				  list = removeElementLinkedList(value, list);
				  break;
		}

		case 3:
		{
				  printedList(list);
				  break;
		}

		default:
		{
				   cout << "Некорректный ввод\n";
				   break;
		}

		}

		if (isWorking)
		{
			printOut();
		}

		else
		{
			cout << "Вы завершили работу\n";
		}

	}

	deleteLinkedList(list);
	return 0;
}
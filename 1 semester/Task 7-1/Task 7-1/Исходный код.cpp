#include <iostream>
#include "list.h"
#include <fstream>
#include <string>
#include "mergeSort.h"

using namespace std;

int main()
{
	setlocale(0, "");
	LinkedList *list = createLinkedList();
	bool isWorking = true;
	reading(list);
	list = invertLinkedList(list);
	printList(list);
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
				cout << "���������� ������� �� ������ ��������:\n";
				list = mergeSort(list, true);
				printList(list);
				break;
			}

			case 2:
			{
				cout << "���������� ������� �� �����:\n";
				list = mergeSort(list, false);
				printList(list);
				break;
			}

			default:
			{
				cout << "������������ ����\n";
				break;
			}
		}

		if (isWorking)
		{
			printOut();
		}
		else
		{
			cout << "�� ��������� ������\n";
		}
	}

	deleteLinkedList(list);
	return 0;
}
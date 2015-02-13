#include <iostream>
#include <fstream>
#include <string>
#include "phone.h"

using namespace std;

int main()
{
	setlocale(0, "");
	LinkedList *list = createLinkedList();
	string fileName = reading(list);
	
	bool isWorking = true;
	cout << "��� ������� �� ���������� �����";
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
				string name;
				cout << "������� ���: ";
				cin >> name;
				int phone = 0;
				cout << "������� ����� ��������: ";
				cin >> phone;
				list = addElementLinkedList(phone, name, list);
				break;
			}

			case 2:
			{
				string name;
				cout << "������� ���: ";
				cin >> name;
				searchPhone(list, name);
				break;
			}

			case 3:
			{
				int phone = 0;
				cout << "������� ����� ��������: ";
				cin >> phone;
				searchName(list, phone);
				break;
			}

			case 4:
			{
				saveToFile(list, fileName);
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
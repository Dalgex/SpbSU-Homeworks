#include <iostream>
#include "Tree.h"

using namespace std;

void printOut()
{
	cout << "\n\n������� �������:\n0 - �����\n1 - �������� �������� � ���������\n2 - ������� ��������\n3 - ��������, ����������� �� ������ �������� ���������\n4 - ������ ��������� � ������� �����������\n5 - ������ ��������� � ������� ��������\n6 - ������� ��� �������� �� ������\n\n";
}

int main()
{
	setlocale(0, "");
	Tree* tree = createTree();
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
				int number = 0;
				cout << "������� ��������: ";
				cin >> number;
				addTreeElement(tree, number);
				cout << "�������� ���������";
				break;
			}

			case 2:
			{
				int number = 0;
				cout << "������� ��������, ������� ������ �� �������: ";
				cin >> number;
				removeElement(tree, number);
				break;
			}

			case 3:
			{
				cout << "������� �����: ";
				int number = 0;
				cin >> number;

				if (isContains(tree, number))
				{
					cout << "�����������";
				}
				else
				{
					cout << "�� �����������";
				}

				break;
			}

			case 4:
			{
				cout << "�������� � ������� �����������:\n";
				printTree(tree, false);
				break;
			}

			case 5:
			{
				cout << "�������� � ������� ��������:\n";
				printTree(tree, true);
				break;
			}

			case 6:
			{
				deleteAllElements(tree);
				cout << "��� �������� �������";
				break;
			}

			default:
			{
				cout << "������������ ����";
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

	deleteTree(tree);
	return 0;
}
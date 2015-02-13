#include <iostream>
#include "Tree.h"

using namespace std;

void printOut()
{
	cout << "\n\nВведите команду:\n0 - выйти\n1 - добавить значение в множество\n2 - удалить значение\n3 - проверка, принадлежит ли данное значение множеству\n4 - печать элементов в порядке возрастания\n5 - печать элементов в порядке убывания\n6 - удалить все элементы из дерева\n\n";
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
				cout << "Введите значение: ";
				cin >> number;
				addTreeElement(tree, number);
				cout << "Значение добавлено";
				break;
			}

			case 2:
			{
				int number = 0;
				cout << "Введите значение, которое хотели бы удалить: ";
				cin >> number;
				removeElement(tree, number);
				break;
			}

			case 3:
			{
				cout << "Введите число: ";
				int number = 0;
				cin >> number;

				if (isContains(tree, number))
				{
					cout << "Принадлежит";
				}
				else
				{
					cout << "Не принадлежит";
				}

				break;
			}

			case 4:
			{
				cout << "Элементы в порядке возрастания:\n";
				printTree(tree, false);
				break;
			}

			case 5:
			{
				cout << "Элементы в порядке убывания:\n";
				printTree(tree, true);
				break;
			}

			case 6:
			{
				deleteAllElements(tree);
				cout << "Все элементы удалены";
				break;
			}

			default:
			{
				cout << "Некорректный ввод";
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

	deleteTree(tree);
	return 0;
}
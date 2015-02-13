#include <iostream>
#include "list.h"

using namespace std;

int main()
{
	setlocale(0, "");
	LinkedList *list = createLinkedList();
	int soldiers = 0;
	int orderOfKill = 0;
	cout << "Данная программа определяет номер k начальной позиции воина, который должен будет остаться последним.\
	Воины встают в круг и каждого m-го солдата убивают\n";

	cout << "Количество воинов: ";
	cin >> soldiers;
	cout << "Каждый m-ый воин умрет: ";
	cin >> orderOfKill;

	for (int i = soldiers; i > 0; i--)
	{
		addElementLinkedList(i, list);
	}

	ListElement *firstElementList = firstElement(list);
	list = convertToCyclicLinkedList(list);
	ListElement *current = firstElementList;
	ListElement *previous = firstElementList;

	while (nextElement(previous) != current)
	{
		previous = nextElement(previous);
	}

	int i = 0;

	while (nextElement(current) != current)
	{
		i++;

		if (i % orderOfKill == 0)
		{
			if (firstElementList == current)
			{
				firstElementList = nextField(list, firstElementList, current);
			}

			appendNextField(previous, nextElement(current));
			delete current;
			current = nextElement(previous);
		}

		else
		{
			current = nextElement(current);
			previous = nextElement(previous);
		}
	}

	cout << valueElement(current) << endl;
	deleteLinkedList(list);
	return 0;
}



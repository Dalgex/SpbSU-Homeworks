#include <iostream>
#include "graph.h"
#include <vector>

using namespace std;

// Выводим на консоль номера государств и списки городов, принадлежащих государствам.
void printNumberOfCities(vector<int> &numberOfState)
{
	for (unsigned int i = 0; i < numberOfState.size(); i++)
	{
		if (numberOfState[i] == i)  // если государство...
		{
			cout << "Номер государства: " << numberOfState[i] << "\nГорода, принадлежащие данному государству: ";

			for (unsigned int j = 0; j < numberOfState.size(); j++)
			{
				if (numberOfState[j] == i && i != j) 
				{
					cout << j << " "; // выводим номера городов, принадлежащих государству numberOfState[i]
				}
			}

			cout << "\n\n";
		}
	}
}

int main()
{
	setlocale(0, "");
	vector<int> numberOfState;  // массив, в котором будут храниться номера государств и свободные города. Позже мы определим, сколько у нас государств и тогда уже будем присоединять кажому государству незанятый город
	unsigned int countOfAddedCities = 0; //количество добавленных уже городов.это там понадобится для цикла, который будет использован в функции joinCities
	int **graph = nullptr;  // объявляем граф (создание графа будет в функции readingFile)
	readingFile(graph, numberOfState, countOfAddedCities); 
	joinCities(graph, numberOfState, countOfAddedCities);
	printNumberOfCities(numberOfState);
	deleteGraph(graph, numberOfState);
	return 0;
}

/*
Входные данные в файле:
6 7
0 1 5
0 2 13
1 2 6
2 5 6
4 5 2
4 3 3
0 3 10
2 0 4

Программа вывела:
Государству 0 принадлежат города: 1, 2
Государству 4 принадлежат города: 3, 5
*/
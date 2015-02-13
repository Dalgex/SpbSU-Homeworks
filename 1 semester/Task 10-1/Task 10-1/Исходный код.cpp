#include <iostream>
#include "graph.h"
#include <vector>

using namespace std;

// ������� �� ������� ������ ���������� � ������ �������, ������������� ������������.
void printNumberOfCities(vector<int> &numberOfState)
{
	for (unsigned int i = 0; i < numberOfState.size(); i++)
	{
		if (numberOfState[i] == i)  // ���� �����������...
		{
			cout << "����� �����������: " << numberOfState[i] << "\n������, ������������� ������� �����������: ";

			for (unsigned int j = 0; j < numberOfState.size(); j++)
			{
				if (numberOfState[j] == i && i != j) 
				{
					cout << j << " "; // ������� ������ �������, ������������� ����������� numberOfState[i]
				}
			}

			cout << "\n\n";
		}
	}
}

int main()
{
	setlocale(0, "");
	vector<int> numberOfState;  // ������, � ������� ����� ��������� ������ ���������� � ��������� ������. ����� �� ���������, ������� � ��� ���������� � ����� ��� ����� ������������ ������ ����������� ��������� �����
	unsigned int countOfAddedCities = 0; //���������� ����������� ��� �������.��� ��� ����������� ��� �����, ������� ����� ����������� � ������� joinCities
	int **graph = nullptr;  // ��������� ���� (�������� ����� ����� � ������� readingFile)
	readingFile(graph, numberOfState, countOfAddedCities); 
	joinCities(graph, numberOfState, countOfAddedCities);
	printNumberOfCities(numberOfState);
	deleteGraph(graph, numberOfState);
	return 0;
}

/*
������� ������ � �����:
6 7
0 1 5
0 2 13
1 2 6
2 5 6
4 5 2
4 3 3
0 3 10
2 0 4

��������� ������:
����������� 0 ����������� ������: 1, 2
����������� 4 ����������� ������: 3, 5
*/
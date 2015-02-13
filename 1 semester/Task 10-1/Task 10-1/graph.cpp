#include <iostream>
#include "graph.h"
#include <fstream>
#include <vector>

using namespace std;

// ������� ���� 
int **createGraph(int countOfCities)
{
	int **graph = new int*[countOfCities];  //graph ��������� �� ������ ���������� int*[countOfCities]

	for (int i = 0; i < countOfCities; i++)
	{
		graph[i] = new int[countOfCities]; // ������ ������ ������� ���������� ������ ��� countOfCities ���������
	}  // ����� ������� ������ ��������� ������ ��� ������� ���������

	for (int i = 0; i < countOfCities; i++)
	{
		for (int j = 0; j < countOfCities; j++)
		{
			graph[i][j] = 0;  // �������� ������� ���������
		}
	}

	return graph;
}

// ��������� ����� ������ ����� ����� �������� � ������� ���������
void addRoad(int** array, int city1, int city2, int lengthOfRoad)
{
	array[city1][city2] = lengthOfRoad;
	array[city2][city1] = lengthOfRoad;
}

void deleteGraph(int **graph, vector<int> numberOfState)
{
	for (unsigned int i = 0; i < numberOfState.size(); i++)
	{
		delete[] graph[i];
	}

	delete[] graph;
}

// ���������� ����� ������ ����� ����� ��������
int lengthOfRoad(int **graph, int city1, int city2)
{
	return graph[city1][city2];
}

// ����� ������ ��������� ����
int searchNearestUnoccupiedCity(int** graph, vector<int> numberOfState, int &numberOfCity)
{
	int shortestRoad = INT_MAX; // ����� �������� ������
	int tempCity = numberOfCity; // ��������� ���������� ��� �������� ������ ������� ������, �.�. numberOfCity ����� ���������� � �����

	for (unsigned int i = 0; i < numberOfState.size(); i++)
	{
		if (lengthOfRoad(graph, tempCity, i) == 0) // ���� ���������� ����� ����, ��, ������, ��� ������
		{
			continue;
		}
		else
		{
			if (lengthOfRoad(graph, tempCity, i) < shortestRoad && numberOfState[i] == -1) // ���� ����� ������ ������ ���������� ������ � ����� i ���������
			{
				shortestRoad = lengthOfRoad(graph, tempCity, i);
				numberOfCity = i;
			}
		}
	}

	return shortestRoad;
}

// �������� �� ������ ����� ������������ � ������������� ����������� 
bool isCityAbleToJoin(vector<int> &numberOfState, int **graph, int numberOfCity)
{
	int nearestCity = -1; // ��������� ����� � numberOfCity
	int distanceToNearestCity = INT_MAX; // ���������� �� ���������� ������

	for (unsigned int i = 0; i < numberOfState.size(); i++)
	{
		if (numberOfState[i] == numberOfCity)  // ���� ����� ����������� �����������
		{
			int tempCity = i; // ������� ��������� ���������� ��� �������� ������ i-�� ������
			int tempRoad = searchNearestUnoccupiedCity(graph, numberOfState, tempCity); // ���� ����� ����������� ���� �� i-�� ������ �� ������-���� ���������� � ��� ������

			if (tempRoad < distanceToNearestCity) 
			{
				distanceToNearestCity = tempRoad;
				nearestCity = tempCity;
			}
		}
	}

	if (distanceToNearestCity != INT_MAX) // ���� �����-���� ����� ������
	{
		numberOfState[nearestCity] = numberOfCity; // ��������� ��� � �����������
		return true;
	}

	return false;
}

void joinCities(int** graph, vector<int> &numberOfState, unsigned int &countOfAddedCities)
{
	for (unsigned int i = 0; countOfAddedCities < numberOfState.size(); ++i, i %= numberOfState.size())  // �� ������� ������� ����������� ����������� ��������� ��������� �����, ������� � ����� ������ i%=...
	{
		if (numberOfState[i] == i)  // ���� �����������...
		{
			if (isCityAbleToJoin(numberOfState, graph, i)) // ���� �����-���� ��������� ����� ���������� ������������ � �����������
			{
				countOfAddedCities++; // ����������� ���������� ����������� �������
			}
		}
	}
}

void readingFile(int** &graph, vector<int> &numberOfState, unsigned int &countOfAddedCities)
{
	ifstream file("Cities and roads.txt", ios::in);

	if (!file.is_open())
	{
		cout << "���� �� ������. ������!";
		return;
	}

	while (!file.eof())
	{
		int countOfCities = 0;
		file >> countOfCities;  // ��������� ���������� �������
		graph = createGraph(countOfCities); // ������� ����
		numberOfState.resize(countOfCities);

		for (int i = 0; i < countOfCities; i++)
		{
			numberOfState[i] = -1; // ��� ��������� ������ ���������������� -1
		}

		int countOfRoads = 0;
		file >> countOfRoads;  // ��������� ���-�� �����

		for (int i = 0; i < countOfRoads; i++)
		{
			int city1 = 0;
			int city2 = 0;
			int lengthOfRoad = 0;
			file >> city1; 
			file >> city2;
			file >> lengthOfRoad;
			addRoad(graph, city1, city2, lengthOfRoad);  // ��������� � ������� ��������� �������� ���� ����� ����� ����� ��������
		}

		int countOfCapitals = 0;
		file >> countOfCapitals;  // ��������� ���-�� ������

		for (int i = 0; i < countOfCapitals; i++)
		{
			int numberOfCapital = 0;
			file >> numberOfCapital; // ��������� ����� �������
			numberOfState[numberOfCapital] = numberOfCapital;  // ���������� � ����� ������� ������ ������
			countOfAddedCities++; 
		}
	}

	file.close();
}
#include <iostream>
#include "graph.h"
#include <fstream>
#include <vector>

using namespace std;

// Создаем граф 
int **createGraph(int countOfCities)
{
	int **graph = new int*[countOfCities];  //graph ссылается на массив указателей int*[countOfCities]

	for (int i = 0; i < countOfCities; i++)
	{
		graph[i] = new int[countOfCities]; // каждой строке массива выделяется память под countOfCities элементов
	}  // таким образом задаем двумерный массив под матрицу смежности

	for (int i = 0; i < countOfCities; i++)
	{
		for (int j = 0; j < countOfCities; j++)
		{
			graph[i][j] = 0;  // обнуляем матрицу смежности
		}
	}

	return graph;
}

// Добавляем длину дороги между двумя городами в матрицу смежности
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

// Возвращаем длину дороги между двумя городами
int lengthOfRoad(int **graph, int city1, int city2)
{
	return graph[city1][city2];
}

// Поиск самого короткого пути
int searchNearestUnoccupiedCity(int** graph, vector<int> numberOfState, int &numberOfCity)
{
	int shortestRoad = INT_MAX; // самая короткая дорога
	int tempCity = numberOfCity; // временная переменная для хранения номера данного города, т.к. numberOfCity может поменяться в цикле

	for (unsigned int i = 0; i < numberOfState.size(); i++)
	{
		if (lengthOfRoad(graph, tempCity, i) == 0) // если расстояние равно нулю, то, значит, нет дороги
		{
			continue;
		}
		else
		{
			if (lengthOfRoad(graph, tempCity, i) < shortestRoad && numberOfState[i] == -1) // если длина дороги меньше кратчайшей дороги и город i свободный
			{
				shortestRoad = lengthOfRoad(graph, tempCity, i);
				numberOfCity = i;
			}
		}
	}

	return shortestRoad;
}

// Возможно ли данный город присоединить к определенному государству 
bool isCityAbleToJoin(vector<int> &numberOfState, int **graph, int numberOfCity)
{
	int nearestCity = -1; // ближайший город к numberOfCity
	int distanceToNearestCity = INT_MAX; // расстояние до ближайшего города

	for (unsigned int i = 0; i < numberOfState.size(); i++)
	{
		if (numberOfState[i] == numberOfCity)  // если город принадлежит государству
		{
			int tempCity = i; // создаем временную переменную для хранения номера i-го города
			int tempRoad = searchNearestUnoccupiedCity(graph, numberOfState, tempCity); // ищем длину кратчайшего пути от i-го города до какого-либо связанного с ним города

			if (tempRoad < distanceToNearestCity) 
			{
				distanceToNearestCity = tempRoad;
				nearestCity = tempCity;
			}
		}
	}

	if (distanceToNearestCity != INT_MAX) // если какой-либо город найден
	{
		numberOfState[nearestCity] = numberOfCity; // добавляем его к государству
		return true;
	}

	return false;
}

void joinCities(int** graph, vector<int> &numberOfState, unsigned int &countOfAddedCities)
{
	for (unsigned int i = 0; countOfAddedCities < numberOfState.size(); ++i, i %= numberOfState.size())  // по очереди каждому государству добавляется ближайший незанятый город, поэтому в конце делаем i%=...
	{
		if (numberOfState[i] == i)  // если государство...
		{
			if (isCityAbleToJoin(numberOfState, graph, i)) // если какой-либо свободный город получилось присоединить к государству
			{
				countOfAddedCities++; // увеличиваем количество добавленных городов
			}
		}
	}
}

void readingFile(int** &graph, vector<int> &numberOfState, unsigned int &countOfAddedCities)
{
	ifstream file("Cities and roads.txt", ios::in);

	if (!file.is_open())
	{
		cout << "Файл не найден. Ошибка!";
		return;
	}

	while (!file.eof())
	{
		int countOfCities = 0;
		file >> countOfCities;  // считываем количество городов
		graph = createGraph(countOfCities); // создаем граф
		numberOfState.resize(countOfCities);

		for (int i = 0; i < countOfCities; i++)
		{
			numberOfState[i] = -1; // все свободные города инициализируются -1
		}

		int countOfRoads = 0;
		file >> countOfRoads;  // считываем кол-во дорог

		for (int i = 0; i < countOfRoads; i++)
		{
			int city1 = 0;
			int city2 = 0;
			int lengthOfRoad = 0;
			file >> city1; 
			file >> city2;
			file >> lengthOfRoad;
			addRoad(graph, city1, city2, lengthOfRoad);  // добавляем в матрицу смежности значения длин дорог между двумя городами
		}

		int countOfCapitals = 0;
		file >> countOfCapitals;  // считываем кол-во столиц

		for (int i = 0; i < countOfCapitals; i++)
		{
			int numberOfCapital = 0;
			file >> numberOfCapital; // считываем номер столицы
			numberOfState[numberOfCapital] = numberOfCapital;  // определяем в нашем массиве номера столиц
			countOfAddedCities++; 
		}
	}

	file.close();
}
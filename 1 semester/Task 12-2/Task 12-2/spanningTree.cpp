#include <iostream>
#include <vector>
#include <fstream>

using namespace std;

// Создаем граф
int** createGraph(int size)
{
	int **graph = new int*[size];

	for (int i = 0; i < size; i++)
	{
		graph[i] = new int[size];
	}

	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			graph[i][j] = 0;
		}
	}

	return graph;
}

// Вес ребра между вершинами vertex1 и vertex2
int weightOfEdge(int **graph, int vertex1, int vertex2)
{
	return graph[vertex1][vertex2];
}

void readingFile(int** &graph, vector<int> &spanningTree)
{
	ifstream file("AdjacencyMatrix.txt", ios::in);

	if (!file.is_open())
	{
		cout << "Error! File was not found";
		return;
	}

	int size = 0;
	file >> size; // считываем размер матрицы смежности
	graph = createGraph(size); // создаем граф
	spanningTree.resize(size);

	for (int i = 1; i < size; i++)  // все вершины инициализируем минус единицей, кроме первой, т.е. вершина с индексом 0 будет равна 0. Это и будет наша исходная вершина, к которой будем присоединять другие вершины
	{
		spanningTree[i] = -1;
	}

	while (!file.eof())
	{
		int number = 0;

		for (int i = 0; i < size; i++)
		{
			for (int j = 0; j < size; j++)
			{
				file >> number;
				graph[i][j] = number; // заполняем наш граф элементами матрицы смежности из файла
			}
		}
	}

	file.close();
}

// Ищем самое легкое ребро от вершины numVertex
int findMinimumWeightEdge(int **graph, vector<int> spanningTree, int &numVertex)
{
	int minimumWeigthEdge = INT_MAX; // самое легкое ребро
	int tempVertex = numVertex; //  // временная переменная для хранения номера данной вершины, т.к. numOfVertex может поменяться в цикле

	for (unsigned int i = 0; i < spanningTree.size(); i++)
	{
		if (weightOfEdge(graph, tempVertex, i) != 0)  // если вершины tempVertex и i соединены ребром 
		{
			if (weightOfEdge(graph, tempVertex, i) < minimumWeigthEdge && spanningTree[i] == -1)  // если расстояние между tempvertex и i меньше минимального расстояния и вершина i не принадлежит дереву
			{
				minimumWeigthEdge = weightOfEdge(graph, tempVertex, i);
				numVertex = i; // запоминаем вершину, до которой к нашему дереву самое короткое расстояние
			}
		}
	}

	return minimumWeigthEdge;
}

// На каждом шаге алгоритма к текущему дереву присоединяется самое лёгкое из рёбер, 
// соединяющих вершину из построенного дерева и вершину не из дерева.
void addVertex(int **graph, vector<int> &spanningTree, int numOfVertex)
{
	int nearestVertex = -1; // ближайшая вершина
	int minimumWeightEdge = INT_MAX; // самое легкое ребро
	int vertex = -1; // создаем переменную, в которую будем записывать, из какой вершины мы нашли ближайшую вершину к дереву

	for (unsigned int i = 0; i < spanningTree.size(); i++)
	{
		if (spanningTree[i] == numOfVertex) // если вершина принадлежит дереву
		{
			int tempVertex = i;  // создаем временную переменную для хранения номера i-ой вершины
			int tempEdge = findMinimumWeightEdge(graph, spanningTree, tempVertex);  // ищем кратчайшее расстояние от вершины tempVertex 

			if (tempEdge < minimumWeightEdge)  // если ребро весит меньше самого легкого ребра
			{
				minimumWeightEdge = tempEdge;  
				nearestVertex = tempVertex; // номер ближайшей вершину к построенному дереву
				vertex = i; // значит, на данный момент, кратчайшее расстояние будет из вершины i до вершины nearestVertex
			}
		}
	}

	spanningTree[nearestVertex] = numOfVertex; // добавляем nearestVertex к нашему дереву
	cout << vertex + 1 << " --> " << nearestVertex + 1 << "  Length: " << minimumWeightEdge << endl; 
	/*
	И сразу же выводим, из какой вершины, куда и сколько весит ребро между ними.
	Прибавляем единицу к vertex и nearestVertex, т.к. у нашего массива индексы начинаются с 0, а мы будем считать, что
	вершины нумеруются, начиная с единицы
	*/
}

void deleteGraph(int **graph, vector<int> spanningTree)
{
	for (unsigned int i = 0; i < spanningTree.size(); i++)
	{
		delete[] graph[i];
	}

	delete[] graph;
}
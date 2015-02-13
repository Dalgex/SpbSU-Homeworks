#include <iostream>
#include <vector>
#include <fstream>

using namespace std;

// ������� ����
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

// ��� ����� ����� ��������� vertex1 � vertex2
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
	file >> size; // ��������� ������ ������� ���������
	graph = createGraph(size); // ������� ����
	spanningTree.resize(size);

	for (int i = 1; i < size; i++)  // ��� ������� �������������� ����� ��������, ����� ������, �.�. ������� � �������� 0 ����� ����� 0. ��� � ����� ���� �������� �������, � ������� ����� ������������ ������ �������
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
				graph[i][j] = number; // ��������� ��� ���� ���������� ������� ��������� �� �����
			}
		}
	}

	file.close();
}

// ���� ����� ������ ����� �� ������� numVertex
int findMinimumWeightEdge(int **graph, vector<int> spanningTree, int &numVertex)
{
	int minimumWeigthEdge = INT_MAX; // ����� ������ �����
	int tempVertex = numVertex; //  // ��������� ���������� ��� �������� ������ ������ �������, �.�. numOfVertex ����� ���������� � �����

	for (unsigned int i = 0; i < spanningTree.size(); i++)
	{
		if (weightOfEdge(graph, tempVertex, i) != 0)  // ���� ������� tempVertex � i ��������� ������ 
		{
			if (weightOfEdge(graph, tempVertex, i) < minimumWeigthEdge && spanningTree[i] == -1)  // ���� ���������� ����� tempvertex � i ������ ������������ ���������� � ������� i �� ����������� ������
			{
				minimumWeigthEdge = weightOfEdge(graph, tempVertex, i);
				numVertex = i; // ���������� �������, �� ������� � ������ ������ ����� �������� ����������
			}
		}
	}

	return minimumWeigthEdge;
}

// �� ������ ���� ��������� � �������� ������ �������������� ����� ����� �� ����, 
// ����������� ������� �� ������������ ������ � ������� �� �� ������.
void addVertex(int **graph, vector<int> &spanningTree, int numOfVertex)
{
	int nearestVertex = -1; // ��������� �������
	int minimumWeightEdge = INT_MAX; // ����� ������ �����
	int vertex = -1; // ������� ����������, � ������� ����� ����������, �� ����� ������� �� ����� ��������� ������� � ������

	for (unsigned int i = 0; i < spanningTree.size(); i++)
	{
		if (spanningTree[i] == numOfVertex) // ���� ������� ����������� ������
		{
			int tempVertex = i;  // ������� ��������� ���������� ��� �������� ������ i-�� �������
			int tempEdge = findMinimumWeightEdge(graph, spanningTree, tempVertex);  // ���� ���������� ���������� �� ������� tempVertex 

			if (tempEdge < minimumWeightEdge)  // ���� ����� ����� ������ ������ ������� �����
			{
				minimumWeightEdge = tempEdge;  
				nearestVertex = tempVertex; // ����� ��������� ������� � ������������ ������
				vertex = i; // ������, �� ������ ������, ���������� ���������� ����� �� ������� i �� ������� nearestVertex
			}
		}
	}

	spanningTree[nearestVertex] = numOfVertex; // ��������� nearestVertex � ������ ������
	cout << vertex + 1 << " --> " << nearestVertex + 1 << "  Length: " << minimumWeightEdge << endl; 
	/*
	� ����� �� �������, �� ����� �������, ���� � ������� ����� ����� ����� ����.
	���������� ������� � vertex � nearestVertex, �.�. � ������ ������� ������� ���������� � 0, � �� ����� �������, ���
	������� ����������, ������� � �������
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
#pragma once
#include <vector>

// ������ �� �����
void readingFile(int** &graph, std::vector<int> &numberOfVertex);

// ��������� ������� � �������� ������
void addVertex(int **graph, std::vector<int> &numberOfVertex, int numOfVertex);

// ������� ����
void deleteGraph(int **graph, std::vector<int> spanningTree);
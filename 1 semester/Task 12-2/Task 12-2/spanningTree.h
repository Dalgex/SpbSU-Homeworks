#pragma once
#include <vector>

// Читаем из файла
void readingFile(int** &graph, std::vector<int> &numberOfVertex);

// Добавляем вершину к текущему дереву
void addVertex(int **graph, std::vector<int> &numberOfVertex, int numOfVertex);

// Удаляем граф
void deleteGraph(int **graph, std::vector<int> spanningTree);
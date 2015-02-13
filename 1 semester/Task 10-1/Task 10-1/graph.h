#pragma once
#include <vector>

// ��������� �� ����� ������� ������
void readingFile(int** &graph, std::vector<int> &numberOfState, unsigned int &countOfAddedCities);

// ������������ ������ ����� �������������
void joinCities(int** graph, std::vector<int> &numberOfState, unsigned int &countOfAddedCities);

// ������� ����
void deleteGraph(int **graph, std::vector<int> numberOfState);
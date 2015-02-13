#pragma once
#include <vector>

// Считываем из файла входные данные
void readingFile(int** &graph, std::vector<int> &numberOfState, unsigned int &countOfAddedCities);

// Распределяем города между государствами
void joinCities(int** graph, std::vector<int> &numberOfState, unsigned int &countOfAddedCities);

// Удаляем граф
void deleteGraph(int **graph, std::vector<int> numberOfState);
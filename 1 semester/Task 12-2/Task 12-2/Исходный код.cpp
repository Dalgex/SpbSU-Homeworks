#include <iostream>
#include "spanningTree.h"

using namespace std;

int main()
{
	int **graph = nullptr; // ��������� ���� (�������� ����� ����� � ������� readingFile)
	vector<int> spanningTree; // ������, � ������� ����� ��������� �������� ���������� ������. � ������� ����� ������� �� � ����� ������� ���� ����������� �������� ������, ��������� �������� ����� ������� ��. � ������� readingFile 
	readingFile(graph, spanningTree);

	for (unsigned int i = 0; i < spanningTree.size() - 1; i++)
	{
		addVertex(graph, spanningTree, 0); // ������������ � ������ ��������� �������. ������ ����� �� ������� �������, ������� � �������� ��������� � ������� addVertex ����� 0
	}

	deleteGraph(graph, spanningTree);
	return 0;
}

/*
4
0 3 0 2
3 0 1 4
0 1 0 3
2 4 3 0

1 --> 4  Length: 2
1 --> 2  Length: 3
2 --> 3  Length: 1


6
0 0 4 3 0 5
0 0 0 1 0 7
4 0 0 6 2 0
3 1 6 0 0 0
0 0 2 0 0 4
5 7 0 0 4 0

1 --> 4  Length: 3
4 --> 2  Length: 1
1 --> 3  Length: 4
3 --> 5  Length: 2
5 --> 6  Length: 4
*/
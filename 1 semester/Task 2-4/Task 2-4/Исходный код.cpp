#include <iostream>
#include <ctime>

using namespace std;

/* ��������� � ��������������� �������: ��� �������� �������, ������ �������, �������� ����� �� ����.
��������������, ��������, ������ �������, ������������� �������� ������. �� ��� ���� ��� ������ ������� ����� ����������,
������� �� ������ ���������� mainIndex, ������� ����� ������� �� �������� ����� ��������.
� ����� �� ������ ������� array[mainIndex] (������ �������, ������������ �������� �� � ����������� ������ ��������)
� array[leftIndex] (��� �������, ������� � ��������, ��� ����������� �������� ������ ��� ����� �������)
*/

void swapArrayElements(int array[], int number)
{
	int mainIndex = 0;
	int constant = array[mainIndex];
	int leftIndex = 0;
	for (int i = 1; i < number; i++)
	{
		if (array[i] < constant)
		{
			swap(array[i], array[leftIndex]);
			if (mainIndex == leftIndex)
			{
				mainIndex = i;
			}
			leftIndex++;
		}
	}
	swap(array[leftIndex], array[mainIndex]);
}

/* ������� ��������� ������ ���������� ����������. � �����, ��� ������ ������� swapArrayElements ��������� ��������.
*/

int main()
{
	int const index = 100;
	setlocale(0, "");
	int array[index] = { 0 };
	srand(time(nullptr));
	int number = 0;
	cout << "������ ��������� ����������� ������ ���, ��� � ������ � ������ ������� ����� ��������, ������� �������, � � ����� - ������� �������. \n";
	cout << "������� ���������� ��������� � �������: ";
	cin >> number;
	for (int i = 0; i < number; i++)
	{
		array[i] = rand() % 30 - 10;
	}
	for (int i = 0; i < number; i++)
	{
		cout << array[i] << " ";
	}
	cout << "\n";
	swapArrayElements(array, number);
	cout << "�����: ";
	for (int i = 0; i < number; i++)
	{
		cout << array[i] << " ";
	}
	cout << "\n";
	return 0;
}

/* ��� ����� 8, ��������� ������: 18 11 -2 -7 0 0 -4 -5, � ����� � ����� ������: 11 -2 -7 0 0 -4 -5 18
��� ����� 6, ��������� ������: -3 2 -5 4 -2 18, � ����� � ����� ������: -5 -3 2 4 -2 18
��� ����� 0 ��������� ������ �� �������
*/
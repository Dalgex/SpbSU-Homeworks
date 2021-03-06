#include <iostream>
#include <ctime>

using namespace std;

/* ���������� ��������� - ��������� ���������: � (n log n)
�������� ���� ��������� � ���, ����� ������������� ����� ���������� ������� ����������
����� ������������� ���������� � �� ���� �������������� ������� ������ ��� ����������
������ �� ������������. �������������� ������ ����� ������������� ���������� ����� �����
� ������ ����������� ��������, ���������� �������� ����������, ����������� �������� �������
����� �������� 1,247. ������� ���������� ����� ���������� ����� ������� �������,
����������� �� ������ ���������� (��������� ����������� �� ���������� ������).
�����, ������ ������ � ���� �����, ���������� �������� ��� �� ������ ���������� � ������ �� ������ �����.
��� ������������ �� ��� ���, ���� �������� �������� �� ��������� �������.
� ���� ������ ������ ����������������� ������� ���������
*/

void combSort(int array[], int number)
{
	int jump = number;
	while (jump > 1)
	{
		if (jump > 1)
		{
			jump /= 1.247;
		}
		for (int i = 0; i + jump < number; i++)
		{
			if (array[i + jump] < array[i])
			{
				swap(array[i], array[i + jump]);
			}
		}
	}
}

/* ���� �������� ����� ������������� ������� � �������.
��� ���� � ��� ��� ������ ������������ � ������� �����������,
�.�. ��� ������� ���������� � ������� ������� ����� ������� combSort
count - ����������, � ������� ������� �� ����� ����������� ���������� ���������� ��������� � �������
maximum - ����������, � ������� ������� �� ����� ���������� ������������ ���������� ���������� ���������
������ ���� ������ ����, � ���� �������� �� ������� ����� ������� ���������� ���������� ���������.
�� ����� ������, ��� � ��� ����� ����������� ��������� �������� ���������� ����� ���.
��������: 1 1 1 2 2 3 3 3 4 (��� ������� � ��� ������), � ��� ����� ������� ���� �������� ����� ������������� �������.
������� ����� ������ ����
k - ����������, � ������� ������� �� ����� ��������, ����� ���-�� ��������� ��������� ����������� ���������� ����� ���
mexElement - ����������, ������� ����� �������� ��������� ������ ������� �������������� �������� � �������
� ���� ������� ����� �� ������������ k. ���� k ����� �������, �.�. ������ ���� ������� ����������� ������ ���� ���������,
�� ������� ���� �������, ����� �����, ��� ��� ��������, �������������� ������ ������
*/

void mostFrequentElement(int number, int array[])
{
	int count = 1;
	int maximum = 1;
	for (int i = 0; i < number - 1; i++)
	{
		if (array[i] == array[i + 1])
		{
			count++;
			if (count > maximum)
			{
				maximum = count;
			}
		}
		else
		{
			count = 1;
		}
	}
	count = 1;
	int k = 0;
	int maxElement = 0;
	for (int i = 0; i < number - 1; i++)
	{
		if (array[i] == array[i + 1])
		{
			count++;
			if (count == maximum)
			{
				k++;
				maxElement = array[i];
			}
		}
		else
		{
			count = 1;
		}
	}
	if (k == 1)
	{
		cout << "�������� ����� ������������� ������� � �������: " << maxElement;
	}
	else
	{
		cout << "��� �������� ����� �������������� �������� � �������";
	}
}

/* ��������� ���������� ��������� � �������. ����� ��������� �������� ������� ���������� ������� � ������� ������
�������� ����� ������ �� 0 �� 10 ��� ����, ����� ����� ���� ��������� ������������ ���������� ���������
����� �������� ��� ����������������� �������
*/

int main()
{
	setlocale(0, "");
	srand(time(nullptr));
	int const index = 100;
	int array[index] = { 0 };
	int number = 0;
	cout << "������� ���������� �������� � �������: ";
	cin >> number;
	for (int i = 0; i < number; i++)
	{
		array[i] = rand() % 10;
	}
	cout << "������ ��������� �����: ";
	for (int i = 0; i < number; i++)
	{
		cout << array[i] << " ";
	}
	cout << endl;
	combSort(array, number);
	mostFrequentElement(number, array);
	cout << endl;
	return 0;
}

/* ��� ����� 6, ��������� ������: 7 2 9 2 4 1, �������� ����� ������������� �������: 2
��� ����� 7, �������� ������: 2 1 2 4 3 4 0, "��� �������� ����� �������������� �������� � �������"
*/
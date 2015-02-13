#include <iostream>
#include <ctime>

using namespace std;

/* ���������� ���������
*/

void insertionSort(int array[], int first, int last)
{
	for (int i = 1; i < last + 1; i++)
	{
		for (int j = i; array[j] < array[j - 1] && j > 0; j--)
		{
			swap(array[j], array[j - 1]);
		}
	}
}

void quickSort(int array[], int first, int last)
{
	if (last - first + 1 < 10)
	{
		insertionSort(array, first, last);
	}

	else
	{
		int i = first;
		int j = last;
		int centre = (first + last) / 2;
		int strongPoint = array[centre];

		while (i < j)
		{
			while (array[i] < strongPoint)
			{
				i++;
			}

			while (array[j] > strongPoint)
			{
				j--;
			}

			if (i <= j)
			{
				swap(array[i], array[j]);
				i++;
				j--;
			}
		}

		if (i < last)
		{
			quickSort(array, i, last);
		}

		if (first < j)
		{
			quickSort(array, first, j);
		}
	}
}

/* �������� �����
*/

bool binarySearch(int array[], int first, int last, int k)
{
	if (k == array[first] || k == array[last])
	{
		return true;
	}

	while (last > first + 1)
	{
		if (k > array[(first + last) / 2])
		{
			first = (first + last) / 2;
			binarySearch(array, first, last, k);
		}

		if (k < array[(first + last) / 2])
		{
			last = (first + last) / 2;
			binarySearch(array, first, last, k);
		}

		if (k == array[(first + last) / 2])
		{
			return true;
		}
	}

	return false;
}

int main()
{
	setlocale(0, "");
	srand(time(nullptr));
	int const index = 5000;
	int array[index] = { 0 };
	int n = 0;
	cout << "������� n (���-�� ��������� � �������): ";
	cin >> n;

	if (n > 5000)
	{
		cout << "n �� ������ ������������ 5000 \n";
		return 0;
	}

	for (int i = 0; i < n; i++)
	{
		array[i] = rand() % 40;
	}

	quickSort(array, 0, n - 1);

	for (int i = 0; i < n; i++)
	{
		cout << array[i] << " ";
	}
	cout << endl << "������� k (���������� �����): ";
	int k = 0;
	cin >> k;

	if (k > 300000)
	{
		cout << "k �� ������ ������������ 300000 \n";
		return 0;
	}

	for (int i = 0; i < k; i++)
	{
		int number = rand() % 20;

		if (binarySearch(array, 0, n - 1, number))
		{
			cout << number << " ����� � ������� \n";
		}

		else
		{
			cout << number << " �� ����� � ������� \n";
		}
	}

	return 0;
}

/* ��� ����� n = 10, ��������� ������: 0 0 0 0 0 0 0 0 0 0,
����� ���� k = 10, ��������� ������:
5 �� �����
14 �� �����
13 �� �����
5 �� �����
0 �����
3 �� �����
15 �� �����
13 �� �����
7 �� �����
9 �� �����
*/
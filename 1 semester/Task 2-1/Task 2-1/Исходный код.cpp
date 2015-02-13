#include <iostream>
#include <cstdlib>
#include <time.h>

using namespace std;

/* ���������� ����� ��������� ����������. ������� ��������� �������� int.
�� ���� ������� �������� ����� ����� � ��� ������� ��������, ��������������� ����� ������ ������������������.
*/

int recursiveFibonacci(int number)
{
	if (number < 1)
	{
		return 0;
	}
	if (number == 1)
	{
		return 1;
	}
	return recursiveFibonacci(number - 2) + recursiveFibonacci(number - 1);
}

/* ����������� ������� ����� ���������. ������� ��������� �������� int.
numOneFib - ������ ����� ���������. numTwoFib - ������ ����� ���������. result - �� �����
����� ������� ����������� ����� numOneFib ��������� 0, numTwoFib - 1.
�����, numTwoFib ����� ������������ �� ����� ���� ���������� �����. ��� � ������� ���� �������.
*/

int iterativeFibonacci(int number)
{
	int numTwoFib = 0;
	int numOneFib = 1;
	int result = 0;
	for (int i = 1; i < number + 1; i++)
	{
		result = numOneFib + numTwoFib;
		numOneFib = numTwoFib;
		numTwoFib = result;
	}
	return numTwoFib;
}

/* ������� ������� ������� ��� ��������� ������������ � ������������ ����������.
���� �� ������ ������������� �����, ��������� ������� �� ����.
������ ����������� ����������, ��������� ��� � ������� �� ����� ������.
�������, ��� ��� n>36 ����������� ������� �������� ������� ���������.
*/

int main()
{
	int number = 0;
	setlocale(0, "");
	cout << "������� ����� ����� ������������������ ���������: ";
	cin >> number;
	if (number < 0)
	{
		cout << "������������ ����, �.�. ������� ������ ������������������ ������ ���� ���������������� \n";
	}
	if (number >= 0)
	{
		int result = 0;
		clock_t startIterative = clock();
		result = iterativeFibonacci(number);
		clock_t endIterative = clock();
		cout << "����������� �������� ����: " << iterativeFibonacci(number) << "\n";
		cout << "����� ������ ������������ ��������� ����������: " << static_cast<double>(endIterative - startIterative) / static_cast<double>(CLOCKS_PER_SEC) << "\n";
		clock_t startRecursive = clock();
		result = recursiveFibonacci(number);
		clock_t endRecursive = clock();
		cout << "����������� �������� ����: " << result << "\n";
		cout << "����� ������ ������������ ��������� ����������: " << static_cast<double>(endRecursive - startRecursive) / static_cast<double>(CLOCKS_PER_SEC) << "\n";
	}
	return 0;
}

/* ��� ����� ����� 7 ��� ��������� ������� 13. ����� ������ �� �����.
��� ����� 37 ��������� ������� 24157817. ����� ����������� ������� ���������� 0, ����������� - 2.445
*/
#include <iostream>

using namespace std;

//����� ��������� �����

void printOut(int it, bool array[])
{
	for (; it < 33; it++)
	{
		cout << array[it] << " ";
	}

	cout << endl;
}

/*
������� ������ ����������� ����� � �������� ������� ���������
��� ������������� ����� ������������ ��� ���������� �������������� ���
�������, �� ������� ������������ �������������� ��� ����� ��� ������������� ������������� �����,
������� � ���, ��� ��� ����� ��������� �������������� ��������. ���� ����� ���������� �����,
���� ������������� ������������� � �������������� ���
*/

void intToBinary(int number, bool array[])
{
	int it = 32; //�������� ��� ������ �������� �����
	unsigned int uNumber = number; //��� unsigned int ����� ������� ������ ��������������� ����� ����� � ��������� �� 0 �� 2^32 - 1

	while (uNumber != 0)
	{
		array[it] = uNumber % 2;
		uNumber /= 2;
		it--;
	}

	printOut(++it, array);
}

// ����� ������� � ������� �������� �����

void sumBinary(bool firstArray[], bool secondArray[], bool thirdArray[])
{
	int it = 32;
	for (int i = 32; i > 0; i--)
	{
		int count = (firstArray[i] ? 1 : 0) + (secondArray[i] ? 1 : 0) + (thirdArray[i] ? 1 : 0);

		thirdArray[i - 1] = count / 2;  //������������� ��������. �� ������, ���������� �� � ���������� �������� �������� �����, ������� �������
		thirdArray[i] = count % 2;

		if (thirdArray[i]) //��������� ���, ����� ������� ���� �������� ����� ���������
		{
			it = i;
		}

	}

	printOut(it, thirdArray);
}

//�������������� �������� ����� � ����������

int binToInt(bool binaryNumber[])
{
	unsigned int uNumber = 0;

	for (int i = 0; i < 33; i++)
	{
		uNumber = uNumber * 2 + (binaryNumber[i] ? 1 : 0);
	}

	return uNumber;
}

int main()
{
	setlocale(0, "");
	cout << "������� ������ �����: ";
	int firstNumber = 0;
	cin >> firstNumber;

	cout << "������� ������ �����: ";
	int secondNumber = 0;
	cin >> secondNumber;

	bool firstBinary[33] = {};

	cout << "������ ����� � �������� ������: ";
	intToBinary(firstNumber, firstBinary);

	bool secondBinary[33] = {};

	cout << "������ ����� � �������� ������: ";
	intToBinary(secondNumber, secondBinary);

	bool thirdBinary[33] = {};

	cout << "����� ������ ���� ����� � �������� �������������: ";
	sumBinary(firstBinary, secondBinary, thirdBinary);

	int thirdNumber = binToInt(thirdBinary);
	cout << "��������� � ���������� ����: " << thirdNumber << endl;;

	return 0;
}

/*
��� ����� ������� ����� 373 � ������� -167 ��������� ������:
������ ����� � �������� ������: 1 0 1 1 1 0 1 0 1
������ ����� � �������� ������: 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 0 1 0 1 1 0 0 1
����� ������ ���� ����� � �������� �������������: 1 1 0 0 1 1 1 0
��������� � ���������� ����: 206
*/
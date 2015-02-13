#include <iostream>
#include <string>
#include <fstream>

using namespace std;

/*
������� ��������� ����������: 101 � ������� power � ������ ������� �� ������ 113779, ��� power = ����� ��������� - 1,
113779 - ������� �����. ����� �������� factor � module ����� ����� ��� ��������� ������������� ����,
��� factor - ��������� ������� ���������, ������ �������� ����� 101
*/
int exponentiation(int power)
{
	const int module = 113779;
	const int factor = 101;
	int result = 1;

	for (int i = 0; i < power; i++)
	{
		result = result * factor % module;
	}

	return result;
}

/*
���-�������
����� ����������� ������� ������ � int, ���������� ������������ �������������� �������� � ������ �������.
�� ���� ������ ��� ������� �������� �� ������� ����� � ������� m, ��� m = ����� ������ - 1, ����� ���� ���� �������,
���������� � �������� �� ���������� ������� ����������� �� ������� �����, ��������� � m-1, � ��� �� ����������.
��� ����������� ���-�������� � ���������
*/
int hashFunction(string str)
{
	const int module = 113779;
	const int factor = 101;
	int result = 0;

	for (unsigned int i = 0; i < str.length(); i++)
	{
		result = (result * factor + str[i]) % module;
	}

	return result;
}

/*
��������� ���
��������� ��� � ���-�������, �������������� ������������������ � ������ ���������� ���� (����������) �� ���.
����� ���� ����� ���-������� ������� ��������, ��� ��� ������� ���� ������ ���������� ���-�������,
�������� ��������� �������� �� ���� � �������� ��������� �������� � ����.
������������ �������� �������� ����� ������� �����: �� ������� ����� �� 1 �� i = S,
����� ��������� ����� ����� �� 2 �� i+1, ��� ���������� ������� �� ������ ����� �������� � 1 � ��������� �������� � S+1.
���������� �������� ��������� � � ��������� ���� �� ���������� � �������������� � �������� �������� �����.

��� ���������� ����� ����� �� �������� ������� �� ������� ������� ������� �� ������� ����� � ������� m,
�������� ����� ����� �� ������� ����� � ���� �������, ���������� ������, ���������� �� ������ ����� � 0 �������.
�������� ����� ���
*/
int rollingHash(string str, int recentHash, int calculation)
{
	const int module = 113779;
	const int factor = 101;
	int result = recentHash;
	result = (result - str[0] * calculation) * factor % module + str[str.length() - 1] % module;

	if (result < 0)
	{
		result += module;
	}

	return result;
}

void rabinKarp(string str, string substring)
{
	int resultOfExponentiation = exponentiation(substring.length() - 1); // ��������� ���������� � �������
	int hashResult = hashFunction(substring);  // ������� ���-�������� ���������
	bool isFoundSubstr = true;  // ���� ��������� �������
	int hashValue = hashFunction(str.substr(0, substring.length()));  // ������� ���-�������� ������ n �������� ������, ��� n = ����� �������� ���������

	for (int i = 1; i < (int)(str.length() - substring.length() + 2); i++) // ���������� (int) ��� ����, ����� ���� ����� ������ ��������� ������ ����� ���������, �� ������ �� �����
	{
		if (hashValue == hashResult)  // ���� ���-�������� �������� ��������� ����� ���-�������� ��������� ������
		{
			for (unsigned int j = 0; j < substring.length(); j++)  // ����������� ��������� ���������� ����� ��������
			{
				if (substring[j] != str[j + i - 1])  // ���� ��������������� ������� �� �����...
				{
					isFoundSubstr = false;
					break;
				}
			}

			if (isFoundSubstr)  // ���� ��������� �������
			{
				cout << "Position: " << i << endl;  // ������� ������� ������� ��������� ��������� � ������ 
				return;
			}
			else  // ���� �� ������� ���������, ���������� �����
			{
				isFoundSubstr = true;
			}
		}

		hashValue = rollingHash(str.substr(i - 1, substring.length() + 1), hashValue, resultOfExponentiation);  // ������� ���-�������� ���������, ��������� �� 1 ������ ������
	}

	cout << "Substring was not found\n";
}
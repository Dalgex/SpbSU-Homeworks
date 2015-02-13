#include <iostream>

using namespace std;

/*������� ��������� ���������� � ������� � ��� : ��������� ������� ���������� ���� �� ���� n ���, ��� n - ���������� �������,
������� �� ���������, ����� ��� � ���������. ���� ���������� ������� ������ ����, �� ������ ������� ������������ ���,
��� ������������� �����.
*/

int function(int base, int exponent)
{
	int result = 1;
	for (int i = 0; i < abs(exponent); i++)
	{
		result *= base;
	}
	return result;
}

/* ����������� ���������� � �������.
������� �������� ���� ���� ��, ������ ��� � ����������� �������, �������� �� ��� ������
*/

int exponentiation(int base, int exponent)
{
	if (exponent == 0)
	{
		return 1;
	}
	int count = exponentiation(base, abs(exponent) / 2);
	if (exponent % 2 == 0)
	{
		return count * count;
	}
	else
	{
		return count * count * base;
	}
}

/* ��������� ��������� � ���������� �������. ������� �������� ����� ����� � ����� ������� ���������� � � ���.
���� ���������� ������� ������ ����, �� ������ ������� ������� ������������ �����
*/

int main()
{
	setlocale(0, "");
	cout << "������� ��������� �������: ";
	int base = 0;
	cin >> base;
	cout << "������� ���������� �������: ";
	int exponent = 0;
	cin >> exponent;
	exponentiation(base, exponent);
	if (exponent < 1 && base == 0)
	{
		cout << "������������ ���� \n";
		return 1;
	}
	else
	{
		if (exponent >= 0)
		{
			cout << "������� ��������: " << exponentiation(base, exponent) << "\n";
		}
		else
		{
			cout << "������� ��������: " << "1/" << exponentiation(base, exponent) << "\n";
		}
	}
	function(base, exponent);
	if (exponent >= 0)
	{
		cout << "��������� ��������: " << function(base, exponent) << "\n";
	}
	else
	{
		cout << "��������� ��������: " << "1/" << function(base, exponent) << "\n";
	}
	return 0;
}

/* ��� ����� ��������� -5, � ���������� 5, ��������� �������: ������� ��������: -3125
��������� ��������: -3125
��� ����� ��������� � ���������� 0, ��������� �������: ������������ ����
��� ����� ��������� 6, � ���������� -3, ���������� �������: ������� ��������: 1/216
��������� ��������: 1/216
*/
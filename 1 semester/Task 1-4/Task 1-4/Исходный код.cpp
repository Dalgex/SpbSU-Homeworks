#include <iostream>

using namespace std;

int module(int number)
{
	if (number < 0)
	{
		number = -number;
	}

	return number;
}

int main()
{
	setlocale(0, "");
	cout << "��������� ��� ���������� ��������� �������� ���� �����. \n";
	int dividend = 0;
	cout << "�������: ";
	cin >> dividend;
	int divisor = 0;
	cout << "��������: ";
	cin >> divisor;
	
	if (divisor == 0)
	{
		cout << "�������� �� ����� ���� ����� 0 \n";
		return 1;
	}

	bool character = (dividend * divisor < 0);
	dividend = module(dividend);
	divisor = module(divisor);
	int result = 0;
	
	while (dividend >= divisor)
	{
		dividend = dividend - divisor;
		result++;
	}
	
	if (character)
	{
		result = -result;
	}

	cout << "�������� �������: " << result << "\n";
	return 0;
}
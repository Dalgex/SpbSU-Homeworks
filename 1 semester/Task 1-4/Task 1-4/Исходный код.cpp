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
	cout << "Программа для нахождения неполного частного двух чисел. \n";
	int dividend = 0;
	cout << "Делимое: ";
	cin >> dividend;
	int divisor = 0;
	cout << "Делитель: ";
	cin >> divisor;
	
	if (divisor == 0)
	{
		cout << "Делитель не может быть равен 0 \n";
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

	cout << "Неполное частное: " << result << "\n";
	return 0;
}
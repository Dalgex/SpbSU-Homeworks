#include <iostream>

using namespace std;

int main()
{
	setlocale(0, "");
	cout << "Программа расчета значения формулы: x^4+x^3+x^2+x+1 \nВведите x: ";
	int number = 0;
	cin >> number;
	int square = number * number;
	int result = square * (square + number) + square + number + 1;
	cout << "Результат: " << result << "\n";
	return 0;
}
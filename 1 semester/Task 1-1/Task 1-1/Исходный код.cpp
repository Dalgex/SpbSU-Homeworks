#include <iostream>

using namespace std;

int main()
{
	setlocale(0, "");
	cout << "��������� ������� �������� �������: x^4+x^3+x^2+x+1 \n������� x: ";
	int number = 0;
	cin >> number;
	int square = number * number;
	int result = square * (square + number) + square + number + 1;
	cout << "���������: " << result << "\n";
	return 0;
}
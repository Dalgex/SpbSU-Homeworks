#include <iostream>

using namespace std;

int main()
{
	setlocale(0, "");
	cout << "��������� ������ ��� ������� �����, �� ������������� ��������� \n";
	int number = 0;
	cout << "������� ����������� �����: ";
	cin >> number;
	int constant = 2;
	bool prime = true;
	for (int i = constant; i <= number; i++)
	{
		prime = true;
		for (int j = constant; j < sqrt(i + 1); j++)
		{
			if (i % j == 0)
			{
				prime = false;
			}
		}
		if (prime)
		{
			cout << i << " ";
		}
	}
	cout << "\n";
	return 0;
}

#include <iostream>

using namespace std;

int main()
{
	setlocale(0, "");
	int const index = 10;
	int array[index] = { 0 };
	cout << "������� �������� �������: ";
	for (int i = 0; i < index; i++)
	{
		cin >> array[i];
	}
	int number = 0;
	for (int i = 0; i < index; i++)
	{
		if (array[i] == 0)
		{
			number++;
		}
	}
	cout << "���������� ������� ��������� �����: " << number << "\n";
	return 0;
}
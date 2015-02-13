#include <iostream>

using namespace std;

int main()
{
	setlocale(0, "");
	int const number = 28;
	int const maximum = 10;
	int sumTicket[number] = { 0 };
	for (int i = 0; i < maximum; i++)
	for (int j = 0; j < maximum; j++)
	for (int k = 0; k < maximum; k++)
	{
		sumTicket[i + j + k]++;
	}
	int totalSumTicket = 0;
	for (int index = 0; index < number; index++)
	{
		sumTicket[index] *= sumTicket[index];
		totalSumTicket += sumTicket[index];
	}
	cout << "Количество счастливых билетов: " << totalSumTicket << "\n";
	return 0;
}
#include <iostream>

using namespace std;

int main()
{
	setlocale(0, "");
	int const indexOne = 10;
	int const indexTwo = 5;
	char arrayOne[indexOne] = { 0 };
	char arrayTwo[indexTwo] = { 0 };
	cout << "Программа печает количество вхождений подстроки в главную строку. \nВведите главную строку: ";
	cin >> arrayOne;
	cout << "Введите подстроку для поиска: ";
	cin >> arrayTwo;
	int number = 0;
	int indexOneLength = strlen(arrayOne);
	int indexTwoLength = strlen(arrayTwo);
	for (int i = 0; i < indexOneLength - indexTwoLength + 1; i++)
	{
		bool answer = true;
		for (int j = 0; j < indexTwoLength; j++)
		{
			if (arrayTwo[j] != arrayOne[i + j])
			{
				answer = false;
				break;
			}
		}
		if (answer)
		{
			number++;
		}
	}
	cout << "Количество вхождений: " << number << "\n";
	return 0;
}
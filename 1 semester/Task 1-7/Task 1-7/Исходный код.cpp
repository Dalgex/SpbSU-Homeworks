#include <iostream>

using namespace std;

int main()
{
	setlocale(0, "");
	char string[100] = { 0 };
	cout << "Введите строку. Длина строки не должна превышать 100 символов. \n";
	cin >> string;
	int openBracket = 0;
	int closeBracket = 0;
	int i = 0;
	bool answer = true;
	while (string[i] != 0)
	{
		if (closeBracket > openBracket)
		{
			answer = false;
		}
		if (string[i] == '(')
		{
			openBracket++;
		}
		else if (string[i] == ')')
		{
			closeBracket++;
		}
		i++;
	}
	if ((closeBracket == openBracket) && answer)
	{
		cout << "Число открывающих скобок равно числу закрывающих \n";
	}
	else
	{
		cout << "Число открывающих скобок не равно числу закрывающих \n";
	}
	return 0;
}
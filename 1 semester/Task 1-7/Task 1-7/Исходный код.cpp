#include <iostream>

using namespace std;

int main()
{
	setlocale(0, "");
	char string[100] = { 0 };
	cout << "������� ������. ����� ������ �� ������ ��������� 100 ��������. \n";
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
		cout << "����� ����������� ������ ����� ����� ����������� \n";
	}
	else
	{
		cout << "����� ����������� ������ �� ����� ����� ����������� \n";
	}
	return 0;
}
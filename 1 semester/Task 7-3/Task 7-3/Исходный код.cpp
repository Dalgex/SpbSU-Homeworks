#include <iostream>
#include <string>
#include "stack.h"
#include "correctBrackets.h"

using namespace std;

int main()
{
	setlocale(0, "");
	string str;
	cout << "Введите строку: ";
	cin >> str;

	if (isStringCorrect(str))
	{
		cout << "Баланс скобок не нарушен\n";
	}
	else
	{
		cout << "Баланас скобок нарушен\n";
	}

	return 0;
}

/*
При вводе: a{bc[d[e(fgh)ijkl]mn]o}mm программа вывела: баланс скобок не нарушен
При вводе: cder{ku}tg(l{ju)l}, прорамма вывела: баланс скобок нарушен
*/
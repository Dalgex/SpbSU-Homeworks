#include <iostream>
#include <string>
#include "stack.h"
#include "correctBrackets.h"

using namespace std;

int main()
{
	setlocale(0, "");
	string str;
	cout << "������� ������: ";
	cin >> str;

	if (isStringCorrect(str))
	{
		cout << "������ ������ �� �������\n";
	}
	else
	{
		cout << "������� ������ �������\n";
	}

	return 0;
}

/*
��� �����: a{bc[d[e(fgh)ijkl]mn]o}mm ��������� ������: ������ ������ �� �������
��� �����: cder{ku}tg(l{ju)l}, �������� ������: ������ ������ �������
*/
#include <iostream>
#include "stack.h"
#include "postfix.h"
#include <string>

using namespace std;

int main()
{
	setlocale(0, "");
	Stack *stack = createStack();
	string infix;
	cout << "������� ���������: ";
	getline(cin, infix);

	int sizeOfArray = 50;
	char *postfix = new char[sizeOfArray];
	postfixNotation(infix, postfix, stack);
	cout << endl;
	delete[] postfix;
	deleteStack(stack);
	return 0;
}

/*
��� �����: (1 + 1) * 2, ��������� ������: 1 1 + 2 *
��� �����: 5-7 *(3+  4/(1 +2)- 1 ), ��������� ������: 5 7 3 4 1 2 + / + 1 - * -
��� �����: 4*(5+3/2) + )5-1( , ��������� ������: ������������ ����
��� �����: 9 - 4+(2* - 3), ��������� ������: ������������ ����
��� �����: 6 + 8(3-1) , ��������� ������: ������������ ����

P.S. ������� ����� ����������� ���� ���
*/
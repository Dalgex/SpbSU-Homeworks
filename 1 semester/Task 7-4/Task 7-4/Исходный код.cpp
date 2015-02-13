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
	cout << "Введите выражение: ";
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
При вводе: (1 + 1) * 2, программа вывела: 1 1 + 2 *
При вводе: 5-7 *(3+  4/(1 +2)- 1 ), программа вывела: 5 7 3 4 1 2 + / + 1 - * -
При вводе: 4*(5+3/2) + )5-1( , программа вывела: некорректный ввод
При вводе: 9 - 4+(2* - 3), программа вывела: некорректный ввод
При вводе: 6 + 8(3-1) , программа вывела: некорректный ввод

P.S. пробелы можно расставлять хоть как
*/
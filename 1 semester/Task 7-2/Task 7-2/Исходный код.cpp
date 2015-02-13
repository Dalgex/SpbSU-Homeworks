#include <iostream>
#include "stack.h"
#include "postfix.h"

using namespace std;

int main()
{
	setlocale(0, "");
	Stack *stack = createStack();
	int sizeOfArray = 40;
	char *expression = new char[sizeOfArray];
	cout << "¬ведите выражение: ";
	int i = 0;
	fgets(expression, sizeOfArray, stdin);

	while (expression[i] != '\n')
	{
		addNumericalDigit(expression[i], stack);
		i++;
	} 

	cout << pop(stack) << endl;
	delete[] expression;
	deleteStack(stack);
	return 0;
}
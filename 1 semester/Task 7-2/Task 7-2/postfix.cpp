#include <iostream>
#include "stack.h"
#include "postfix.h"

void calculateValues(char operation, Stack* stack)
{
	StackElement* firstElementStack = firstElement(stack);
	StackElement* secondElementStack = secondElement(stack);

	if ((firstElementStack == nullptr) || (secondElementStack == nullptr))
	{
		return;
	}

	int value2 = pop(stack);
	int value1 = pop(stack);

	switch (operation)
	{
		case '+':
		{
			push(stack, value1 + value2);
			break;
		}

		case '-':
		{
			push(stack, value1 - value2);
			break;
		}

		case '*':
		{
			push(stack, value1 * value2);
			break;
		}

		case '/':
		{
			push(stack, value1 / value2);
			break;
		}

		default:
		{
			break;
		}
	}
}

void addNumericalDigit(char digit, Stack* stack)
{

	if ((digit >= '0') && (digit <= '9'))
	{
		push(stack, digit - '0');
	}
	else
	{
		if (digit == ' ')
		{
			return;
		}
		else
		{
			calculateValues(digit, stack);
		}
	}
}
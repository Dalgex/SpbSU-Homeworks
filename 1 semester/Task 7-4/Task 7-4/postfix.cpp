#include <iostream>
#include "stack.h"
#include "postfix.h"
#include <string>

using namespace std;

bool isDigit(char digit)
{
	if ((digit >= '0') && (digit <= '9'))
	{
		return true;
	}

	return false;
}

bool isOperation(char operation)
{
	return (operation == '+') || (operation == '-') || (operation == '*') || (operation == '/');
}

bool isPlus(char operation)
{
	return (operation == '+') || (operation == '-');
}

bool isOpenBracket(char token)
{
	return token == '(';
}

bool isCloseBracket(char token)
{
	return token == ')';
}

bool isBracket(char token)
{
	return (token == '(') || (token == ')');
}

bool isOpenBracketStack(Stack* stack)
{
	if (isEmpty(stack))
	{
		return false;
	} 

	return value(stack) == '(';
}

bool isSpace(char token)
{
	return token == ' ';
}

char space()
{
	return ' ';
}

int checkPriority(char token)
{
	switch (token)
	{
		case '*':
		case '/':
		{
			return 2;
		}

		case '+':
		case '-':
		{
			return 1;
		}
	}

	return 0;
}

bool isStringCorrect(Stack* stack, string expression)
{
	for (int unsigned i = 0; i < expression.length(); i++)  // удаляем пробелы из строки, чтобы было удобнее следить за корректностью введенного выражения
	{
		if (expression[i] == ' ')
		{
			expression.erase(i, 1);
			i--;
		}
	}

	//if (!isDigit(expression[0]) && !isOpenBracket(expression[0])) 
	{
		//return false;
	}

	if (!isDigit(expression.back()) && !isCloseBracket(expression.back()))
	{
		return false;
	}

	if (isOpenBracket(expression[0]))
	{
		push(stack, expression[0]);
	}

	for (int unsigned i = 1; i < expression.length(); i++)
	{
		if (isOpenBracket(expression[i]))
		{
			push(stack, expression[i]);
		}

		if (isCloseBracket(expression[i]))
		{
			if (!isEmpty(stack))
			{
				pop(stack);
			}
			else
			{
				return false;
			}
		}

//		if (isOpenBracket(expression[i - 1]) && isOperation(expression[i]))  // открывающая скобка, затем оператор
		{
//			if (!(isOperation(expression[i]) && isOpenBracket(expression[i + 1])))
			{
//				return false;
			}
		}

		if (isDigit(expression[i - 1]) && isOpenBracket(expression[i]))  // цифра, затем открывающая скобка
		{
			return false;
		}

		if (isOpenBracket(expression[i - 1]) && isCloseBracket(expression[i]))
		{
			return false;
		}

		if (isOperation(expression[i - 1]) && isCloseBracket(expression[i]))  // оператор, затем закрывающая скобка
		{
			return false;
		}

		if (isCloseBracket(expression[i - 1]) && isDigit(expression[i]))  // закрывающая скобка, затем цифра
		{
			return false;
		}

		if (isDigit(expression[i - 1]) && isDigit(expression[i]))  // две цифры подряд
		{
			if ((expression[i - 1] == '0'))
			{
				if (i > 1)
				{
					if (!isDigit(expression[i - 2]))
					{
						return false;
					}
				}
				else
				{
					return false;
				}
			}
		}

		if (isOperation(expression[i - 1]) && isOperation(expression[i])) // два оператора
		{
			if (!(isPlus(expression[i - 1]) && isPlus(expression[i])))
			{
				return false;
			}
		}

		if (!isBracket(expression[i]) && !isOperation(expression[i]) && !isDigit(expression[i]))  // ни скобка, ни оператор, ни число
		{
			return false;
		}
	}

	return (isEmpty(stack));
} 

void postfixNotation(string infix, char* postfix, Stack* stack)
{
	if (!isStringCorrect(stack, infix))
	{
		cout << "Некорректный ввод";
		return;
	}
	else
	{
		cout << "Корректный ввод";
	}
	/*
	int j = 0;

	for (int unsigned i = 0; i < infix.length(); i++)
	{
		if (isDigit(infix[i]))
		{
			postfix[j++] = infix[i];
			postfix[j++] = space();
		}
		else
		{
			if ((isSpace(infix[i])))
			{
				continue;
			}

			if (isOperation(infix[i]))
			{
				if (isEmpty(stack))
				{
					push(stack, infix[i]);
				}
				else
				{
					while (!isEmpty(stack) && checkPriority(infix[i]) <= checkPriority(value(stack)))
					{
						postfix[j++] = pop(stack);
						postfix[j++] = space();
					}

					push(stack, infix[i]);
				}
			}
			else
			{
				if (isOpenBracket(infix[i]))
				{
					push(stack, infix[i]);
				}
				else
				{
					while (!isOpenBracketStack(stack))
					{
						postfix[j++] = pop(stack);
						postfix[j++] = space();
					}

					pop(stack);
				}
			}
		}
	}

	while (!isEmpty(stack))
	{
		postfix[j++] = pop(stack);
		postfix[j++] = space();
	}

	for (int i = 0; i < j; i++)
	{
		cout << postfix[i];
	} */
}
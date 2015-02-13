#include <iostream>
#include "correctBrackets.h"
#include "stack.h"
#include <string>

using namespace std;

char getBracket(char bracket)
{
	if (bracket == ')')
	{
		return '(';
	}

	if (bracket == ']')
	{
		return '[';
	}

	if (bracket == '}')
	{
		return '{';
	}
}

bool closeBracket(char symbol)
{
	return (symbol == ')') || (symbol == ']') || (symbol == '}');
}

bool isStringCorrect(string const &str)
{
	Stack *stack = createStack();

	for (int i = 0; i < str.size(); i++)
	{
		switch (str[i])
		{
			case '(':
			case'{':
			case'[':
			{
			   push(stack, str[i]);
			   break;
			}

			default:
			{
				if (closeBracket(str[i]))
				{
					char bracket = getBracket(str[i]);
					
					if (isEmpty(stack))
					{
						return false;
					}
					else
					{
						char valueFirstElement = valueElement(stack);

						if (valueFirstElement == bracket)
						{
							pop(stack);
						}
						else
						{
						   return false;
						}
					}
				}

				break;
			}
		}
	}

	bool const result = isEmpty(stack);
	deleteStack(stack);
	return result;
}
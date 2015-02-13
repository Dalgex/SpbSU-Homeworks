#include <iostream>
#include "checkSymbol.h"

using namespace std;

bool isDigit(char digit)
{
	return (digit >= '0') && (digit <= '9');
}

bool isOperation(char operation)
{
	return (operation == '+') || (operation == '-') || (operation == '*') || (operation == '/');
}

bool isAddition(char token)
{
	return token == '+';
}

bool isSubtraction(char token)
{
	return token == '-';
}

bool isMultiplication(char token)
{
	return token == '*';
}

bool isDivision(char token)
{
	return token == '/';
}

bool isOpenBracket(char token)
{
	return token == '(';
}

bool isCloseBracket(char token)
{
	return token == ')';
}

bool isBrackets(char token)
{
	return isOpenBracket(token) || isCloseBracket(token);
}

bool isSpace(char token)
{
	return token == ' ';
}

bool isCorrectString(string expression)
{
	int count = 0;
	int brackets = 0;

	for (unsigned int i = 0; i < expression.length(); i++)
	{
		if (isSpace(expression[i]))
		{
			continue;
		}

		if (isBrackets(expression[i]))
		{
			if (isOpenBracket(expression[i])) 
			{
				brackets++;
			}
			else
			{
				brackets--;
			}

			if (brackets < 0)   // если кол-во скобок стало меньше нул€, это означает, что 
			{					// в опр момент закрывающих скобок больше, чем открывающих 
				return false;
			}

			continue;
		}

		if (!isDigit(expression[i]) && !isOperation(expression[i]))   // если не цифра и не оператор
		{
			return false;
		}

		if (isOperation(expression[i]))
		{
			count--;
		}
		else
		{
			count++;
		}

		if (count > 0)  // этот фрагмент опишу ниже
		{
			for (unsigned int j = i + 1; j < expression.length(); j++)
			{
				if (isDigit(expression[j]) || isOperation(expression[j]))
				{
					return false;
				}
			}
		}
	}

	return count == 1;
}

/* чтобы ввод был корректный, необходимо, чтобы кол-во цифр минус кол-во операторов было небольше 1, причем
разница будет равна единице, когда все дерево заполнитс€, а до этого или кол-во цифр будет равн€тьс€ кол-ву операторов,
или меньше. ≈сли мы на каком-то этапе получаем count>0, это означает, что при корректном вводе все цифры и операторы должны 
быть задействованы. тогда мы делаем новый цикл. если после того, как count стал больше 0, мы найдем в нашем выражении цифру или
оператор - ошибка, такого быть не может. максимум, что может сто€ть, так это скобки и пробелы.
—читаем, что если в нашем выражении присутствует последовательность () - она €вл€етс€ корректной, т.к. ни на что не вли€ет.
ћожно конечно и это учесть, но тогда код проверки станет еще больше
 онечно, со скобками тут будет еще парочку перестановок, которые можно было бы учесть, но если это все принимать во внимание, 
то получитс€ большой код. нам самое главное знать, чтобы кол-во цифр не превышало кол-во операций, а если и превысило, то
только на единицу и на этом заканчивалось бы выражение. ѕодробнее можно все посмотреть на тестах после main'a
*/
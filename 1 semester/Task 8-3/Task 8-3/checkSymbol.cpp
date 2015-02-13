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

			if (brackets < 0)   // ���� ���-�� ������ ����� ������ ����, ��� ��������, ��� 
			{					// � ��� ������ ����������� ������ ������, ��� ����������� 
				return false;
			}

			continue;
		}

		if (!isDigit(expression[i]) && !isOperation(expression[i]))   // ���� �� ����� � �� ��������
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

		if (count > 0)  // ���� �������� ����� ����
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

/* ����� ���� ��� ����������, ����������, ����� ���-�� ���� ����� ���-�� ���������� ���� �������� 1, ������
������� ����� ����� �������, ����� ��� ������ ����������, � �� ����� ��� ���-�� ���� ����� ��������� ���-�� ����������,
��� ������. ���� �� �� �����-�� ����� �������� count>0, ��� ��������, ��� ��� ���������� ����� ��� ����� � ��������� ������ 
���� �������������. ����� �� ������ ����� ����. ���� ����� ����, ��� count ���� ������ 0, �� ������ � ����� ��������� ����� ���
�������� - ������, ������ ���� �� �����. ��������, ��� ����� ������, ��� ��� ������ � �������.
�������, ��� ���� � ����� ��������� ������������ ������������������ () - ��� �������� ����������, �.�. �� �� ��� �� ������.
����� ������� � ��� ������, �� ����� ��� �������� ������ ��� ������
�������, �� �������� ��� ����� ��� ������� ������������, ������� ����� ���� �� ������, �� ���� ��� ��� ��������� �� ��������, 
�� ��������� ������� ���. ��� ����� ������� �����, ����� ���-�� ���� �� ��������� ���-�� ��������, � ���� � ���������, ��
������ �� ������� � �� ���� ������������� �� ���������. ��������� ����� ��� ���������� �� ������ ����� main'a
*/
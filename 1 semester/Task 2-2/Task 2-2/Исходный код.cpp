#include <iostream>

using namespace std;

/*Функция реализует возведение в степень в лоб : основание степени умножается само на себя n раз, где n - показатель степени,
который мы считываем, также как и основание. Если показатель степени меньше нуля, то данная функция воспринимает его,
как положительное число.
*/

int function(int base, int exponent)
{
	int result = 1;
	for (int i = 0; i < abs(exponent); i++)
	{
		result *= base;
	}
	return result;
}

/* Рекурсивное возведение в степень.
Функция вызывает саму себя же, только уже с показателем степени, деленным на два нацело
*/

int exponentiation(int base, int exponent)
{
	if (exponent == 0)
	{
		return 1;
	}
	int count = exponentiation(base, abs(exponent) / 2);
	if (exponent % 2 == 0)
	{
		return count * count;
	}
	else
	{
		return count * count * base;
	}
}

/* Считываем основание и показатель степени. Функция возводит целое число в целую степень рекурсивно и в лоб.
Если показатель степени меньше нуля, то данная функция выводит перевернутую дробь
*/

int main()
{
	setlocale(0, "");
	cout << "Введите основание степени: ";
	int base = 0;
	cin >> base;
	cout << "Введите показатель степени: ";
	int exponent = 0;
	cin >> exponent;
	exponentiation(base, exponent);
	if (exponent < 1 && base == 0)
	{
		cout << "Некорректный ввод \n";
		return 1;
	}
	else
	{
		if (exponent >= 0)
		{
			cout << "Быстрый алгоритм: " << exponentiation(base, exponent) << "\n";
		}
		else
		{
			cout << "Быстрый алгоритм: " << "1/" << exponentiation(base, exponent) << "\n";
		}
	}
	function(base, exponent);
	if (exponent >= 0)
	{
		cout << "Медленный алгоритм: " << function(base, exponent) << "\n";
	}
	else
	{
		cout << "Медленный алгоритм: " << "1/" << function(base, exponent) << "\n";
	}
	return 0;
}

/* При вводе основания -5, а показателя 5, программа выводит: Быстрый алгоритм: -3125
Медленный алгоритм: -3125
При вводе основания и показателя 0, программа выводит: Некорректный ввод
При вводе основания 6, а показателя -3, программма выводит: Быстрый алгоритм: 1/216
Медленный алгоритм: 1/216
*/
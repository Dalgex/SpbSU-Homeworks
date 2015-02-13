#include <iostream>
#include <string>
#include <fstream>

using namespace std;

/*
Находим результат вычисления: 101 в степени power в кольце вычетов по модулю 113779, где power = длина подстроки - 1,
113779 - простое число. Выбор констант factor и module очень важен для получения качественного хэша,
где factor - основание системы счисления, равный простому числу 101
*/
int exponentiation(int power)
{
	const int module = 113779;
	const int factor = 101;
	int result = 1;

	for (int i = 0; i < power; i++)
	{
		result = result * factor % module;
	}

	return result;
}

/*
Хэш-функция
Чтобы достаточный полином влезал в int, необходимо использовать арифметические операции в кольце вычетов.
То есть первый код символа умножаем на простое число в степени m, где m = длина строки - 1, после чего берём остаток,
складываем с остатком от следующего символа умноженного на простое число, возведённоё в m-1, и так до последнего.
Так высчитываем хэш-значение у подстроки
*/
int hashFunction(string str)
{
	const int module = 113779;
	const int factor = 101;
	int result = 0;

	for (unsigned int i = 0; i < str.length(); i++)
	{
		result = (result * factor + str[i]) % module;
	}

	return result;
}

/*
Кольцевой хэш
Кольцевой хэш — хэш-функция, обрабатывающая последовательность в рамках некоторого окна (промежутка) на ней.
Сдвиг окна такой хэш-функции дешёвая операция, так как требует лишь знания предыдущей хэш-функции,
значений элементов выпавших из окна и значений элементов попавших в окно.
Элементарным примером является такой подсчёт суммы: мы считаем сумму от 1 до i = S,
чтобы посчитать новую сумму от 2 до i+1, нам достаточно вычесть из старой суммы значение в 1 и прибавить значение в S+1.
Аналогично возможно поступить и с подсчётом хэша по многочлену с коэффициентами — степенью простого числа.

Для нахождений новой суммы мы вычитаем остаток от бывшего первого символа на простое число в степени m,
умножаем новую сумму на простое число и берём остаток, прибавляем символ, умноженный на просто число в 0 степени.
Получаем новый хэш
*/
int rollingHash(string str, int recentHash, int calculation)
{
	const int module = 113779;
	const int factor = 101;
	int result = recentHash;
	result = (result - str[0] * calculation) * factor % module + str[str.length() - 1] % module;

	if (result < 0)
	{
		result += module;
	}

	return result;
}

void rabinKarp(string str, string substring)
{
	int resultOfExponentiation = exponentiation(substring.length() - 1); // результат возведения в степень
	int hashResult = hashFunction(substring);  // считаем хэш-значение подстроки
	bool isFoundSubstr = true;  // если подстрока найдена
	int hashValue = hashFunction(str.substr(0, substring.length()));  // считаем хэш-значение первых n символов строки, где n = длине исходной подстроки

	for (int i = 1; i < (int)(str.length() - substring.length() + 2); i++) // используем (int) для того, чтобы если длина строки оказалась меньше длины подстроки, то выйдем из цикла
	{
		if (hashValue == hashResult)  // если хэш-значение исходной подстроки равно хэш-значению подстроки строки
		{
			for (unsigned int j = 0; j < substring.length(); j++)  // посимвольно проверяем совпадение самих подстрок
			{
				if (substring[j] != str[j + i - 1])  // если соответствующие символы не равны...
				{
					isFoundSubstr = false;
					break;
				}
			}

			if (isFoundSubstr)  // если подстрока найдена
			{
				cout << "Position: " << i << endl;  // выводим позицию первого вхождения подстроки в строке 
				return;
			}
			else  // если не найдена подстрока, продолжаем поиск
			{
				isFoundSubstr = true;
			}
		}

		hashValue = rollingHash(str.substr(i - 1, substring.length() + 1), hashValue, resultOfExponentiation);  // считаем хэш-значение подстроки, сдвинутой на 1 символ вправо
	}

	cout << "Substring was not found\n";
}
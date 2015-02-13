#include <iostream>
#include <cstdlib>
#include <time.h>

using namespace std;

/* Вычисление чисел Фибоначчи рекурсивно. Функция принимает значение int.
На вход функции подается целое число и она выводит значение, соответствующее этому номеру последовательности.
*/

int recursiveFibonacci(int number)
{
	if (number < 1)
	{
		return 0;
	}
	if (number == 1)
	{
		return 1;
	}
	return recursiveFibonacci(number - 2) + recursiveFibonacci(number - 1);
}

/* Итеративный подсчет чисел Фибоначчи. Функция принимает значения int.
numOneFib - первое число Фибоначчи. numTwoFib - второе число Фибоначчи. result - их сумма
После первого прохождения цикла numOneFib принимает 0, numTwoFib - 1.
Далее, numTwoFib будет складываться из суммы двух предыдущих чисел. Его и выводит наша функция.
*/

int iterativeFibonacci(int number)
{
	int numTwoFib = 0;
	int numOneFib = 1;
	int result = 0;
	for (int i = 1; i < number + 1; i++)
	{
		result = numOneFib + numTwoFib;
		numOneFib = numTwoFib;
		numTwoFib = result;
	}
	return numTwoFib;
}

/* Главная функция выводит нам результат итеративного и рекурсивного алгоритмов.
Если мы вводим отрицательное число, программа говорит об этом.
Помимо результатов алгоритмов, программа еще и выводит их время работы.
Заметим, что при n>36 рекурсивная функция работает заметно медленнее.
*/

int main()
{
	int number = 0;
	setlocale(0, "");
	cout << "Введите номер члена последовательности Фибоначчи: ";
	cin >> number;
	if (number < 0)
	{
		cout << "Некорректный ввод, т.к. индексы членов последовательности должны быть неотрицательными \n";
	}
	if (number >= 0)
	{
		int result = 0;
		clock_t startIterative = clock();
		result = iterativeFibonacci(number);
		clock_t endIterative = clock();
		cout << "Итеративный алгоритм дает: " << iterativeFibonacci(number) << "\n";
		cout << "Время работы итеративного алгоритма составляет: " << static_cast<double>(endIterative - startIterative) / static_cast<double>(CLOCKS_PER_SEC) << "\n";
		clock_t startRecursive = clock();
		result = recursiveFibonacci(number);
		clock_t endRecursive = clock();
		cout << "Рекурсивный алгоритм дает: " << result << "\n";
		cout << "Время работы рекурсивного алгоритма составляет: " << static_cast<double>(endRecursive - startRecursive) / static_cast<double>(CLOCKS_PER_SEC) << "\n";
	}
	return 0;
}

/* При вводе числа 7 оба алгоритма выводят 13. Время работы по нулям.
При вводе 37 алгоритмы выводят 24157817. Время итеративной функции составляет 0, рекурсивной - 2.445
*/
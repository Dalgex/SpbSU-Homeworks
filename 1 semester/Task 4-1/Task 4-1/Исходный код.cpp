#include <iostream>

using namespace std;

//¬ывод двоичного числа

void printOut(int it, bool array[])
{
	for (; it < 33; it++)
	{
		cout << array[it] << " ";
	}

	cout << endl;
}

/*
ѕеревод целого дес€тичного числа в двоичную систему счислени€
ƒл€ отрицательных чисел используетс€ так называемый дополнительный код
ѕричина, по которой используетс€ дополнительный код числа дл€ представлени€ отрицательных чисел,
св€зана с тем, что так проще выполн€ть математические операции.  уда проще складывать числа,
если отрицательные преобразованы в дополнительный код
*/

void intToBinary(int number, bool array[])
{
	int it = 32; //итератор дл€ вывода двоичных чисел
	unsigned int uNumber = number; //тип unsigned int может хранить только неотрицательные целые числа в диапазоне от 0 до 2^32 - 1

	while (uNumber != 0)
	{
		array[it] = uNumber % 2;
		uNumber /= 2;
		it--;
	}

	printOut(++it, array);
}

// —умма первого и второго двоичных чисел

void sumBinary(bool firstArray[], bool secondArray[], bool thirdArray[])
{
	int it = 32;
	for (int i = 32; i > 0; i--)
	{
		int count = (firstArray[i] ? 1 : 0) + (secondArray[i] ? 1 : 0) + (thirdArray[i] ? 1 : 0);

		thirdArray[i - 1] = count / 2;  //промежуточное значение. ћы узнаем, по€вл€етс€ ли в результате прошлого сложени€ число, большее единицы
		thirdArray[i] = count % 2;

		if (thirdArray[i]) //провер€ем это, чтобы вывести наше двоичное число корректно
		{
			it = i;
		}

	}

	printOut(it, thirdArray);
}

//ѕреобразование двоичных чисел в дес€тичные

int binToInt(bool binaryNumber[])
{
	unsigned int uNumber = 0;

	for (int i = 0; i < 33; i++)
	{
		uNumber = uNumber * 2 + (binaryNumber[i] ? 1 : 0);
	}

	return uNumber;
}

int main()
{
	setlocale(0, "");
	cout << "¬ведите первое число: ";
	int firstNumber = 0;
	cin >> firstNumber;

	cout << "¬ведите второе число: ";
	int secondNumber = 0;
	cin >> secondNumber;

	bool firstBinary[33] = {};

	cout << "ѕервое число в двоичной записи: ";
	intToBinary(firstNumber, firstBinary);

	bool secondBinary[33] = {};

	cout << "¬торое число в двоичной записи: ";
	intToBinary(secondNumber, secondBinary);

	bool thirdBinary[33] = {};

	cout << "—умма первых двух чисел в двоичном представлении: ";
	sumBinary(firstBinary, secondBinary, thirdBinary);

	int thirdNumber = binToInt(thirdBinary);
	cout << "–езультат в дес€тичном виде: " << thirdNumber << endl;;

	return 0;
}

/*
ѕри вводе первого числа 373 и второго -167 программа вывела:
ѕервое число в двоичной записи: 1 0 1 1 1 0 1 0 1
¬торое число в двоичной записи: 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 0 1 0 1 1 0 0 1
—умма первых двух чисел в двоичном представлении: 1 1 0 0 1 1 1 0
–езультат в дес€тичном виде: 206
*/
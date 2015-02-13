#include <iostream>

using namespace std;

int main()
{
	setlocale(0, "");
	int const index = 100;
	int array[index] = { 0 };
	int lengthBeginArray = 0;
	cout << "Дан массив целых чисел x[1]...x[m+n], рассматриваемый как соединение двух его отрезков: начала x[1]...x[m] длины m и конца x[m+1]...x[m+n] длины n. Данная программа переставляет местами начало и конец. \n";
	cout << "Введите длину m начала x[1]...x[m] массива: ";
	cin >> lengthBeginArray;
	cout << "Введите элементы начала массива: \n";
	for (int i = 0; i < lengthBeginArray; i++)
	{
		cout << i + 1 << " элемент: ";
		cin >> array[i];
	}
	int lengthEndArray = 0;
	cout << "Введите длину n конца x[m+1]...x[n] массива: ";
	cin >> lengthEndArray;
	int lengthMyArray = lengthBeginArray + lengthEndArray; // lengthMyArray = m + n
	cout << "Введите элементы конца массива: \n";
	for (int i = lengthBeginArray; i < lengthMyArray; i++)
	{
		cout << i - lengthBeginArray + 1 << " элемент: ";
		cin >> array[i];
	}
	for (int i = 0; i < lengthBeginArray - i - 1; i++)
	{
		swap(array[i], array[lengthBeginArray - i - 1]); // Переворачиваем начало массива
	}
	for (int i = lengthBeginArray; i < lengthMyArray + lengthBeginArray - i - 1; i++)
	{
		swap(array[i], array[lengthMyArray + lengthBeginArray - i - 1]); // Переворачиваем конец массива
	}
	for (int i = 0; i < lengthMyArray - i - 1; i++)
	{
		swap(array[i], array[lengthMyArray - i - 1]); // Обращаем весь массив как единое целое
	}
	cout << "Новый массив: \n";
	for (int i = 0; i < lengthMyArray; i++)
	{
		cout << array[i] << " ";
	}
	cout << "\n";
	return 0;
}
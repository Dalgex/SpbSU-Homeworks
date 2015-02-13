#include <iostream>
#include <ctime>

using namespace std;

/* Пояснение к нижеприведенной функции: все элементы массива, меньше первого, помещаем слева от него.
Соответственно, элементы, больше первого, автоматически окажутся правее. Но при этом сам первый элемент может сместиться,
поэтому мы вводим переменную mainIndex, которая будет следить за индексом этого элемента.
В конце мы меняем местами array[mainIndex] (первый элемент, относительно которого мы и сортировали другие элементы)
и array[leftIndex] (тот элемент, начиная с которого, все последующие элементы больше или равны первому)
*/

void swapArrayElements(int array[], int number)
{
	int mainIndex = 0;
	int constant = array[mainIndex];
	int leftIndex = 0;
	for (int i = 1; i < number; i++)
	{
		if (array[i] < constant)
		{
			swap(array[i], array[leftIndex]);
			if (mainIndex == leftIndex)
			{
				mainIndex = i;
			}
			leftIndex++;
		}
	}
	swap(array[leftIndex], array[mainIndex]);
}

/* Функция заполняет массив случайными значениями. А затем, при помощи функции swapArrayElements сортирует элементы.
*/

int main()
{
	int const index = 100;
	setlocale(0, "");
	int array[index] = { 0 };
	srand(time(nullptr));
	int number = 0;
	cout << "Данная программа преобразует массив так, что в начале в начале массива будут элементы, меньшие первого, а в конце - большие первого. \n";
	cout << "Введите количество элементов в массиве: ";
	cin >> number;
	for (int i = 0; i < number; i++)
	{
		array[i] = rand() % 30 - 10;
	}
	for (int i = 0; i < number; i++)
	{
		cout << array[i] << " ";
	}
	cout << "\n";
	swapArrayElements(array, number);
	cout << "Вывод: ";
	for (int i = 0; i < number; i++)
	{
		cout << array[i] << " ";
	}
	cout << "\n";
	return 0;
}

/* При вводе 8, программа вывела: 18 11 -2 -7 0 0 -4 -5, а затем с новой строки: 11 -2 -7 0 0 -4 -5 18
При вводе 6, программа вывела: -3 2 -5 4 -2 18, а затем с новой строки: -5 -3 2 4 -2 18
При вводе 0 программа ничего не выводит
*/
#include <iostream>

using namespace std;

int main()
{
	setlocale(0, "");
	int const index = 100;
	int array[index] = { 0 };
	int lengthBeginArray = 0;
	cout << "��� ������ ����� ����� x[1]...x[m+n], ��������������� ��� ���������� ���� ��� ��������: ������ x[1]...x[m] ����� m � ����� x[m+1]...x[m+n] ����� n. ������ ��������� ������������ ������� ������ � �����. \n";
	cout << "������� ����� m ������ x[1]...x[m] �������: ";
	cin >> lengthBeginArray;
	cout << "������� �������� ������ �������: \n";
	for (int i = 0; i < lengthBeginArray; i++)
	{
		cout << i + 1 << " �������: ";
		cin >> array[i];
	}
	int lengthEndArray = 0;
	cout << "������� ����� n ����� x[m+1]...x[n] �������: ";
	cin >> lengthEndArray;
	int lengthMyArray = lengthBeginArray + lengthEndArray; // lengthMyArray = m + n
	cout << "������� �������� ����� �������: \n";
	for (int i = lengthBeginArray; i < lengthMyArray; i++)
	{
		cout << i - lengthBeginArray + 1 << " �������: ";
		cin >> array[i];
	}
	for (int i = 0; i < lengthBeginArray - i - 1; i++)
	{
		swap(array[i], array[lengthBeginArray - i - 1]); // �������������� ������ �������
	}
	for (int i = lengthBeginArray; i < lengthMyArray + lengthBeginArray - i - 1; i++)
	{
		swap(array[i], array[lengthMyArray + lengthBeginArray - i - 1]); // �������������� ����� �������
	}
	for (int i = 0; i < lengthMyArray - i - 1; i++)
	{
		swap(array[i], array[lengthMyArray - i - 1]); // �������� ���� ������ ��� ������ �����
	}
	cout << "����� ������: \n";
	for (int i = 0; i < lengthMyArray; i++)
	{
		cout << array[i] << " ";
	}
	cout << "\n";
	return 0;
}
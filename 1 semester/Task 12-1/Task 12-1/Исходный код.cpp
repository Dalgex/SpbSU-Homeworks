#include <iostream>
#include <string>
#include <fstream>
#include "RabinKarp.h"

using namespace std;

// Считываем из файла строку
void readingFile(string &str)
{
	ifstream file("Text.txt", ios::in);

	if (!file.is_open())
	{
		cout << "Error! File is not found\n";
		return;
	}

	while (!file.eof())
	{
		string str1;
		getline(file, str1);
		str += str1; // к строке str добавляем строку, считанную из файла
		str1 += '\n';
	}

	file.close();
}

int main()
{
	string substring;
	cout << "Enter the substring: ";
	cin >> substring; 
	string str;
	readingFile(str);
	rabinKarp(str, substring);
	return 0;
}

/*
The earth we live is a circle
Hot hot sun is a circle
The cool moon is a circle
Delicious orange is a circle
Bangles we wear too is a circle
Hey The ball we play is also a circle
Children! Now We all know
What a circle is!

Подстрока: circle
Position: 24

Подстрока: sun
Position: 38

Подстрока: red
Substring was not found
*/
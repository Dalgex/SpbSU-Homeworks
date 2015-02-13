#include <fstream>
#include <iostream>
#include <string>

using namespace std;

int main()
{
	ifstream file("../test.txt", ios::in);
	if (!file.is_open())
	{
		cout << "File not found!" << endl;
		return 1;
	}
	int k = 0;
	while (!file.eof())
	{
		string str;
		getline(file, str);
		str += '\n';
		int i = 0;
		while (str[i] != '\n')
		{
			if ((str[i] != ' ') && (str[i] != '\t'))
			{
				k++;
				break;
			}
			else
			{
				i++;
			}
		}
	}
	file.close();
	cout << k << endl;
	return 0;
}
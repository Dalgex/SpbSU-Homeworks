using System;
using System.IO;

namespace Task_2._3
{
    class Program
    {
        static void Main()
        {
            HashTable hashTable = new HashTable();
            ReadingFile(hashTable);
            hashTable.WriteToFile();
        }

        // Проверка, является ли данный символ подходящим для слова, т.е. убираются символы: ; " ? , . !  и т.д.
        static bool IsCorrectSymbol(char symbol)
        {
            return (symbol >= 'a' && symbol <= 'z') || (symbol >= 'A' && symbol <= 'Z') || (symbol >= '0' && symbol <= '9') || (symbol == '-') || (symbol == '\'');
        }

        // Чтение из файла
        static void ReadingFile(HashTable hashTable)
        {
            FileInfo file = new FileInfo("Text.txt");

            if (!file.Exists)
            {
                Console.WriteLine("Файл не найден");
                return;
            }

            StreamReader sr = file.OpenText();

            /*
            Считываем из файла слово в переменную word. Создаем дополнительную переменную line.
	        Если символ является подходящим для слова, добавляем в line. Если нет, то идем дальше.
            */
            while (!sr.EndOfStream)
            {
                string word = sr.ReadLine();
                string line = "";

                for (int i = 0; i < word.Length; i++)
                {
                    if (IsCorrectSymbol(word[i]))
                    {
                        line += word[i];
                    }
                    else
                    {
                        if (line.Length > 0) // необходимая проверка например для: hello,world. Мы дошли до запятой, этот символ не входит в слово, тогда делаем проверку: если строка line ненулевая, т.е. уже записано какое-либо слово туда, то добавляем его в хэш-таблицу и обнуляем line. И продолжаем читать дальше
                        {
                            hashTable.AddElementHashTable(line);
                            line = "";
                        }
                    }
                }

                if (line.Length > 0) // вернемся к примеру, описанному выше: hello,world. Мы добавbли слово hello в таблицу, далее пропустили запятую и считали слово world. Видим, что длина больше 0, значит, добавляем и его в хэш-таблицу
                {
                    hashTable.AddElementHashTable(line);
                }
            }

            sr.Close();
        }
    }
}

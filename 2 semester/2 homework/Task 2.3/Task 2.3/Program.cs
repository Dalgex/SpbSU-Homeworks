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

        /// <summary>
        ///  Чтение из файла
        /// </summary>
        static void ReadingFile(HashTable hashTable)
        {
            FileInfo file = new FileInfo("Text.txt");

            if (!file.Exists)
            {
                Console.WriteLine("Файл не найден");
                return;
            }

            StreamReader sr = file.OpenText();

            while (!sr.EndOfStream)
            {
                string value = sr.ReadLine();

                foreach (string line in value.Split(' '))
                {
                    if (line == "")
                    {
                        continue;
                    }

                    hashTable.AddElementHashTable(line);
                }
            }

            sr.Close();
        }
    }
}

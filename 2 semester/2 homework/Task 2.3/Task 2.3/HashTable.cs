using System;
using System.IO;

namespace Task_2._3
{
    class HashTable
    {
        private const int hashTableSize = 20000;

        List[] hashTableList;
        private int countOfWords;

        public HashTable()
        {
            hashTableList = new List[hashTableSize];

            for (int i = 0; i < hashTableList.Length; i++)
            {
                this.hashTableList[i] = new List();
            }

            this.countOfWords = 0;
        }

        // Возвращает размер хеш-таблицы
        private int Length()
        {
            return hashTableList.Length;
        }

        // Добавление элемента
        public void AddElementHashTable(string word)
        {
            this.hashTableList[HashFunction(word)].AddListElement(word);
            this.countOfWords++;
        }

        // Хеш-функция
        private int HashFunction(string word)
        {
            int result = 0;
            int factor = 89;

            for (int i = 0; i < word.Length; i++)
            {
                result = (result * factor + word[i]) % hashTableSize;
            }

            return result;
        }

        // Запись в файл
        public void WriteToFile()
        {
            Console.WriteLine("Количество слов: {0}", this.countOfWords);
            StreamWriter sw = new StreamWriter("hashTable.txt");

            for (int i = 0; i < this.Length(); i++)
            {
                while (this.hashTableList[i].Count() != 0)
                {
                    int number = this.hashTableList[i].NumberOfWords();
                    string word = this.hashTableList[i].DeleteListElement();
                    sw.WriteLine(word + " " + number); // записываем слово и сколько раз оно встретилось
                }
            }

            sw.Close();
            Console.WriteLine("Файл сохранен");
        }
    }
}

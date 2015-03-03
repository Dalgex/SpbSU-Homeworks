using System;
using System.IO;

namespace Task_2._3
{
    public class HashTable
    {
        private const int hashTableSize = 20000;

        List[] hashTableList;

        public HashTable()
        {
            hashTableList = new List[hashTableSize];

            for (int i = 0; i < hashTableList.Length; i++)
            {
                this.hashTableList[i] = new List();
            }
        }

        /// <summary>
        ///  Возвращает размер хеш-таблицы
        /// </summary>
        private int Length()
        {
            return hashTableList.Length;
        }

        /// <summary>
        ///  Добавление элемента
        /// </summary>
        public void AddElementHashTable(string value)
        {
            this.hashTableList[HashFunction(value)].AddListElement(value);
        }

        /// <summary>
        ///  Хеш-функция
        /// </summary>
        private int HashFunction(string value)
        {
            int result = 0;
            int factor = 89;

            for (int i = 0; i < value.Length; i++)
            {
                result = (result * factor + value[i]) % hashTableSize;
            }

            return result;
        }

        /// <summary>
        /// Проверка на принадлежность
        /// </summary>
        public bool Contains(string value)
        {
            return hashTableList[HashFunction(value)].Contains(value);
        }

        /// <summary>
        /// Удаление элемента
        /// </summary>
        public bool RemoveElement(string value)
        {
            return (hashTableList[HashFunction(value)].RemoveListElement(value));
        }

        /// <summary>
        ///  Запись в файл
        /// </summary>
        public void WriteToFile()
        {
            StreamWriter sw = new StreamWriter("hashTable.txt");

            for (int i = 0; i < this.Length(); i++)
            {
                while (this.hashTableList[i].Count() != 0)
                {
                    int number = this.hashTableList[i].NumberOfElements();
                    string value = this.hashTableList[i].DeleteListElement();
                    sw.WriteLine(value + " " + number); // записываем значение и сколько раз оно встретилось
                }
            }

            sw.Close();
            Console.WriteLine("Файл сохранен");
        }
    }
}

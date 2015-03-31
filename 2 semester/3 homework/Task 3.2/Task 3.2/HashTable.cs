using System;

namespace Task_3._2
{
    /// <summary>
    /// Предоставляет коллекцию пар "ключ-значение", которые упорядочены по хэш-коду ключа
    /// </summary>
    public class HashTable
    {
        private const int hashTableSize = 1000;

        private List[] hashTableList;

        public delegate int Hashing(string value);
        private Hashing hashFunction;

        public HashTable()
        {
            hashTableList = new List[hashTableSize];

            for (int i = 0; i < hashTableList.Length; i++)
            {
                this.hashTableList[i] = new List();
            }

            this.hashFunction = HashFunction;
        }

        public HashTable(Hashing hashFunc) :this()
        {
            this.hashFunction = hashFunc;
        }

        /// <summary>
        ///  Возвращает размер хеш-таблицы
        /// </summary>
        public int Length()
        {
            return hashTableList.Length;
        }

        /// <summary>
        /// Возвращает хеш-код указанного ключа
        /// </summary>
        private int GetHash(string value)
        {
            return hashFunction(value);
        }

        /// <summary>
        ///  Добавление элемента
        /// </summary>
        public void AddElementHashTable(string value)
        {
            int index = GetHash(value);
            this.hashTableList[index].AddListElement(value);
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
            int index = GetHash(value);
            return hashTableList[index].Contains(value);
        }

        /// <summary>
        /// Удаление элемента
        /// </summary>
        public bool RemoveElement(string value)
        {
            int index = GetHash(value);
            return (hashTableList[index].RemoveListElement(value));
        }
    }
}

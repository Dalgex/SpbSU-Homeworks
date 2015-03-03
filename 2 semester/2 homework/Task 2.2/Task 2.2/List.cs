using System;

namespace Task_2._2
{
    class List
    {
        class ListElement
        {
            public ListElement Next { get; set; }
            public int Value { get; private set; }

            public ListElement(int value, ListElement next)
            {
                this.Next = next;
                this.Value = value;
            }
        }

        private ListElement head;
        private int size;

        public List()
        {
            this.head = new ListElement(0, null);
        }

        /// <summary>
        ///  Добавление элемента
        /// </summary>
        public void AddListElement(int value)
        {
            this.head.Next = new ListElement(value, this.head.Next);
            this.size++;
            Console.WriteLine("Значение добавлено");
        }

        /// <summary>
        ///  Проверка на пустоту
        /// </summary>
        private bool IsEmpty()
        {
            return this.head.Next == null;
        }

        /// <summary>
        ///  Количество элементов в списке
        /// </summary>
        public int Count()
        {
            return this.size;
        }

        /// <summary>
        ///  Распечатывание списка
        /// </summary>
        public void PrintList()
        {
            ListElement current = this.head.Next;

            if (IsEmpty())
            {
                Console.WriteLine("Список пуст");
                return;
            }

            Console.Write("Список: ");

            while (current != null)
            {
                Console.Write("{0} ", current.Value);
                current = current.Next;
            }

            Console.WriteLine();
        }

        /// <summary>
        ///  Определяет, входит ли элемент в состав списка
        /// </summary>
        public bool Contains(int value)
        {
            if (IsEmpty())
            {
                return false;
            }

            ListElement current = this.head.Next;

            while ((current.Value != value) && (current.Next != null))
            {
                current = current.Next;
            }

            return current.Value == value;
        }

        /// <summary>
        ///  Удаление указанного элемента
        /// </summary>
        public void RemoveListElement(int value)
        {
            ListElement current = this.head.Next;
            ListElement previous = this.head;

            if (IsEmpty())
            {
                Console.WriteLine("Список пуст");
                return;
            }

            while ((current.Value != value) && (current.Next != null))
            {
                current = current.Next;
                previous = previous.Next;
            }

            if (current.Value == value)
            {
                previous.Next = current.Next;
                this.size--;
                Console.WriteLine("Элемент удален");
            }
            else
            {
                Console.WriteLine("Элемент не найден");
            }
        }
    }
}

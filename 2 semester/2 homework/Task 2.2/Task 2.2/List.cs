using System;

namespace Task_2._2
{
    class List
    {
        class ListElement
        {
            public ListElement pNext { get; set; }
            public int value { get; private set; }

            public ListElement(int value, ListElement pNext)
            {
                this.pNext = pNext;
                this.value = value;
            }
        }

        private ListElement head;
        private int size;

        public List()
        {
            this.head = new ListElement(0, null);
            this.size = 0;
        }

        // Добавление элемента
        public void AddListElement(int value)
        {
            this.head.pNext = new ListElement(value, this.head.pNext);
            this.size++;
            Console.WriteLine("Значение добавлено");
        }

        // Проверка на пустоту
        private bool IsEmpty()
        {
            return this.head.pNext == null;
        }

        // Количество элементов в списке
        public int Count()
        {
            return this.size;
        }

        // Распечатывание списка
        public void PrintList()
        {
            ListElement current = this.head.pNext;

            if (IsEmpty())
            {
                Console.WriteLine("Список пуст");
                return;
            }

            Console.Write("Список: ");

            while (current != null)
            {
                Console.Write("{0} ", current.value);
                current = current.pNext;
            }

            Console.WriteLine();
        }

        // Определяет, входит ли элемент в состав списка
        public bool Contains(int value)
        {
            if (IsEmpty())
            {
                return false;
            }

            ListElement current = this.head.pNext;

            while ((current.value != value) && (current.pNext != null))
            {
                current = current.pNext;
            }

            if (current.value == value)
            {
                return true;
            }

            return false;
        }

        // Удаление указанного элемента
        public void RemoveListElement(int value)
        {
            ListElement current = this.head.pNext;
            ListElement previous = this.head;

            if (IsEmpty())
            {
                Console.WriteLine("Список пуст");
                return;
            }

            while ((current.value != value) && (current.pNext != null))
            {
                current = current.pNext;
                previous = previous.pNext;
            }

            if (current.value == value)
            {
                previous.pNext = current.pNext;
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

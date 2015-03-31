using System;

namespace Task_3._2
{
    class List
    {
        class ListElement
        {
            public ListElement Next { get; set; }
            public string Value { get; private set; }
            public int Counter { get; set; } // переменная счетчик. Записываем, сколько раз встретилось нам данное значение

            public ListElement(string value, ListElement next)
            {
                this.Next = next;
                this.Value = value;
            }
        }

        private ListElement head;
        private int size;

        /// <summary>
        ///  Добавление элемента
        /// </summary>
        public void AddListElement(string value)
        {
            ListElement current = this.head;

            while ((current != null) && (current.Value != value)) // пока не конец списка и наше значение не встретилось...
            {
                current = current.Next;
            }

            if (current == null) // если current == null, это означает, что значение имеет такой же ключ, как и другое значение, которое лежит уже в этом списке, или список еще пуст
            {
                this.head = new ListElement(value, this.head);
                this.head.Counter++;
                this.size++;
            }
            else
            {
                current.Counter++; // current != null, т.е. мы нашли элемент в списке, который ранее встречался в тексте. Тогда просто увеличиваем счетчик
            }
        }

        /// <summary>
        ///  Количество элементов в списке
        /// </summary>
        public int Count()
        {
            return this.size;
        }

        /// <summary>
        ///  Сколько раз встретилось значение, которое сейчас находится в голове списка
        /// </summary>
        public int NumberOfElements()
        {
            return this.head.Counter;
        }

        /// <summary>
        ///  Определяет, входит ли элемент в состав списка
        /// </summary>
        public bool Contains(string value)
        {
            ListElement current = this.head;

            if (current == null)
            {
                return false;
            }

            while ((current.Value != value) && (current.Next != null))
            {
                current = current.Next;
            }

            return current.Value == value;
        }

        /// <summary>
        ///  Удаление верхнего элемента
        /// </summary>
        public string DeleteListElement()
        {
            string value = this.head.Value;
            this.head = this.head.Next;
            this.size--;
            return value;
        }

        /// <summary>
        /// Удаление указанного элемента
        /// </summary>
        public bool RemoveListElement(string value)
        {
            ListElement previous = head;
            ListElement current = head;

            while (current != null && current.Value != value)
            {
                previous = current;
                current = current.Next;
            }

            if (current != null)
            {
                if (current == head)
                {
                    head = head.Next;
                }
                else
                {
                    previous.Next = current.Next;
                }

                size--;
                return true;
            }

            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4._2
{
    public class List
    {
        public class ListElement
        {
            public int Value { get; private set; }
            public ListElement Next { get; set; }

            public ListElement(int value, ListElement next)
            {
                Next = next;
                Value = value;
            }
        }

        private ListElement head;
        private int size;

        /// <summary>
        /// Добавление элемента
        /// </summary>
        public virtual void AddListElement(int value)
        {
            ListElement newElement = new ListElement(value, head);
            head = newElement;
            size++;
        }

        /// <summary>
        /// Возвращает количество элементов в списке
        /// </summary>
        public int Count()
        {
            return size;
        }

        /// <summary>
        /// Определяет, входит ли элемент в состав списка
        /// </summary>
        public bool Contains(int value)
        {
            if (head == null)
            {
                return false;
            }

            ListElement current = head;

            while (current.Next != null && current.Value != value)
            {
                current = current.Next;
            }

            return current.Value == value;
        }

        /// <summary>
        /// Удаление указанного элемента
        /// </summary>
        public virtual bool RemoveListElement(int value)
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

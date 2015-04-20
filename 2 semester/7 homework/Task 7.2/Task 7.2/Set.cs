using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_7._2
{
    /// <summary>
    /// Предоставляет АТД "Множество"
    /// </summary>
    public class Set<T>
    {
        class SetElement
        {
            public SetElement Next { get; set; }
            public T Value { get; set; }

            public SetElement(T value, SetElement next)
            {
                Next = next;
                Value = value;
            }
        }

        private SetElement head;
        private int size;

        /// <summary>
        /// Возвращает число элементов, содержащихся во множестве
        /// </summary>
        public int Count
        {
            get { return size; }
        }

        /// <summary>
        /// Добавляет элемент в текущее множество и возвращает значение, указывающее, что элемент был добавлен успешно
        /// </summary>
        public bool Add(T value)
        {
            if (!Contains(value))
            {
                var newElement = new SetElement(value, head);
                head = newElement;
                size++;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Определяет, содержит ли множество указанное значение 
        /// </summary>
        public bool Contains(T value)
        {
            var current = head;

            while (current != null)
            {
                if (Equals(current.Value, value))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        /// <summary>
        /// Удаляет указанный элемент из набора и возвращает значение, указывающее, был ли объект value успешно удален
        /// </summary>
        public bool Remove(T value)
        {
            var previous = head;
            var current = head;

            while (current != null && !Equals(current.Value, value))
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

        /// <summary>
        /// Возвращает множество, содержащее в себе все элементы исходных множеств
        /// </summary>
        public Set<T> UniteSets(Set<T> secondSet)
        {
            Set<T> resultSet = new Set<T>();
            var current = head;

            for (int i = 0; i < Count; i++)
            {
                resultSet.Add(current.Value);
                current = current.Next;
            }

            current = secondSet.head;

            while (current != null)
            {
                resultSet.Add(current.Value);
                current = current.Next;
            }

            return resultSet;
        }

        /// <summary>
        /// Возвращает множество, которое содержит только те элементы, которые входят в оба данных множества
        /// </summary>
        public Set<T> IntersectSets(Set<T> secondSet)
        {
            Set<T> resultSet = new Set<T>();
            var current = head;

            while (current != null)
            {
                if (secondSet.Contains(current.Value))
                {
                    resultSet.Add(current.Value);
                }

                current = current.Next;
            }

            return resultSet;
        }
    }
}

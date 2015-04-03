using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_1
{
    /// <summary>
    /// Класс очередь с приоритетами
    /// </summary>
    public class PriorityQueue<T>
    {
        class QueueElement
        {
            public QueueElement Next { get; set; }
            public QueueElement Previous { get; set; }
            public T Value { get; private set; }
            public int Priority { get; private set; }

            public QueueElement(T value, int priority)
            {
                Priority = priority;
                Value = value;
            }
        }

        private QueueElement head;
        private QueueElement tail;
        private int highestPriority; // самый высокий приоритет

        /// <summary>
        /// Число элементов, содержащихся в очереди
        /// </summary>
        public int Count { get; private set; } 

        /// <summary>
        /// Принимает на вход значение и численный приоритет и добавляет элемент в очередь
        /// </summary>
        public void Enqueue(T value, int priority)
        {
            QueueElement newElement = new QueueElement(value, priority);
            newElement.Previous = tail;

            if (Count > 0)
            {
                tail.Next = newElement;
            }
            else
            {
                head = newElement;
            }

            tail = newElement;
            Count++;

            if (newElement.Priority > highestPriority)
            {
                highestPriority = newElement.Priority;
            }
        }

        /// <summary>
        /// Поиск элемента с самым высоким приоритетом
        /// </summary>
        public void newHighestPriority()
        {
            if (Count == 0)
            {
                highestPriority = 0;
                return;
            }

            QueueElement current = head;
            highestPriority = head.Priority;

            while (current != null)
            {
                if (current.Priority > highestPriority)
                {
                    highestPriority = current.Priority;
                }

                current = current.Next;
            }
        }

        /// <summary>
        /// Возвращает значение с наивысшим приоритетом и удаляет его из оереди
        /// </summary>
        public T Dequeue()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            QueueElement current = head;

            while (current.Next != null)
            {
                if (current.Priority == highestPriority)
                {
                    break;
                }

                current = current.Next;
            }

            Count--;

            if (current == head)
            {
                head = head.Next;
                newHighestPriority();
                return current.Value;
            }

            if (current.Next == null)
            {
                tail.Previous.Next = null;
                tail = current.Previous;
                newHighestPriority();
                return current.Value;
            }

            current.Previous.Next = current.Next;
            current.Next.Previous = current.Previous;
            newHighestPriority();
            return current.Value;
        }
    }
}

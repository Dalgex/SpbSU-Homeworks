using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_7._1
{
    /// <summary>
    /// Представляет коллекцию объектов, действующую по принципу: последним пришел - первым вышел
    /// </summary>
    public class Stack<T>
    {
        class StackElement
        {
            public T Value { get; private set; }
            public StackElement Next { get; private set; }

            public StackElement(T value, StackElement next)
            {
                Next = next;
                Value = value;
            }
        }

        private StackElement top;
        private int size;

        /// <summary>
        /// Получает число элементов, содержащихся в коллекции Stack<typeparamref name="&lt;T&gt;"/>
        /// </summary>
        public int Count
        {
            get { return size; }
        }

        /// <summary>
        /// Вставляет объект в верхнюю часть Stack<typeparamref name="&lt;T&gt;"/>
        /// </summary>
        public void Push(T value)
        {
            StackElement newElement = new StackElement(value, top);
            top = newElement;
            size++;
        }

        /// <summary>
        /// Возвращает самый верхний объект Stack<typeparamref name="&lt;T&gt;"/>, но не удаляет его
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Стек пуст");
            }

            return top.Value;
        }

        /// <summary>
        /// Определяет, находится ли элемент в Stack<typeparamref name="&lt;T&gt;"/>
        /// </summary>
        public bool Contains(T value)
        {
            var current = top;

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
        /// Удаляет и возвращает объект из верхней части Stack<typeparamref name="&lt;T&gt;"/>
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public T Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Стек пуст");
            }

            T result = top.Value;
            top = top.Next;
            size--;
            return result;
        }

        /// <summary>
        /// Удаляет все объекты из Stack<typeparamref name="&lt;T&gt;"/>
        /// </summary>
        public void Clear()
        {
            top = null;
            size = 0;
        }
    }
}

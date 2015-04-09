using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_6._1
{
    /// <summary>
    /// Представляет коллекцию объектов, действующую по принципу: последним пришел - первым вышел
    /// </summary>
    class Stack
    {
        class StackElement
        {
            public StackElement Next { get; private set; }
            public object Value { get; private set; }

            public StackElement(object value, StackElement next)
            {
                this.Next = next;
                this.Value = value;
            }
        }

        private StackElement top;
        private int size;

        /// <summary>
        ///  Добавление элемента
        /// </summary>
        public void Push(object value)
        {
            StackElement newElement = new StackElement(value, this.top);
            this.top = newElement;
            this.size++;
        }

        /// <summary>
        ///  Чтение верхнего элемента
        /// </summary>
        public object Top()
        {
            return this.top.Value;
        }

        /// <summary>
        /// Удаление всех элементов
        /// </summary>
        public void Clear()
        {
            this.top = null;
            this.size = 0;
        }

        /// <summary>
        ///  Проверка на пустоту
        /// </summary>
        public bool IsEmpty()
        {
            return this.top == null;
        }

        /// <summary>
        ///  Удаление последнего элемента
        /// </summary>
        public object Pop()
        {
            if (IsEmpty())
            {
                return 1;
            }

            object result = this.top.Value;
            this.top = this.top.Next;
            this.size--;
            return result;
        }

        /// <summary>
        ///  Возвращает размер стека
        /// </summary>
        public int Size()
        {
            return this.size;
        }
    }
}

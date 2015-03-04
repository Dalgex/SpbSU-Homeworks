using System;

namespace Task_3._1
{
    public class Stack
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

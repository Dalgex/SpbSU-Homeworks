using System;

namespace Task_2._1
{
    class Stack
    {
        class StackElement
        {
            public StackElement Next { get; private set; }
            public int Value { get; private set; }

            public StackElement(int value, StackElement next)
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
        public void Push(int value)
        {
            StackElement newElement = new StackElement(value, this.top);
            this.top = newElement;
            this.size++;
        }

        /// <summary>
        ///  Чтение верхнего элемента
        /// </summary>
        public int Top()
        {
            return this.top.Value;
        }

        /// <summary>
        ///  Распечатывание стека
        /// </summary>
        public void PrintStack()
        {
            StackElement current = this.top;

            if (IsEmpty())
            {
                Console.WriteLine("Стек пуст");
                return;
            }

            Console.Write("Стек: ");

            while (current != null)
            {
                Console.Write("{0} ", current.Value);
                current = current.Next;
            }

            Console.WriteLine();
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
        public int Pop()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Стек пуст");
                return 1;
            }

            int result = this.top.Value;
            this.top = this.top.Next;
            this.size--;
            Console.WriteLine("Последний элемент {0} удален", result);
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

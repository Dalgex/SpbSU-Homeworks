using System;

namespace Task_2._1
{
    class Stack
    {
        class StackElement
        {
            public StackElement pNext { get; private set; } // pNext сокращенно от pointer next
            public int value { get; private set; }

            public StackElement(int value, StackElement pNext)
            {
                this.pNext = pNext;
                this.value = value;
            }
        }

        private StackElement top;
        private int size;

        public Stack()
        {
            this.top = null;
            this.size = 0;
        }

        // Добавление элемента
        public void Push(int value)
        {
            StackElement newElement = new StackElement(value, this.top);
            this.top = newElement;
            this.size++;
        }

        // Чтение верхнего элемента
        public int Top()
        {
            return this.top.value;
        }

        // Распечатывание стека
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
                Console.Write("{0} ", current.value);
                current = current.pNext;
            }

            Console.WriteLine();
        }

        // Проверка на пустоту
        public bool IsEmpty()
        {
            return this.top == null;
        }

        // Удаление последнего элемента
        public int Pop()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Стек пуст");
                return 1;
            }

            int result = this.top.value;
            this.top = this.top.pNext;
            this.size--;
            Console.WriteLine("Последний элемент {0} удален", result);
            return result;
        }

        // Возвращает размер стека
        public int Size()
        {
            return this.size;
        }
    }
}

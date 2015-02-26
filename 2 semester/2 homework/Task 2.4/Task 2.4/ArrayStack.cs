using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2._4
{
    class ArrayStack : IStack
    {
        object[] array;

        public ArrayStack()
        {
            array = new object[3];
            this.size = 0;
        }

        private int size;

        /// <summary>
        ///  Добавление элемента в конец
        /// </summary>
        public void Add(object value)
        {
            if (this.size == array.Length)
            {
                Array.Resize(ref array, array.Length * 2);
            }

            int index = this.size;
            this.array[index] = value;
            this.size++;
        }

        /// <summary>
        ///  Удаление последнего элемента и возвращение его значения
        /// </summary>
        public object RemoveLast()
        {
            this.size--;
            int index = this.size;
            return array[index];
        }

        /// <summary>
        ///  Просмотр последнего элемента
        /// </summary>
        /// <returns></returns>
        public object LastElement()
        {
            int index = this.size - 1;
            return array[index];
        }

        public void Push(object value)
        {
            Add(value);
        }

        public object Pop()
        {
            return RemoveLast();
        }

        public object Top()
        {
            return LastElement();
        }

        public bool IsEmpty()
        {
            return this.size == 0;
        }

        public int Size()
        {
            return this.size;
        }
    }
}

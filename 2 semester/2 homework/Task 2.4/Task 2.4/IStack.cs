using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2._4
{
    interface IStack
    {
        /// <summary>
        ///  Добавление элемента в голову
        /// </summary>
        void Push(object value);

        /// <summary>
        ///  Извлечь из стека последний элемент
        /// </summary>
        object Pop();

        /// <summary>
        ///  Узнать значение последнего элемента
        /// </summary>
        object Top();

        /// <summary>
        ///  Проверка на пустоту
        /// </summary>
        bool IsEmpty();
       
        /// <summary>
        ///  Размер стека
        /// </summary>
        int Size();
    }
}

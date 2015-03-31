using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4._2
{
    public class UniqueList : List
    {
        /// <summary>
        /// Добавление элемента
        /// </summary>
        public override void AddListElement(int value)
        {
            if (Contains(value))
            {
                throw new AddExistentElementException("Такой элемент уже существует");
            }

            base.AddListElement(value);
        }

        /// <summary>
        /// Удаление элемента
        /// </summary>
        public override bool RemoveListElement(int value)
        {
            if (!Contains(value))
            {
                throw new RemoveNonexistentElementException("Такого элемента не существует");
            }

            return base.RemoveListElement(value);
        }
    }
}

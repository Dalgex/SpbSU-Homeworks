using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5._1
{
    /// <summary>
    /// Класс, реализующий функцию Map
    /// </summary>
    public class MapClass<T>
    {
        /// <summary>
        /// Map функция, которая принимает список и функцию, преобразующую элемент списка
        /// </summary>
        public List<T> Map(List<T> list, Func<T, T> function)
        {
            List<T> mapList = new List<T>();

            foreach(var temp in list)
            {
                mapList.Add(function(temp));
            }

            return mapList;
        }
    }
}

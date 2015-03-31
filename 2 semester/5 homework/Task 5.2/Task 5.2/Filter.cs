using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5._2
{
    /// <summary>
    /// Класс, реализующий функцию Filter
    /// </summary>
    public class FilterClass<T>
    {
        /// <summary>
        ///  Принимает список и функцию, возвращающую список, составленный из тех элементов переданного списка, для которых переданная функция вернула true
        /// </summary>
        public List<T> Filter(List<T> list, Func<T, bool> function)
        {
            List<T> filterList = new List<T>();

            foreach (var temp in list)
            {
                if (function(temp))
                {
                    filterList.Add(temp);
                }
            }

            return filterList;
        }
    }
}

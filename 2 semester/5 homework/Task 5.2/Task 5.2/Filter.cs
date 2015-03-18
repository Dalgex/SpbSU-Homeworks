using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5._2
{
    public class FilterClass<T>
    {
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

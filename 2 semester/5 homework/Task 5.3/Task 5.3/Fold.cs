using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5._3
{
    public class FoldClass<T>
    {
        public T Fold(List<T> list, T value, Func<T, T, T> function)
        {
            List<int> foldList = new List<int>();

            foreach (var temp in list)
            {
                value = function(value, temp);
            }

            return value;
        }
    }
}

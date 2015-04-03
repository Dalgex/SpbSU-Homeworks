using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4._1
{
    public class Program
    {
        static void Main(string[] args)
        {
            var tree = ReadingFile.ReadFromFile("expression1.txt");
            Console.WriteLine("Дерево разбора:{0}", tree.PrintParseTree());
            Console.WriteLine("Результат: {0}", tree.CalculateTree());
        }
    }
}

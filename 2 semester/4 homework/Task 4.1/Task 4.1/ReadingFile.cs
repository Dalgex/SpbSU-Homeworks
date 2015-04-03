using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task_4._1
{
    /// <summary>
    /// Класс для чтения из файла
    /// </summary>
    public static class ReadingFile
    {
        /// <summary>
        /// Чтение выражения из файла
        /// </summary>
        public static ConstructParseTree ReadFromFile(string fileName)
        {
            var tree = new ConstructParseTree();
            FileInfo file = new FileInfo(fileName);

            if (!file.Exists)
            {
                throw new FileNotFoundException("Файл не найден");
            }

            StreamReader sr = file.OpenText();

            string expression = sr.ReadLine();
            expression = expression.Replace(" ", string.Empty);

            for (int i = 0; i < expression.Length; i++)
            {
                if (tree.IsOperator(expression[i]) || Char.IsDigit(expression[i]))
                {
                    tree.AddElement(expression[i]);
                }
            }

            sr.Close();
            return tree;
        }
    }
}

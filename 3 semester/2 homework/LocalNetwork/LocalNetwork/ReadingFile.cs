using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    public class ReadingFile
    {
        /// <summary>
        /// Считывает данные из файла
        /// </summary>
        public static void ReadFromFile(string fileName, out Computer[] comp, out OperatingSystem[] system, out bool[,] matrix)
        {
            FileInfo file = new FileInfo(fileName);

            if (!file.Exists)
            {
                throw new FileNotFoundException("Файл не найден");
            }

            StreamReader sr = file.OpenText();
            int numberOfComps = Convert.ToInt32(sr.ReadLine()); // считываем кол-во компьютеров
            matrix = new bool[numberOfComps, numberOfComps];

            for (int i = 0; i < numberOfComps; i++) // составляем матрицу смежности
            {
                string[] str = sr.ReadLine().Split(' ');

                for (int j = 0; j < str.Length; j++)
                {
                    matrix[i, j] = Convert.ToBoolean(Convert.ToInt32(str[j]));
                }
            }

            int numberOfSystems = Convert.ToInt32(sr.ReadLine()); // считываем кол-во операционных систем
            system = new OperatingSystem[numberOfSystems];

            for (int i = 0; i < numberOfSystems; i++)
            {
                string[] str = sr.ReadLine().Split(' ');  // считываем название ОС и вероятность заражения
                system[i] = new OperatingSystem(str[0], Convert.ToInt32(str[1]));
            }

            comp = new Computer[numberOfComps];

            for (int i = 0; i < numberOfComps; i++)
            {
                string[] str = sr.ReadLine().Split(' '); // считываем номер компьютера и тип ОС, которая на нем стоит
                comp[i] = new Computer(NameOfSystem(str[2], system));
            }

            int numberOfInfectedComps = Convert.ToInt32(sr.ReadLine()); // считываем кол-во зараженных машин
            string[] temp = sr.ReadLine().Split(' '); // считываем номера зараженных компьютеров

            for (int i = 0; i < numberOfInfectedComps; i++)
            {
                comp[Convert.ToInt32(temp[i])].IsInfected = true;
            }

            sr.Close();
        }

        /// <summary>
        /// Находит и возвращает операционную систему с именем name
        /// </summary>
        private static OperatingSystem NameOfSystem(string name, OperatingSystem[] system)
        {
            foreach (var temp in system)
            {
                if (temp.SystemName == name)
                {
                    return temp;
                }
            }

            return null;
        }
    }
}

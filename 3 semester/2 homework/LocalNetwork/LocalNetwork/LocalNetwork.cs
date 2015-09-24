using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    /// <summary>
    /// Моделирует работу локальной сети
    /// </summary>
    public class LocalNetwork
    {
        private Computer[] comp;
        private OperatingSystem[] system;
        private Random rand;
        private bool[,] matrix;

        public LocalNetwork()
        {
            rand = new Random();
        }

        /// <summary>
        /// Считывает данные из файла
        /// </summary>
        public void ReadFromFile(string fileName)
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
                comp[i] = new Computer(NameOfSystem(str[2]));
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
        private OperatingSystem NameOfSystem(string name)
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

        /// <summary>
        /// Предоставляет данные о компьютере
        /// </summary>
        private class Computer
        {
            public Computer(OperatingSystem systemType)
            {
                SystemType = systemType;
            }

            public OperatingSystem SystemType { get; private set; }
            public bool IsInfected { get; set; }
        }

        /// <summary>
        /// Класс содержит свойства операционной системы
        /// </summary>
        private class OperatingSystem
        {
            public OperatingSystem(string systemName, int probability)
            {
                SystemName = systemName;
                ProbabilityOfInfection = probability;
            }

            public string SystemName { get; private set; }
            public int ProbabilityOfInfection { get; private set; }
        }

        /// <summary>
        /// Проверяет, соединены ли компьютеры с номерами i и j
        /// </summary>
        private bool IsConnected(int i, int j)
        {
            return matrix[i, j];
        }

        /// <summary>
        /// Проверяет, заразился ли компьютер
        /// </summary>
        private bool HasBecomeInfected(int number)
        {
            return rand.Next(100) <= comp[number].SystemType.ProbabilityOfInfection;
        }

        /// <summary>
        /// Ход вирусов
        /// </summary>
        public void Move()
        {
            for (int i = 0; i < comp.Length; i++)
            {
                if (comp[i].IsInfected)
                {
                    for (int j = 0; j < comp.Length; j++)
                    {
                        if (IsConnected(i, j))
                        {
                            if (!comp[j].IsInfected && HasBecomeInfected(j))
                            {
                                comp[j].IsInfected = true;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Выводит состояние сети
        /// </summary>
        public void Display()
        {
            while (true)
            {
                int count = 0;

                for (int i = 0; i < comp.Length; i++)
                {
                    if (comp[i].IsInfected)
                    {
                        Console.WriteLine("Компьютер {0} заражен", i);
                        count++;
                    }
                }

                if (count == comp.Length)
                {
                    break;
                }

                Move();
                System.Threading.Thread.Sleep(2000);
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Возвращает номера зараженных компьютеров. Этот метод сделан для тестов
        /// </summary>
        public string PrintNumberInfectedComps()
        {
            string result = string.Empty;

            for (int i = 0; i < comp.Length; i++)
            {
                if (comp[i].IsInfected)
                {
                    result += Convert.ToString(i) + " ";
                }
            }

            return result;
        }
    }
}

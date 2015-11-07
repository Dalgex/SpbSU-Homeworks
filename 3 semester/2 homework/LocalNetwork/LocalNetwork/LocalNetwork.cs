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
        private Random rand = new Random();
        private bool[,] matrix;

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
                system[i] = NewSystem(str[0], Convert.ToInt32(str[1]));
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
        /// Возвращает новую операционную систему
        /// </summary>
        private OperatingSystem NewSystem(string name, int infectionProbability)
        {
            switch (name)
            {
                case "Linux": return new Linux(infectionProbability);
                case "Windows": return new Windows(infectionProbability);
                case "Unix": return new Unix(infectionProbability);
                case "MacOS": return new MacOS(infectionProbability);
            }

            throw new InvalidOperationException("Неправильные данные");
        }

        /// <summary>
        /// Находит и возвращает операционную систему с именем name
        /// </summary>
        public OperatingSystem NameOfSystem(string name)
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
        /// Проверяет, соединены ли компьютеры с номерами i и j
        /// </summary>
        private bool IsConnected(int i, int j)
        {
            return matrix[i, j];
        }

        /// <summary>
        /// Ход вирусов
        /// </summary>
        public void Move()
        {
            for (int i = 0; i < comp.Length; i++)
            {
                if (comp[i].IsInfected && !comp[i].IsJustInfected)
                {
                    for (int j = 0; j < comp.Length; j++)
                    {
                        if (IsConnected(i, j))
                        {
                            if (!comp[j].IsInfected && comp[j].HasBecomeInfected(rand))
                            {
                                comp[j].IsInfected = true;
                                comp[j].IsJustInfected = true;
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
                        if (comp[i].IsJustInfected)
                        {
                            Console.WriteLine("Компьютер {0} только что заразился", i);
                            comp[i].IsJustInfected = false;
                        }
                        else
                        {
                            Console.WriteLine("Компьютер {0} заражен", i);
                        }

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
                    if (comp[i].IsJustInfected)
                    {
                        comp[i].IsJustInfected = false;
                    }

                    result += Convert.ToString(i) + " ";
                }
            }

            return result;
        }
    }
}

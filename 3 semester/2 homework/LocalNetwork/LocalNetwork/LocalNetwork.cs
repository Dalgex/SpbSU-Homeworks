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
        private Random rand = new Random();
        private OperatingSystem[] system;
        private bool[,] matrix;

        public LocalNetwork(Computer[] comp, OperatingSystem[] system, bool[,] matrix)
        {
            this.comp = comp;
            this.system = system;
            this.matrix = matrix;
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

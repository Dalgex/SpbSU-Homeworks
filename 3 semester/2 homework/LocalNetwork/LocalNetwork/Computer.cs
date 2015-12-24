using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    /// <summary>
    /// Предоставляет данные о компьютере
    /// </summary>
    public class Computer
    {
        public Computer(OperatingSystem systemType)
        {
            SystemType = systemType;
        }

        /// <summary>
        /// Показывает, какая ОС стоит на данном компьютере
        /// </summary>
        public OperatingSystem SystemType { get; private set; }

        /// <summary>
        /// Проверяет, заражен ли компьютер
        /// </summary>
        public bool IsInfected { get; set; }

        /// <summary>
        /// Проверяет, заразился ли только что компьютер
        /// </summary>
        public bool IsJustInfected { get; set; }

        /// <summary>
        /// Пытается заразить компьютер
        /// </summary>
        public void TryInfect(Random rand)
        {
            IsJustInfected = rand.Next(100) <= SystemType.ProbabilityOfInfection;
            Commit();
        }

        private void Commit()
        {
            IsInfected = IsJustInfected;
        }
    }
}

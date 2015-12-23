using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    /// <summary>
    /// Предоставляет данные об операционной системе
    /// </summary>
    public class OperatingSystem
    {
        public OperatingSystem(string systemName, int infectionProbability)
        {
            SystemName = systemName;
            ProbabilityOfInfection = infectionProbability;
        }

        /// <summary>
        /// Показывает название операционной системы
        /// </summary>
        public string SystemName { get; private set; }

        /// <summary>
        /// Показывает вероятность заражения
        /// </summary>
        public int ProbabilityOfInfection { get; private set; }
    }
}

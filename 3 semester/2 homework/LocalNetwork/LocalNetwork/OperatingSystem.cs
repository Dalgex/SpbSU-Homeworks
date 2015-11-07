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
    public abstract class OperatingSystem
    {
        /// <summary>
        /// Показывает название операционной системы
        /// </summary>
        public virtual string SystemName { get; protected set; }

        /// <summary>
        /// Показывает вероятность заражения
        /// </summary>
        public virtual int ProbabilityOfInfection { get; protected set; }
    }
}

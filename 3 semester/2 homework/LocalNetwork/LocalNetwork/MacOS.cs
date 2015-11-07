using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    /// <summary>
    /// Представляет информацию об операционной системе MacOS
    /// </summary>
    public class MacOS : OperatingSystem
    {
        public MacOS(int infectionProbability)
        {
            ProbabilityOfInfection = infectionProbability;
        }

        public override string SystemName
        {
            get { return "MacOS"; }
        }

        public override int ProbabilityOfInfection { get; protected set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    /// <summary>
    /// Представляет информацию об операционной системе Windows
    /// </summary>
    public class Windows : OperatingSystem
    {
        public Windows(int infectionProbability)
        {
            ProbabilityOfInfection = infectionProbability;
        }

        public override string SystemName
        {
            get { return "Windows"; }
        }

        public override int ProbabilityOfInfection { get; protected set; }
    }
}

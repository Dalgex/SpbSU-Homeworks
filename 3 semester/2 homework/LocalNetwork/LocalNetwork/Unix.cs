using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    /// <summary>
    /// Представляет информацию об операционной системе Unix
    /// </summary>
    public class Unix : OperatingSystem
    {
        public Unix(int infectionProbability)
        {
            ProbabilityOfInfection = infectionProbability;
        }

        public override string SystemName
        {
            get { return "Unix"; }
        }

        public override int ProbabilityOfInfection { get; protected set; }
    }
}

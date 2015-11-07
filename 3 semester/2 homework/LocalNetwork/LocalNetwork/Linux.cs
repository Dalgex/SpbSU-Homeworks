using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    /// <summary>
    /// Представляет информацию об операционной системе Linux
    /// </summary>
    public class Linux : OperatingSystem
    {
        public Linux(int infectionProbability)
        {
            ProbabilityOfInfection = infectionProbability;
        }

        public override string SystemName
        {
            get { return "Linux"; }
        }

        public override int ProbabilityOfInfection { get; protected set; }
    }
}

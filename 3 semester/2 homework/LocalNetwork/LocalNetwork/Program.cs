using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    class Program
    {
        static void Main(string[] args)
        {
            Computer[] comp;
            Network.OperatingSystem[] system;
            bool[,] matrix;
            ReadingFile.ReadFromFile("network.txt", out comp, out system, out matrix);
            var netWork = new LocalNetwork(comp, system, matrix);
            Console.WriteLine("Состояние сети:");
            netWork.Display();
        }
    }
}

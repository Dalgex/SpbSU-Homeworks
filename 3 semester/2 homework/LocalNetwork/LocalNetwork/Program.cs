﻿using System;
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
            LocalNetwork netWork = new LocalNetwork();
            netWork.ReadFromFile("network.txt");
            Console.WriteLine("Состояние сети:");
            netWork.Display();
        }
    }
}
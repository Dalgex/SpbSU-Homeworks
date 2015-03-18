using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4._1
{
    class Division : ParseTree
    {
        public Division(char value)
            : base(value) { }

        public override int Calculate()
        {
            if (RightChild.Calculate() == 0)
            {
                throw new DivideByZeroException();
            }

            return LeftChild.Calculate() / RightChild.Calculate();
        }

        public override string Print()
        {
            return " /";
        }
    }
}

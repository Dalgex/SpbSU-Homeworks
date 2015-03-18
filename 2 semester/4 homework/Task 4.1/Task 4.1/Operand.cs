using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4._1
{
    class Operand : ParseTree
    {
        public Operand(char value)
            : base(value) { }

        public override int Calculate()
        {
            return (int) Char.GetNumericValue(Value);
        }

        public override string PrintTree()
        {
            return " " + Convert.ToString(Value);
        }

        public override string Print()
        {
            return string.Empty;
        }
    }
}

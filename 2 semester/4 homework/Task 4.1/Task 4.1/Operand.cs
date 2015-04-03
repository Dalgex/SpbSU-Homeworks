using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4._1
{
    /// <summary>
    /// Класс для операндов
    /// </summary>
    class Operand : ParseTreeNode
    {
        public Operand(char value)
        {
            Value = value;
        }

        public char Value { get; set; }

        public override int Calculate()
        {
            return (int) Char.GetNumericValue(Value);
        }

        public override string PrintTree()
        {
            return " " + Convert.ToString(Value);
        }

        public override bool AddElement(ParseTreeNode treeElement)
        {
            return false;
        }
    }
}

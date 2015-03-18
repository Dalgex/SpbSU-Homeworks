using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4._1
{
    abstract class ParseTree
    {
        public ParseTree LeftChild { get; set; }
        public ParseTree RightChild { get; set; }
        public char Value { get; set; }

        public ParseTree(char value)
        {
            Value = value;
        }

        public virtual string PrintTree()
        {
            return Print() + LeftChild.PrintTree() + RightChild.PrintTree();
        }

        public abstract string Print();

        public abstract int Calculate();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4._1
{
    /// <summary>
    /// Класс оператор, от которого наследуются 4 оператора
    /// </summary>
    abstract class Operator : ParseTreeNode
    {
        public ParseTreeNode LeftChild { get; set; }
        public ParseTreeNode RightChild { get; set; }

        public sealed override string PrintTree()
        {
            return Print() + LeftChild.PrintTree() + RightChild.PrintTree();
        }

        public abstract string Print();

        public override bool AddElement(ParseTreeNode treeElement)
        {
            if (LeftChild == null)
            {
                LeftChild = treeElement;
                return true;
            }

            if (LeftChild.AddElement(treeElement))
            {
                return true;
            }

            if (RightChild == null)
            {
                RightChild = treeElement;
                return true;
            }

            if (RightChild.AddElement(treeElement))
            {
                return true;
            }

            return false;
        }
    }
}

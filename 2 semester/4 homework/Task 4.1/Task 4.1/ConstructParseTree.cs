using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4._1
{
    public class ConstructParseTree
    {
        private ParseTree tree;

        private ParseTree Operator(char value)
        {
            switch (value)
            {
                case '+': return new Addition('+');
                case '-': return new Subtraction('-');
                case '*': return new Multiplication('*');
                case '/': return new Division('/');
            }

            throw new InvalidOperationException("Неправильный символ");
        }

        /// <summary>
        /// Проверка, полная ли ветвь
        /// </summary>
        private bool IsBranchFull(ParseTree treeElement)
        {
            if (treeElement == null)
            {
                return false;
            }

            if (IsOperator(treeElement.Value))
            {
                return IsBranchFull(treeElement.LeftChild) && IsBranchFull(treeElement.RightChild);
            }

            return true;
        }

        private void AddElement(ParseTree treeElement, char value)
        {
            if (treeElement.LeftChild == null)
            {
                if (IsOperator(value))
                {
                    treeElement.LeftChild = Operator(value);
                }
                else
                {
                    treeElement.LeftChild = new Operand(value);
                }
                
                return;
            }

            if (IsOperator(treeElement.LeftChild.Value) && !IsBranchFull(treeElement.LeftChild))
            {
                AddElement(treeElement.LeftChild, value);
                return;
            }

            if (treeElement.RightChild == null)
            {
                if (IsOperator(value))
                {
                    treeElement.RightChild = Operator(value);
                }
                else
                {
                    treeElement.RightChild = new Operand(value);
                }

                return;
            }

            if (IsOperator(treeElement.RightChild.Value) && !IsBranchFull(treeElement.RightChild))
            {
                AddElement(treeElement.RightChild, value);
            }
        }

        /// <summary>
        /// Добавление элемента в дерево
        /// </summary>
        public void AddElement(char value)
        {
            if (tree != null)
            {
                AddElement(tree, value);
            }
            else if (IsOperator(value))
            {
                tree = Operator(value);
            }
            else
            {
                tree = new Operand(value);
            }
        } 

        /// <summary>
        /// Вычисление значения арифметического выражения
        /// </summary>
        public int CalculateTree()
        {
            return tree.Calculate();
        }

        /// <summary>
        /// Распечатывание дерева
        /// </summary>
        public string PrintParseTree()
        {
            return tree.PrintTree();
        }

        /// <summary>
        /// Показывает, является ли указанный символом арифметическим знаком
        /// </summary>
        public bool IsOperator(char symbol)
        {
            return (symbol == '+') || (symbol == '-') || (symbol == '*') || (symbol == '/');
        }
    }
}

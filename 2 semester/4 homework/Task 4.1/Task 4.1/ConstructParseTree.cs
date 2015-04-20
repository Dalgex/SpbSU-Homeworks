using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4._1
{
    public class ConstructParseTree
    {
        private ParseTreeNode tree; // корень дерева

        /// <summary>
        /// Возвращает новый узел оператора symbol
        /// </summary>
        private ParseTreeNode Operator(char symbol)
        {
            switch (symbol)
            {
                case '+': return new Addition();
                case '-': return new Subtraction();
                case '*': return new Multiplication();
                case '/': return new Division();
            }

            throw new InvalidOperationException("Неправильный символ");
        }

        /// <summary>
        /// Добавление элемента в дерево
        /// </summary>
        public void AddElement(char value)
        {
            if (tree != null)
            {
                if (IsOperator(value))
                {
                    tree.AddElement(Operator(value));
                }
                else
                {
                    tree.AddElement(new Operand(value));
                }
            }
            else 
            {
                if (IsOperator(value))
                {
                    tree = Operator(value);
                }
                else
                {
                    tree = new Operand(value);
                }
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

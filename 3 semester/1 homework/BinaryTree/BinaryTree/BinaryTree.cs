using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    /// <summary>
    /// Класс, предназначенный для хранения данных в виде бинарного дерева
    /// </summary>
    public class BinaryTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        private class TreeElement
        {
            public T Value { get; set; }
            public TreeElement RightChild { get; set; }
            public TreeElement LeftChild { get; set; }

            public TreeElement(T value)
            {
                Value = value;
            }
        }

        private TreeElement root;

        /// <summary>
        /// Добавляет элемент в дерево
        /// </summary>
        public void Add(T value)
        {
            if (root == null)
            {
                root = new TreeElement(value);
            }
            else
            {
                var temp = root;

                while (value.CompareTo(temp.Value) != 0)
                {
                    if (value.CompareTo(temp.Value) > 0)
                    {
                        if (temp.RightChild == null)
                        {
                            temp.RightChild = new TreeElement(value);
                            break;
                        }

                        temp = temp.RightChild;
                    }
                    else
                    {
                        if (temp.LeftChild == null)
                        {
                            temp.LeftChild = new TreeElement(value);
                            break;
                        }

                        temp = temp.LeftChild;
                    }
                }
            }
        }

        /// <summary>
        /// Проверяет, является ли дерево пустым
        /// </summary>
        public bool IsEmpty()
        {
            return root == null;
        }

        /// <summary>
        /// Определяет, входит ли элемент в состав коллекции
        /// </summary>
        public bool IsContains(T value)
        {
            var temp = root;

            while (temp != null)
            {
                if (value.CompareTo(temp.Value) == 0)
                {
                    return true;
                }

                if (value.CompareTo(temp.Value) > 0)
                {
                    temp = temp.RightChild;
                }
                else
                {
                    temp = temp.LeftChild;
                }
            }

            return false;
        }

        /// <summary>
        /// Удаляет указанное значение из коллекции
        /// </summary>
        public void Remove(T value)
        {
            root = Remove(root, value);
        }

        private TreeElement Remove(TreeElement current, T value)
        {
            if (current == null)
            {
                return null;
            }

            if (value.CompareTo(current.Value) > 0)
            {
                current.RightChild = Remove(current.RightChild, value);
            }
            else if (value.CompareTo(current.Value) < 0)
            {
                current.LeftChild = Remove(current.LeftChild, value);
            }
            else
            {
                if (current.LeftChild == null && current.RightChild == null)
                {
                    return null;
                }

                if (current.LeftChild == null && current.RightChild != null)
                {
                    current = current.RightChild;
                }
                else if (current.LeftChild != null && current.RightChild == null)
                {
                    current = current.LeftChild;
                }
                else
                {
                    var temp = current.RightChild;
                    var cursor = current.LeftChild;
                    current = current.LeftChild;

                    while (cursor.RightChild != null)
                    {
                        cursor = cursor.RightChild;
                    }

                    cursor.RightChild = temp;
                }
            }

            return current;
        }

        /// <summary>
        /// Возвращает перечислитель, выполняющий перебор элементов коллекции
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            return new TreeEnumerator(this);
        }

        /// <summary>
        /// Возвращает перечислитель, осуществляющий перебор коллекции
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Реализует простой перебор элементов бинарного дерева
        /// </summary>
        private class TreeEnumerator : IEnumerator<T>
        {
            private int iterator;
            private BinaryTree<T> tree;
            private List<T> listForTree;

            public TreeEnumerator(BinaryTree<T> tree)
            {
                this.tree = tree;
                listForTree = new List<T>();
                BypassTree(tree.root);
                iterator = -1;
            }

            /// <summary>
            /// Обходит дерево и добавляет элементы в список в порядке возрастания
            /// </summary>
            private void BypassTree(TreeElement current)
            {
                if (current == null)
                {
                    return;
                }

                if (current.LeftChild != null)
                {
                    BypassTree(current.LeftChild);
                }

                listForTree.Add(current.Value);

                if (current.RightChild != null)
                {
                    BypassTree(current.RightChild);
                }
            }

            /// <summary>
            /// Получает текущий элемент в коллекции
            /// </summary>
            public object Current
            {
                get { return Current; }
            }

            /// <summary>
            /// Получает элемент коллекции, соответствующий текущей позиции перечислителя
            /// </summary>
            T IEnumerator<T>.Current
            {
                get { return listForTree[iterator]; }
            }

            /// <summary>
            /// Устанавливает перечислитель в его начальное положение, т.е. перед первым элементом коллекции
            /// </summary>
            public void Reset()
            {
                iterator = -1;
            }

            /// <summary>
            /// Перемещает перечислитель к следующему элементу коллекции
            /// </summary>
            public bool MoveNext()
            {
                if (iterator < listForTree.Count - 1)
                {
                    iterator++;
                    return true;
                }

                return false;
            }

            public void Dispose()
            {
            }
        }
    }
}

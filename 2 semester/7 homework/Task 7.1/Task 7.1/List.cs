using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_7._1
{
    /// <summary>
    /// Представляет строго типизированный список объектов, доступных по индексу
    /// </summary>
    public class List<T> : IEnumerable<T>
    {
        class ListElement
        {
            public ListElement Next { get; set; }
            public ListElement Previous { get; set; }
            public T Value { get; set; }

            public ListElement(T value)
            {
                Value = value;
            }
        }

        private ListElement head;
        private ListElement tail;
        private int size;

        /// <summary>
        /// Получает число элементов, содержащихся в коллекции List<typeparamref name="&lt;T&gt;"/>
        /// </summary>
        public int Count
        {
            get { return size; }
        }

        /// <summary>
        /// Получает или задает элемент с указанным индексом
        /// </summary>
        public T this[int index]
        {
            get { return FindElementByIndex(index).Value; }
            set { FindElementByIndex(index).Value = value; }
        }

        /// <summary>
        /// Исключение, которое выбрасывается, при передаче указателя null
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        private void CheckArgumentNullException(Predicate<T> match)
        {
            if (match == null)
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// Исключение, которое выбрасывается, когда значение аргумента находится вне допустимого диапазона значений
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private void CheckArgumentOutOfRangeException(int index)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Добавляет объект в конец коллекции List<typeparamref name="&lt;T&gt;"/>
        /// </summary>
        public void Add(T value)
        {
            var newElement = new ListElement(value);
            newElement.Previous = tail;

            if (Count > 0)
            {
                tail.Next = newElement;
            }
            else
            {
                head = newElement;
            }

            tail = newElement;
            size++;
        }

        /// <summary>
        /// Удаляет все элементы из коллекции List<typeparamref name="&lt;T&gt;"/>
        /// </summary>
        public void Clear()
        {
            head = null;
            tail = null;
            size = 0;
        }

        /// <summary>
        /// Определяет, входит ли элемент в состав List<typeparamref name="&lt;T&gt;"/>
        /// </summary>
        public bool Contains(T value)
        {
            return IndexOf(value) != -1;
        }

        /// <summary>
        /// Копирует List<typeparamref name="&lt;T&gt;"/> целиком в совместимый одномерный массив, 
        /// начиная с указанного индекса конечного массива
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (array.Length - arrayIndex < size)
            {
                throw new ArgumentException();
            }

            Array.Copy(this.ToArray(), 0, array, arrayIndex, Count);
        }

        /// <summary>
        /// Определяет, содержит ли List<typeparamref name="&lt;T&gt;"/> элементы, удовлетворяющие условиям указанного предиката
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        public bool Exists(Predicate<T> match)
        {
            return FindIndex(match) != -1;
        }

        /// <summary>
        /// Выполняет поиск элемента, удовлетворяющего условиям указанного предиката, 
        /// и возвращает первое найденное вхождение в пределах всего списка List<typeparamref name="&lt;T&gt;"/>
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public T Find(Predicate<T> match)
        {
            bool isFind = true;
            T result = TryFind(match, ref isFind);

            if (isFind)
            {
                return result;
            }

            throw new Exception("Элемент не найден");
        }

        /// <summary>
        /// Извлекает все элементы, удовлетворяющие условиям указанного предиката
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        public List<T> FindAll(Predicate<T> match)
        {
            CheckArgumentNullException(match);

            List<T> list = new List<T>();

            foreach (var value in this)
            {
                if (match(value))
                {
                    list.Add(value);
                }
            }

            return list;
        }

        /// <summary>
        /// Выполняет поиск элемента, удовлетворяющего условиям указанного предиката, и возвращает отсчитываемый от нуля 
        /// индекс первого найденного вхождения в пределах всего списка List<typeparamref name="&lt;T&gt;"/>
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        public int FindIndex(Predicate<T> match)
        {
            CheckArgumentNullException(match);

            int count = 0;

            foreach (var value in this)
            {
                if (match(value))
                {
                    return count;
                }

                count++;
            }

            return -1; // Если не найден элемент, удовлетворяющий условиям предиката match, возвращает -1
        }

        /// <summary>
        /// Выполняет поиск элемента по индексу в коллекции List<typeparamref name="&lt;T&gt;"/>
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private ListElement FindElementByIndex(int index) // этот метод нужен только самому классу List<T>
        {
            CheckArgumentOutOfRangeException(index);

            var current = head;

            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            return current;
        }

        /// <summary>
        /// Осуществляет поиск указанного объекта и возвращает отсчитываемый от нуля индекс первого вхождения,
        /// найденного в пределах всего списка List<typeparamref name="&lt;T&gt;"/>
        /// </summary>
        public int IndexOf(T value)
        {
            var current = head;
            int count = 0;

            while (current != null)
            {
                if (Equals(current.Value, value))
                {
                    return count;
                }

                count++;
                current = current.Next;
            }

            return -1;  // Если элемент не найден, возвращает -1
        }

        /// <summary>
        /// Добавляет объект в начало коллекции List<typeparamref name="&lt;T&gt;"/>
        /// </summary>
        private void InsertToHead(T value)  // данный метод нужен только самому классу List<T>
        {
            var newElement = new ListElement(value);
            newElement.Next = head;

            if (Count > 0)
            {
                head.Previous = newElement;
            }
            else
            {
                tail = newElement;
            }

            head = newElement;
            size++;
        }

        /// <summary>
        /// Добавляет элемент в список List<typeparamref name="&lt;T&gt;"/> в позиции с указанным индексом
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void Insert(int index, T value)
        {
            CheckArgumentOutOfRangeException(index);

            if (index == 0)
            {
                InsertToHead(value);
                return;
            }

            if (index == Count)
            {
                Add(value);
                return;
            }

            var newElement = new ListElement(value);
            var current = head;

            while (index != 0)
            {
                current = current.Next;
                index--;
            }

            newElement.Next = current;
            newElement.Previous = current.Previous;
            current.Previous.Next = newElement;
            current.Previous = newElement;
            size++;
        }

        /// <summary>
        /// Изменяет порядок элементов во всем списке List<typeparamref name="&lt;T&gt;"/> на обратный
        /// </summary>
        public void Reverse()
        {
            List<T> list = new List<T>();

            foreach (var value in this)
            {
                list.Insert(0, value);
            }

            head = list.head;
            tail = list.tail;
        }

        /// <summary>
        /// Удаляет первое вхождение указанного объекта из коллекции List<typeparamref name="&lt;T&gt;"/>
        /// </summary>
        public bool Remove(T value)
        {
            int index = IndexOf(value);

            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Удаляет элемент списка List<typeparamref name="&lt;T&gt;"/> с указанным индексом
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void RemoveAt(int index)
        {
            CheckArgumentOutOfRangeException(index);

            size--;

            if (index == 0)
            {
                head = head.Next;
                return;
            }

            if (index == Count)
            {
                tail.Previous.Next = null;
                tail = tail.Previous;
                return;
            }

            var current = head;

            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            current.Previous.Next = current.Next;
            current.Next.Previous = current.Previous;
        }
        
        /// <summary>
        /// Копирует элементы списка List<typeparamref name="&lt;T&gt;"/> в новый массив
        /// </summary>
        public T[] ToArray()
        {
            T[] array = new T[Count];
            int i = 0;

            foreach (var value in this)
            {
                array[i] = value;
                i++;
            }

            return array;
        } 

        /// <summary>
        /// Возвращает строку, состоящую из всех элементов списка
        /// </summary>
        public override string ToString()
        {
            string result = String.Empty;

            foreach (var value in this)
            {
                result += value + " ";
            }

            return result;
        }

        /// <summary>
        /// Определяет, все ли элементы списка List<typeparamref name="&lt;T&gt;"/> удовлетворяют условиям указанного предиката
        /// </summary>
        public bool TrueForAll(Predicate<T> match)
        {
            CheckArgumentNullException(match);

            foreach (var value in this)
            {
                if (!match(value))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Возвращает первый элемент списка List<typeparamref name="&lt;T&gt;"/>, 
        /// который удовлетворяет условиям указанного предиката. 
        /// Также принимает логический параметр, куда сообщает успешность поиска
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        public T TryFind(Predicate<T> match, ref bool isFind)
        {
            CheckArgumentNullException(match);

            foreach (var value in this)
            {
                if (match(value))
                {
                    isFind = true;
                    return value;
                }
            }

            isFind = false;
            return default(T);
        }

        /// <summary>
        /// Возвращает перечислитель, выполняющий перебор элементов коллекции
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            return new ListEnumerator(this);
        }

        /// <summary>
        /// Возвращает перечислитель, осуществляющий перебор коллекции
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Реализует простой перебор элементов универсальной коллекции
        /// </summary>
        private class ListEnumerator : IEnumerator<T>
        {
            private int iterator; // перечислитель
            private List<T> list;
            private ListElement current;

            public ListEnumerator(List<T> list)
            {
                this.list = list;
            }

            /// <summary>
            /// Получает текущий элемент в коллекции
            /// </summary>
            public object Current
            {
                get { return current; }
            }

            /// <summary>
            /// Получает элемент коллекции, соответствующий текущей позиции перечислителя
            /// </summary>
            T IEnumerator<T>.Current
            {
                get { return current.Value; }
            }

            /// <summary>
            /// Устанавливает перечислитель в его начальное положение, т.е. перед первым элементом коллекции
            /// </summary>
            public void Reset()
            {
                iterator = 0;
            }

            /// <summary>
            /// Перемещает перечислитель к следующему элементу коллекции
            /// </summary>
            public bool MoveNext()
            {
                if (iterator < list.Count)
                {
                    if (iterator == 0)
                    {
                        current = list.head;
                    }
                    else
                    {
                        current = current.Next;
                    }

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

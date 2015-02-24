using System;

namespace Task_2._3
{
    class List
    {
        class ListElement
        {
            public ListElement pNext { get; private set; }
            public string word { get; private set; }
            public int counter { get; set; } // переменная счетчик. Записываем, сколько раз встретилось нам данное слово

            public ListElement(string word, ListElement pNext)
            {
                this.pNext = pNext;
                this.word = word;
                this.counter = 0;
            }
        }

        private ListElement head;
        private int size; 

        public List()
        {
            this.head = null;
            this.size = 0;
        }

        // Добавление элемента
        public void AddListElement(string word)
        {
            ListElement current = this.head;
            ListElement newElement = new ListElement(word, this.head);

            while ((current != null) && (current.word != word)) // пока не конец списка и нашего слова не было...
            {
                current = current.pNext;
            }

            if (current == null) // если current == null, это означает, что слово имеет такой же ключ, как и другое слово, которое лежит уже в этом списке, или список еще пуст
            {
                this.head = newElement;
                this.head.counter++;
                this.size++;
            }
            else
            {
                current.counter++; // current != null, т.е. мы нашли слово в списке, которое ранее встречалось в тексте. Тогда просто увеличиваем счетчик
            }
        }

        // Количество элементов в списке
        public int Count()
        {
            return this.size;
        }

        // Сколько раз встретилось слово, которое сейчас находится в голове списка
        public int NumberOfWords()
        {
            return this.head.counter;
        }

        // Удаление элемента
        public string DeleteListElement()
        {
            string word = this.head.word;
            this.head = this.head.pNext;
            this.size--;
            return word;
        }
    }
}

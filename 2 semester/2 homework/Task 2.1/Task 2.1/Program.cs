using System;

namespace Task_2._1
{
    class Program
    {
        static void Main()
        {
            Stack stack = new Stack();
            bool isWorking = true;
            PrintOut();

            while (isWorking)
            {
                int choice = Int32.Parse(Console.ReadLine());
                switch (choice)
                {
                    case (0):
                    {
                        isWorking = false;
                        break;
                    }

                    case (1):
                    {
                        Console.Write("Введите ваше число: ");
                        int value = Int32.Parse(Console.ReadLine());
                        stack.Push(value);
                        Console.WriteLine("Новый элемент добавлен");
                        break;
                    }

                    case (2):
                    {
                        stack.Pop();
                        break;
                    }

                    case (3):
                    {
                        stack.PrintStack();
                        break;
                    }

                    case (4):
                    {
                        if (stack.IsEmpty())
                        {
                            Console.WriteLine("Стек пуст");
                        }
                        else
                        {
                            Console.WriteLine("Верхний элемент: {0}", stack.Top());
                        }
                        
                        break;
                    }

                    case(5):
                    {
                        Console.WriteLine("Размер: {0}", stack.Size());
                        break;
                    }

                    default:
                    {
                        Console.WriteLine("Некорректный ввод");
                        break;
                    }
                }

                if (isWorking)
                {
                    PrintOut();
                }
                else
                {
                    Console.WriteLine("Вы завершили работу");
                }
            }
        }

        static void PrintOut()
        {
            Console.WriteLine("\nВведите команду:\n0 - выйти\n1 - добавить новый элемент в стек\n2 - удалить последний элемент из стека\n3 - распечатать стек\n4 - возвратить значение самого верхнего элемента\n5 - размер стека");
        }
    }
}

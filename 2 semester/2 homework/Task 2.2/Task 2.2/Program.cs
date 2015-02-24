using System;

namespace Task_2._2
{
    class Program
    {
        static void Main()
        {
            List list = new List();
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
                        list.AddListElement(value);
                        break;
                    }

                    case (2):
                    {
                        Console.Write("Введите ваше число: ");
                        int value = Int32.Parse(Console.ReadLine());
                        list.RemoveListElement(value);
                        break;
                    }

                    case (3):
                    {
                        list.PrintList();
                        break;
                    }

                    case (4):
                    {
                        Console.Write("Введите ваше число: ");
                        int value = Int32.Parse(Console.ReadLine());

                        if (list.Contains(value))
                        {
                            Console.WriteLine("Входит в список");
                        }
                        else
                        {
                            Console.WriteLine("Не входит в список");
                        }

                        break;
                    }

                    case (5):
                    {
                        Console.WriteLine("Размер: {0}", list.Count());
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
            Console.WriteLine("\nВведите команду:\n0 - выйти\n1 - добавить значение в список\n2 - удалить значение из списка\n3 - распечатать список\n4 - содержится ли элемент в списке\n5 - размер списка\n");
        }
    }
}

using LibraryForLabs;
using System;

namespace Лабораторная_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string choice = null;
            DoublyLinkedList<Cars> list = null;
            
            PrintMenu();

            while (choice != "7")
            {
                Console.Write("Ваш выбор: ");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        try
                        {
                            Console.Write("Введите длину списка: ");
                            int length = int.Parse(Console.ReadLine());
                            list = new DoublyLinkedList<Cars>(length);
                            Console.WriteLine("Список сформирован");
                        }
                        catch
                        {
                            Console.WriteLine("Вы неправильно ввели длину списка.");
                        }
                        break;
                    case "2":
                        if (list != null)
                        {
                            list.AddOddItems();
                            Console.WriteLine("Элементы добавлены");
                        }
                        else
                            Console.WriteLine("Сначала сформируйте список.");
                        break;
                    case "3":
                        try
                        {
                            Cars carForDelete = new Cars();
                            carForDelete.Init();
                            if (list != null && list.DeleteAfterFound(carForDelete))
                                Console.WriteLine("Элементы удалены!");
                            else
                                Console.WriteLine("\nЭлемент с таким полем не найден!\n");
                        }
                        catch
                        {
                            Console.WriteLine("Сначала сформируйте список.");
                        }
                        break;
                    case "4":
                        try
                        {
                            Console.WriteLine();
                            Console.WriteLine("Оригинал:\n");
                            list.PrintList();
                            Console.WriteLine();
                            Console.WriteLine("Копия:\n");
                            DoublyLinkedList<Cars> listCopy = list.MakeDeepCopy(list);
                            listCopy.PrintList();
                        }
                        catch
                        {
                            Console.WriteLine("Сначала сформируйте список.");
                        }
                        break;
                    case "5":
                        try
                        {
                            list.DeleteList();
                            Console.WriteLine("Список удален");
                        }
                        catch
                        {
                            Console.WriteLine("Сначала сформируйте список.");
                        }
                        break;
                    case "6":
                        if (list == null)
                        {
                            Console.WriteLine("Сначала сформируйте список.");
                            break;
                        }
                        list.PrintList();
                        break;
                    default:
                        Console.WriteLine("Некорректный выбор. Попробуйте снова.");
                        break;
                }
            }
        }

        public static void PrintMenu()
        {
            Console.WriteLine("\n\t\t|||Меню|||\n");
            Console.WriteLine("1. Сформировать список\n" +
                "2. Добавить в список элементы с номерами 1, 3, 5 и т.д. \n" +
                "3. Удалить из списка все элементы, начиная с элемента с заданным информационным полем\n" +
                "4. Сделать глубокую копию списка\n" +
                "5. Удалить список из памяти\n" +
                "6. Распечатать список\n" +
                "7. Выход");
        }
    }
}

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
                        list = new DoublyLinkedList<Cars>(5);
                        Console.WriteLine("Список сформирован");
                        break;
                    case "2":
                        try
                        {
                            list.AddToOddIndex();
                            Console.WriteLine("Элементы добавлены");
                        }
                        catch
                        {
                            Console.WriteLine("Сначала сформируйте список.");
                        }
                        break;
                    case "3":
                        try
                        {
                            list.RemoveAfterFound(new Cars("Nissan", 2023, "Black", 777777, 25));
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

            //Console.WriteLine("\n\t\t|||Изначальный список|||\n");
            //DoublyLinkedList<Cars> list = new DoublyLinkedList<Cars>(5);
            //list.PrintList();
            //Console.WriteLine("\n\t\t|||После добавления|||\n");
            //list.AddToOddIndex();
            //list.PrintList();
            //Console.WriteLine("\n\t\t|||После удаления элементов|||\n");
            //Cars car = new Cars("Nissan", 2023, "Black", 777777, 25);
            //list.RemoveAfterFound(car);
            //list.PrintList();

            //Console.WriteLine("\n\t\t|||Оригинал и копия списка|||\n");
            //Клонирование глубокое
            //DoublyLinkedList<Cars> listOriginal = new DoublyLinkedList<Cars>(4);
            //listOriginal.PrintList();
            //Console.WriteLine();
            //DoublyLinkedList<Cars> listCopy = listOriginal.MakeDeepCopy(listOriginal);
            //listCopy.PrintList();
            //Console.WriteLine();
            ////Удаление
            //Console.WriteLine("\n\t\t|||Удаление списка из памяти|||\n");
            //list.DeleteList();
            //list.PrintList();
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

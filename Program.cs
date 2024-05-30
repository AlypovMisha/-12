using LibraryForLabs;
using System;

namespace Лабораторная_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            




            //Console.ReadLine();
            PrintMenu();
            ChoiceDataStructure();
        }

        public static void PrintMenuForLinkedList()
        {
            Console.WriteLine("\n\t\t|||Связанный список|||\n");
            Console.WriteLine("1. Сформировать список\n" +
                "2. Добавить в список элементы с номерами 1, 3, 5 и т.д. \n" +
                "3. Удалить из списка все элементы, начиная с элемента с заданным информационным полем\n" +
                "4. Сделать глубокую копию списка\n" +
                "5. Удалить список из памяти\n" +
                "6. Распечатать список\n" +
                "7. Выход");
        }

        public static void PrintMenuForHashTable()
        {
            Console.WriteLine("\n\t\t|||Хеш-таблица|||\n");
            Console.WriteLine("" +
                "1. Сформировать хеш-таблицу\n" +
                "2. Найти элемент в хеш-таблице\n" +
                "3. Удалить элемент из хеш-таблицы\n" +
                "4. Добавить элемент\n" +
                "5. Удалить хеш-таблицу\n" +
                "6. Распечатать хеш-таблицы\n" +
                "7. Выход");
        }

        public static void PrintMenuForTree()
        {
            Console.WriteLine("\n\t\t|||Дерево|||\n");
            Console.WriteLine("1. Сформировать дерево\n" +
                "2. Найти максимальный элемент в дереве (с максимальной ценой) \n" +
                "3. Удалить элемент из дерева \n" +
                "4. Добавить элемент в дерево\n" +
                "5. Преобразовать идеально сбалансированное дерево в дерево поиска\n" +
                "6. Удалить дерево из памяти\n" +
                "7. Распечатать дерево\n" +
                "8. Выход");
        }

        public static void PrintMenuForAnotherHashTable()
        {
            Console.WriteLine("\n\t\t|||Ещё одна хэш-таблица|||\n");
            Console.WriteLine("1. Сформировать хэш-таблицу\n" +
                "2. Найти элемент в хэш-таблице \n" +
                "3. Удалить элемент в хэш-таблице\n" +
                "4. Добавить элемент в хэш-таблицу\n" +
                "5. Удалить хэш-таблицу из памяти\n" +
                "6. Распечатать хэш-таблицы (если есть копии)\n" +
                "7. Сделать поверхностную копию\n" +
                "8. Сделать глубокую копию\n" +
                "9. Найти количество желтых автомобилей в хэш-таблице (демонстрация foreach)\n" +
                "10. Выход");
        }

        public static void PrintMenu()
        {
            Console.WriteLine("\n\t\t|||Меню|||\n");
            Console.WriteLine(
                "1. Работа с связанным списком\n" +
                "2. Работа с хэш-таблицей\n" +
                "3. Работа с деревом\n" +
                "4. Работа с ещё одной хэш-таблицей\n" +
                "5. Выход\n");
        }

        public static void ChoiceForLinkedList()
        {
            string choice = null;
            DoublyLinkedList<Cars> list = null;
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
                        if (list != null)
                        {
                            Cars carForDelete = new Cars();
                            carForDelete.Init();
                            if (list != null && list.DeleteAfterFound(carForDelete))
                                Console.WriteLine("Элементы удалены!");
                            else
                                Console.WriteLine("\nЭлемент с таким полем не найден!\n");
                        }
                        else
                        {
                            Console.WriteLine("Сначала сформируйте список.");
                        }
                        break;
                    case "4":
                        if (list != null)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Оригинал:\n");
                            list.PrintList();
                            Console.WriteLine();
                            Console.WriteLine("Копия:\n");
                            DoublyLinkedList<Cars> listCopy = list.MakeDeepCopy();
                            listCopy.PrintList();
                        }
                        else
                        {
                            Console.WriteLine("Сначала сформируйте список.");
                        }
                        break;
                    case "5":
                        if (list != null)
                        {
                            list.DeleteList();
                            Console.WriteLine("Список удален");
                        }
                        else
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
                    case "7":
                        PrintMenu();
                        break;
                    default:
                        Console.WriteLine("Некорректный выбор. Попробуйте снова.");
                        break;
                }
            }
        }

        public static void ChoiceForHashTable()
        {
            string choice = null;
            HashTable<Cars> hashTable = null;
            while (choice != "7")
            {
                Console.Write("Ваш выбор: ");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        try
                        {
                            Console.Write("Введите количество ячеек: ");
                            int length = int.Parse(Console.ReadLine());
                            hashTable = new HashTable<Cars>(length);
                            Console.Write("Введите элементов, которых хотите создать: ");
                            int countOfElements = int.Parse(Console.ReadLine());                    
                            for (int i = 0; i < countOfElements; i++)
                            {
                                Cars car = new Cars();
                                car.RandomInit();
                                hashTable.Add(car);
                            }
                            Console.WriteLine("Хеш-таблица сформирована");
                        }
                        catch
                        {
                            Console.WriteLine("Вы неправильно ввели данные о хеш-таблице.");
                        }
                        break;
                    case "2":
                        if (hashTable != null)
                        {
                            Cars carForSearch = new Cars();
                            Console.WriteLine("Введите экземпляр, который хотите найти");
                            carForSearch.Init();
                            Node<Cars> node = hashTable.SearchItem(carForSearch);
                            if (node != null)
                                Console.WriteLine($"Экземпляр найден. {node}");
                            else
                                Console.WriteLine("Экземпляр не найден");
                        }
                        else
                        {
                            Console.WriteLine("Сначала сформируйте хеш-таблицу.");
                        }
                        break;
                    case "3":
                        if (hashTable != null)
                        {
                            Cars carForDelete = new Cars();
                            Console.WriteLine("Введите экземпляр, который хотите удалить");
                            carForDelete.Init();
                            if (hashTable.RemoveElement(carForDelete))
                                Console.WriteLine("Экземпляр удален");
                            else
                                Console.WriteLine("Экземпляр не найден");
                        }
                        else
                        {
                            Console.WriteLine("Сначала сформируйте хеш-таблицу.");
                        }
                        break;
                    case "4":
                        if (hashTable != null)
                        {
                            Cars carForAdd = new Cars();
                            Console.WriteLine("Введите экземпляр, который хотите добавить");
                            carForAdd.Init();
                            hashTable.Add(carForAdd);
                            Console.WriteLine("Экземпляр добавлен");
                        }
                        else
                        {
                            Console.WriteLine("Сначала сформируйте хеш-таблицу.");
                        }
                        break;
                    case "5":
                        if (hashTable != null)
                        {
                            hashTable.DeleteHashTable();
                            hashTable = null;
                            Console.WriteLine("Хеш-таблица удалена");
                        }
                        else
                        {
                            Console.WriteLine("Сначала сформируйте хеш-таблицу.");
                        }
                        break;
                    case "6":
                        if (hashTable != null)
                        {
                            hashTable.PrintTable();
                        }
                        else
                        {
                            Console.WriteLine("Сначала сформируйте хеш-таблицу.");
                        }
                        break;
                    case "7":
                        PrintMenu();
                        break;
                    default:
                        Console.WriteLine("Некорректный выбор. Попробуйте снова.");
                        break;
                }
            }
        }

        public static void ChoiceForTree()
        {
            string choice = null;
            Tree<Cars> tree = null;
            Tree<Cars> treeBST = null;
            while (choice != "8")
            {
                Console.Write("Ваш выбор: ");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        try
                        {
                            Console.Write("Введите количество элементов в дереве: ");
                            int length = int.Parse(Console.ReadLine());
                            tree = new Tree<Cars>(length);
                            Console.WriteLine("Дерево сформировано");
                        }
                        catch
                        {
                            Console.WriteLine("Вы неправильно ввели количество ячеек.");
                        }
                        break;
                    case "2":
                        if (tree != null)
                        {
                            tree.FindMax(tree.Root);
                        }
                        else
                            Console.WriteLine("Сначала сформируйте дерево");
                        break;
                    case "3":
                        if (tree != null)
                        {
                            int tc = tree.Count;
                            Cars car = new Cars();
                            car.Init();
                            tree.Remove(car);
                            if (tc > tree.Count)
                                Console.WriteLine("Элемент удален");
                            else
                                Console.WriteLine("Элемент не найден");
                        }
                        else
                            Console.WriteLine("Сначала сформируйте дерево");
                        break;
                    case "4":
                        if (tree != null)
                        {
                            Cars car = new Cars();
                            car.Init();
                            tree.AddPoint(car);
                            Console.WriteLine("Элемент добавлен");
                        }
                        else
                            Console.WriteLine("Сначала сформируйте дерево");
                        break;
                    case "5":
                        if (tree != null)
                        {
                            treeBST = new Tree<Cars>();
                            tree.MadeFromTreeToFindTree(treeBST);
                            Console.WriteLine("Дерево преобразовано");
                        }
                        else
                            Console.WriteLine("В дереве не было элементов");
                        break;
                    case "6":
                        if (tree != null)
                        {
                            tree.Clear();
                            Console.WriteLine("Дерево удалено");
                        }
                        else
                            Console.WriteLine("В дереве не было элементов");
                        break;
                    case "7":
                        if (tree != null && tree.Root != null)
                        {
                            Console.WriteLine("\n\t\t|||Сбалансированное дерево|||\n");
                            tree.ShowTree();
                            if (treeBST != null)
                            {
                                Console.WriteLine("\n\t\t|||Бинарное дерево поиска|||\n");
                                treeBST.ShowTree();
                            }
                        }
                        else
                            Console.WriteLine("В дереве нет элементов");
                        break;
                    case "8":
                        PrintMenu();
                        break;
                    default:
                        Console.WriteLine("Некорректный выбор. Попробуйте снова.");
                        break;
                }
            }
        }

        public static void ChoiceForAnotherHashTable()
        {
            string choice = null;
            SuperHashTable<Cars> hashTable = null;
            SuperHashTable<Cars> hashTableForSurfaceCopy = null;
            SuperHashTable<Cars> hashTableForDeepCopy = null;
            while (choice != "10")
            {
                Console.Write("Ваш выбор: ");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        try
                        {
                            Console.Write("Введите количество ячеек: ");
                            int length = int.Parse(Console.ReadLine());
                            hashTable = new SuperHashTable<Cars>(length);
                            Console.Write("Введите элементов, которых хотите создать: ");
                            int countOfElements = int.Parse(Console.ReadLine());
                            for (int i = 0; i < countOfElements; i++)
                            {
                                Cars car = new Cars();
                                car.RandomInit();
                                hashTable.Add(car);
                            }
                            Console.WriteLine("Хеш-таблица сформирована");
                        }
                        catch
                        {
                            Console.WriteLine("Вы неправильно ввели данные о хеш-таблице.");
                        }
                        break;
                    case "2":
                        if (hashTable != null)
                        {
                            Cars carForSearch = new Cars();
                            Console.WriteLine("Введите экземпляр, который хотите найти");
                            carForSearch.Init();
                            Node<Cars> node = hashTable.SearchItem(carForSearch);
                            if (node != null)
                                Console.WriteLine($"Экземпляр найден. {node}");
                            else
                                Console.WriteLine("Экземпляр не найден");
                        }
                        else
                        {
                            Console.WriteLine("Сначала сформируйте хеш-таблицу.");
                        }
                        break;
                    case "3":
                        if (hashTable != null)
                        {
                            Cars carForDelete = new Cars();
                            Console.WriteLine("Введите экземпляр, который хотите удалить");
                            carForDelete.Init();
                            if (hashTable.Remove(carForDelete))
                                Console.WriteLine("Экземпляр удален");
                            else
                                Console.WriteLine("Экземпляр не найден");
                        }
                        else
                        {
                            Console.WriteLine("Сначала сформируйте хеш-таблицу.");
                        }
                        break;
                    case "4":
                        if (hashTable != null)
                        {
                            Cars carForAdd = new Cars();
                            Console.WriteLine("Введите экземпляр, который хотите добавить");
                            carForAdd.Init();
                            hashTable.Add(carForAdd);
                            Console.WriteLine("Экземпляр добавлен");
                        }
                        else
                        {
                            Console.WriteLine("Сначала сформируйте хеш-таблицу.");
                        }
                        break;
                    case "5":
                        hashTable.DeleteSuperHashTable();
                        hashTable = null;
                        Console.WriteLine("Хеш-таблица удалена");
                        break;
                    case "6":
                        if (hashTable != null)
                        {
                            hashTable.PrintTable();
                            Console.WriteLine();
                            if (hashTableForSurfaceCopy != null)
                            {
                                hashTableForSurfaceCopy.PrintTable(); Console.WriteLine("Поверхностная копия");
                            }
                            Console.WriteLine();

                            if (hashTableForDeepCopy != null)
                            {
                                Console.WriteLine("Глубокая копия");
                                hashTableForDeepCopy.PrintTable();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Сначала сформируйте хеш-таблицу.");
                        }
                        break;
                    case "7":
                        if (hashTable != null)
                        {
                            hashTableForSurfaceCopy = hashTable.MakeSurfaceCopy();
                            Console.WriteLine("Поверхностная копия сделана");
                        }
                        else
                        {
                            Console.WriteLine("Сначала сформируйте хеш-таблицу.");
                        }
                        break;
                    case "8":
                        if (hashTable != null)
                        {
                            hashTableForDeepCopy = new SuperHashTable<Cars>(hashTable);
                            Console.WriteLine("Глубокая копия сделана");
                        }
                        else
                        {
                            Console.WriteLine("Сначала сформируйте хеш-таблицу.");
                        }
                        break;
                    case "9":
                        if (hashTable != null)
                        {
                            int countOfYellowCars = 0;
                            foreach (var item in hashTable)
                            {
                                if(item.Color == "Yellow")
                                    countOfYellowCars++;
                            }
                            Console.WriteLine($"В хеш-таблице {countOfYellowCars} желтых автомобилей");
                        }
                        else
                        {
                            Console.WriteLine("Сначала сформируйте хеш-таблицу.");
                        }
                        break;
                    case "10":
                        PrintMenu();
                        break;
                    default:
                        Console.WriteLine("Некорректный выбор. Попробуйте снова.");
                        break;
                }
            }
        }

        public static void ChoiceDataStructure()
        {
            string choice = null;
            while (choice != "5")
            {
                Console.Write("Ваш выбор: ");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        PrintMenuForLinkedList();
                        ChoiceForLinkedList();
                        break;
                    case "2":
                        PrintMenuForHashTable();
                        ChoiceForHashTable();
                        break;
                    case "3":
                        PrintMenuForTree();
                        ChoiceForTree();
                        break;
                    case "4":
                        PrintMenuForAnotherHashTable();
                        ChoiceForAnotherHashTable();
                        break;
                    default:
                        Console.WriteLine("Некорректный выбор. Попробуйте снова.");
                        break;
                }
            }
        }
    }
}


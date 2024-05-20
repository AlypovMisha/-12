using LibraryForLabs;
using System;

namespace Лабораторная_12
{
    public class HashTable<T> where T : IInit, ICloneable, new()
    {
        private Node<T>[] table;

        private int count;

        private int size;

        public int Count => count;

        public int Size
        {
            get { return size; }
            set
            {
                if (value > 0)
                    size = value;
                else
                    size = 1;
            }
        }

        public HashTable(int size)
        {
            Size = size;
            table = new Node<T>[Size];
        }

        public void PrintTable()
        {
            if (table != null)
            {
                for (int i = 0; i < table.Length; i++)
                {
                    if (table[i] != null)
                    {
                        Console.WriteLine($"{i}: {table[i]}");
                        if (table[i].Next != null)
                        {
                            Node<T> current = table[i].Next;
                            while (current != null)
                            {
                                Console.WriteLine($"   {current.Data}");
                                current = current.Next;
                            }
                        }
                    }
                    else { Console.WriteLine($"{i}: Нет элемента"); }
                }
            }
            else
            {
                throw new Exception("Таблица удалена");
            }
        }

        public void Add(T data)
        {
            int index = GetHash(data);
            //позиция пустая
            if (table[index] == null)
            {
                table[index] = new Node<T>(data);
                table[index].Data = data;
                count++;
            }
            else //есть цепочка
            {
                Node<T> current = table[index];
                if (current.Data.Equals(data))
                    return;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = new Node<T>(data);
                current.Next.Prev = current;
                count++;
            }
        }

        public Node<T> SearchItem(T itemForSearch)
        {
            int k = GetHash(itemForSearch);
            if (table[k] == null)
                return default;
            else
            {
                while (true)
                {
                    if (table[k].Data.Equals(itemForSearch))
                        return table[k];
                    table[k] = table[k].Next;
                    if (table[k] == null)
                        return default;
                }
            }
        }

        public bool RemoveElement(T data)
        {
            int index = GetHash(data);
            if (table[index] == null)
                return false;
            if (table[index].Data.Equals(data))
            {
                if (table[index].Next == null)
                {
                    table[index] = null;
                }
                else
                {
                    table[index] = table[index].Next;
                    table[index].Prev = null;
                }
                count--;
                return true;
            }
            Node<T> current = table[index];
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    Node<T> pred = current.Prev;
                    Node<T> next = current.Next;
                    pred.Next = next;
                    if (next != null)
                        next.Prev = pred;
                    current.Prev = null;
                    count--;
                    return true;
                }
                current = current.Next;
            }
            return false;
        }


        public bool Contains(T data)
        {
            int index = GetHash(data);
            if (table == null)
                throw new Exception("empty table");
            if (table[index] == null) //цепочка пустая, элемента
                return false;
            if (table[index].Data.Equals(data)) //попали на нужный
                return true;
            else
            {
                Node<T> current = table[index];//идем по цепочке
                while (current != null)
                {
                    if (current.Data.Equals(data))
                        return true;
                    current = current.Next;
                }
                return false;
            }
        }

        public void DeleteHashTable()
        {
            count = 0;
            table = null;
        }

        private int GetHash(T item)
        {
            return Math.Abs(item.GetHashCode()) % table.Length;
        }
    }
}

using LibraryForLabs;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Лабораторная_12
{
    public class SuperHashTable<T> : IEnumerable<T>, ICollection<T> where T : IInit, ICloneable, new()
    {
        private Node<T>[] table;

        private int count;

        private int size;

        public int Count { get { return count; } private set { } }

        public bool IsReadOnly => false;

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

        public SuperHashTable()
        {
            table = new Node<T>[10];
            size = 10;
        }

        public SuperHashTable(int size)
        {
            Size = size;
            table = new Node<T>[Size];
        }

        public SuperHashTable(SuperHashTable<T> c)
        {
            Size = c.Size;
            count = c.count;
            table = new Node<T>[Size];
            for (int i = 0; i < Size; i++)
            {
                if (c.table[i] != null)
                {
                    table[i] = Clone(c.table[i]);
                }
            }
        }

        private Node<T> Clone(Node<T> node)
        {
            if (node == null) return null;

            Node<T> newNode = new Node<T>((T)node.Data.Clone())
            {
                Next = Clone(node.Next),
                Prev = null
            };

            if (newNode.Next != null)
            {
                newNode.Next.Prev = newNode;
            }

            return newNode;
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
            int index = GetHash(itemForSearch);
            if (table[index] == null)
                return default;
            else
            {
                while (true)
                {
                    if (table[index].Data.Equals(itemForSearch))
                        return table[index];
                    table[index] = table[index].Next;
                    if (table[index] == null)
                        return default;
                }
            }
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

        private int GetHash(T item)
        {
            return Math.Abs(item.GetHashCode()) % table.Length;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var node in table)
            {
                Node<T> current = node;
                while (current != null)
                {
                    yield return current.Data;
                    current = current.Next;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Clear()
        {
            count = 0;
            table = new Node<T>[Size];
        }

        public void DeleteSuperHashTable()
        {
            count = 0;
            table = null;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            foreach (var item in table)
            {
                if (item != null)
                {
                    array[arrayIndex] = item.Data;
                    arrayIndex++;
                }
            }
        }

        public SuperHashTable<T> MakeSurfaceCopy()
        {
            SuperHashTable<T> copy = new SuperHashTable<T>(Size);
            for (int i = 0; i < Size; i++)
            {
                copy.table[i] = table[i];
                if (copy.table[i] != null)
                    copy.count++;
            }
            
            return copy;
        }

        public bool Remove(T data)
        {
            int index = GetHash(data);
            Node<T> current = table[index];

            if (current == null)
                return false;

            // Удаление первого элемента цепочки
            if (current.Data.Equals(data))
            {
                if (current.Next == null)
                {
                    table[index] = null;
                }
                else
                {
                    table[index] = current.Next;
                    table[index].Prev = null;
                }
                count--;
                return true;
            }

            // Поиск и удаление элемента внутри цепочки
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (current.Prev != null)
                        current.Prev.Next = current.Next;
                    if (current.Next != null)
                        current.Next.Prev = current.Prev;

                    count--;
                    return true;
                }
                current = current.Next;
            }

            return false;
        }
    }
}

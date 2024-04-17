using LibraryForLabs;
using System;

namespace Лабораторная_12
{
    public class DoublyLinkedList<T> where T : IInit, ICloneable, new()
    {
        private Node<T> beginning = new Node<T>();
        private Node<T> end = new Node<T>();
        private Node<T> node = new Node<T>();
        private int count;
        public int Count => count;

        //Конструкторы
        public DoublyLinkedList()
        {
            beginning = null;
            end = null;
            count = 0;
        }

        public DoublyLinkedList(int size)
        {
            if (size <= 0)
                throw new ArgumentOutOfRangeException("Size is not less than 1");

            beginning = node.MakeRandomData();
            count++;
            end = beginning;
            for (int i = 1; i < size; i++)
            {
                T newItem = node.MakeRandomItem();
                AddToEnd(newItem);
            }
        }

        public DoublyLinkedList(T[] collection)
        {
            if (collection == null)
                throw new ArgumentNullException("Empty collection: null");
            if (collection.Length == 0)
                throw new ArgumentException("Empty collection");
            T newData = (T)collection.Clone();
            beginning = new Node<T>(newData);
            end = beginning;
            for (int i = 0; i < collection.Length; i++)
            {
                AddToEnd(collection[i]);
            }
        }


        //Добавить в начало 
        public void AddToBeginning(T item)
        {
            T newData = (T)item.Clone();
            Node<T> newItem = new Node<T>(newData);
            count++;
            if (beginning != null)
            {
                beginning.Prev = newItem;
                newItem.Next = beginning;
                beginning = newItem;
            }
            else
            {
                beginning = newItem;
                end = beginning;
            }
        }

        //Добавить в конец 
        public void AddToEnd(T item)
        {
            T newData = (T)item.Clone();
            Node<T> newItem = new Node<T>(newData);
            count++;
            if (end != null)
            {
                end.Next = newItem;
                newItem.Prev = end;
                end = newItem;
            }
            else
            {
                beginning = newItem;
                end = beginning;
            }
        }

        //Распечатать массив
        public void PrintList()
        {
            if (count == 0)
                Console.WriteLine("The list is empty");
            Node<T> current = beginning;
            for (int i = 0; current != null; i++)
            {
                Console.WriteLine($"{i}. {current}");
                current = current.Next;
            }
        }

        //Добавить элементы на нечетные индексы
        public void AddToOddIndex()
        {
            if (count <= 1)
                throw new Exception("There are no elements with odd indexes in the array");
            Node<T> current = beginning;
            for (int i = 0; current != null; i++)
            {
                if (i % 2 != 0 && current.Next != null)
                {
                    Cars car = new Cars("Nissan", 2023, "Black", 777777, 25);
                    T newData = (T)car.Clone();
                    Node<T> newNode = new Node<T>(newData);
                    newNode.Prev = current.Prev;
                    newNode.Next = current;
                    current.Prev.Next = newNode;
                    current.Next.Prev = current;
                    count++;
                }
                else if (i % 2 != 0 && current.Next == null)
                {
                    Cars car = new Cars("Nissan", 2023, "Black", 777777, 25);
                    T newData = (T)car.Clone();
                    Node<T> newNode = new Node<T>(newData);
                    newNode.Next = current;
                    newNode.Prev = current.Prev;
                    current.Prev.Next = newNode;
                    current.Prev = newNode;
                }
                else
                    current = current.Next;
            }
        }

        public void RemoveAfterFound(T item)
        {
            Node<T> current = beginning;
            Node<T> itemForFind = new Node<T>(FindItem(item).Data);
            while (current != null)
            {
                if (count <= 1 && current.Data.Equals(itemForFind.Data))
                {
                    beginning = null;
                    end = null;
                    count = 0;
                    break;
                }
                if (current.Prev == null && current.Data.Equals(itemForFind.Data))
                {
                    current.Next.Prev = null;
                    beginning = current.Next;
                    count--;
                }
                else if (current.Next == null && current.Data.Equals(itemForFind.Data))
                {
                    current.Prev.Next = null;
                    count--;
                }
                else if (current.Data.Equals(itemForFind.Data))
                {
                    current.Prev.Next = current.Next;
                    current.Next.Prev = current.Prev;
                }
                current = current.Next;
            }
        }

        public Node<T> FindItem(T item)
        {
            Node<T> current = beginning;
            while (current != null)
            {
                if (current.Data == null)
                    throw new Exception("Data is null");
                if (current.Data.Equals(item))
                    return current;
                current = current.Next;
            }
            return null;
        }

        public bool RemoveItem(T item)
        {
            if (beginning == null)
                throw new Exception("The empty list");
            Node<T> pos = FindItem(item);
            if (pos == null)
                return false;
            count--;
            //Один элемент
            if (beginning == end)
            {
                beginning = end = null;
                return true;
            }
            //Первый
            if (pos.Prev == null)
            {
                beginning = beginning?.Next;
                beginning.Prev = null;
                return true;
            }
            //Последний
            if (pos.Next == null)
            {
                end = end.Prev;
                end.Next = null;
                return true;
            }
            Node<T> next = pos.Next;
            Node<T> prev = pos.Prev;
            pos.Next.Prev = prev;
            pos.Prev.Next = next;
            return true;
        }


        //Сделать глубокую копию списка
        public DoublyLinkedList<T> MakeDeepCopy(DoublyLinkedList<T> listForCopy)
        {
            DoublyLinkedList<T> newList = new DoublyLinkedList<T>();
            Node<T> currentForCopy = listForCopy.beginning;
            if (listForCopy.Count > 0)
            {
                for (int i = 0; i < listForCopy.Count; i++)
                {
                    newList.AddToEnd(currentForCopy.Data);
                    currentForCopy = currentForCopy.Next;
                }
            }
            return newList;
        }

        //Удаление из памяти        
        public void DeleteList()
        {
            Node<T> current = end;
            while (current.Prev != null)
            {
                current = current.Prev;
                current.Next = null;
            }
            beginning = end = null;
            count = 0;
        }

        public Node<T> ElementAt(int index)
        {
            Node<T> current = beginning;
            if(index <= count)
            {
                for(int i = 0;i < index;i++)
                {
                    current = current.Next;
                }
                return current;
            }
            else { return null; }
        }
    }
}

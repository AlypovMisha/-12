using LibraryForLabs;
using System;

namespace Лабораторная_12
{
    public class Tree<T> where T : IInit, IComparable, new()
    {
        private TreeNode<T> root;

        private int count;

        private int length;

        private bool IsFindTree;

        public TreeNode<T> Root { get { return root; } private set { } }

        public int Count => count;

        public int Length
        {
            get
            {
                return length;
            }
            set
            {
                if (value > 0)
                {
                    length = value;
                }
                else
                {
                    length = 0;
                }
            }
        }

        public Tree()
        {
            count = 0;
            Length = 0;
        }

        public Tree(int length)
        {
            if (length != 0)
            {
                Length = length;
                count = Length;
                root = MakeTree(Length, root);
            }
            else
            {
                count = 0;
                Length = 0;
            }
        }

        public void ShowTree()
        {
            Show(root);
        }

        public TreeNode<T> MakeTree(int length, TreeNode<T> point)
        {
            T data = new T();
            data.RandomInit();
            TreeNode<T> newItem = new TreeNode<T>(data);
            if (length == 0)
            {
                return null;
            }
            int nl = length / 2;
            int nr = length - nl - 1;
            newItem.Left = MakeTree(nl, newItem.Left);
            newItem.Right = MakeTree(nr, newItem.Right);
            return newItem;
        }

        private void Show(TreeNode<T> point, int spaces = 5)
        {
            if (point != null)
            {
                Show(point.Left, spaces + 5);
                for (int i = 0; i < spaces; i++)
                    Console.Write(" ");
                Console.WriteLine(point.Data);
                Show(point.Right, spaces + 5);
            }
        }

        public void AddPoint(T data)
        {
            if (count == 0)
            {
                root = new TreeNode<T>(data);
                count++;
            }
            else
            {
                TreeNode<T> point = root;
                TreeNode<T> current = null;
                bool isExist = false;
                while (point != null && !isExist)
                {
                    current = point;
                    if (point.Data.CompareTo(data) == 0)
                        isExist = true;
                    else if (point.Data.CompareTo(data) < 0)
                    {
                        point = point.Left;
                    }
                    else
                    {
                        point = point.Right;
                    }
                }
                if (isExist)
                    return;
                TreeNode<T> newPoint = new TreeNode<T>(data);
                if (current.Data.CompareTo(data) < 0)
                    current.Left = newPoint;
                else
                    current.Right = newPoint;
                count++;
            }
        }

        private void TransformToArray(TreeNode<T> point, T[] array, ref int current)
        {
            if (point != null)
            {
                TransformToArray(point.Left, array, ref current);
                array[current] = point.Data;
                current++;
                TransformToArray(point.Right, array, ref current);
            }
        }

        public void TransformToFindTree()
        {
            T[] array = new T[count];
            int current = 0;
            TransformToArray(root, array, ref current);

            root = new TreeNode<T>(array[0]);
            count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                AddPoint(array[i]);
            }
            IsFindTree = true;
        }

        public Tree<T> MadeFromTreeToFindTree(Tree<T> newTree)
        {
            T[] array = new T[count];
            int current = 0;
            TransformToArray(root, array, ref current);


            for (int i = 0; i < array.Length; i++)
            {
                newTree.AddPoint(array[i]);
            }
            return newTree;
        }


        public T FindMax(TreeNode<T> root)
        {
            if (root == null)
            {
                throw new ArgumentNullException("root", "Дерево пустое");
            }
            if (IsFindTree)
            {
                var current = root;
                while (current.Left != null)
                {
                    current = current.Left;
                }
                return current.Data;
            }
            else
            {
                T max = root.Data;
                TreeNode<T>[] children = { root.Left, root.Right };
                foreach (var child in children)
                {
                    if (child != null)
                    {
                        T childMax = FindMax(child);
                        if (childMax.CompareTo(max) > 0)
                        {
                            max = childMax;
                        }
                    }
                }
                return max;
            }
        }

        public void Clear()
        {
            Clear(root);
            root = null;
            count = 0;
            IsFindTree = false;
        }

        private void Clear(TreeNode<T> node)
        {
            if (node != null)
            {
                Clear(node.Left);
                Clear(node.Right);
                node.Left = null;
                node.Right = null;
                node.Data = default(T);  // Сбрасываем данные узла
            }
        }

        public void Remove(T data)
        {
            root = Remove(root, data);
        }

        private TreeNode<T> Remove(TreeNode<T> node, T data)
        {
            if (node == null)
            {
                count++;
                return null;
            }

            count--;

            if (count == 0)
                root = null;

            int compare = data.CompareTo(node.Data);

            if (compare < 0)
            {
                node.Left = Remove(node.Left, data);
            }
            else if (compare > 0)
            {
                node.Right = Remove(node.Right, data);
            }
            else if (node.Left == null && node.Right == null)
            {
                node.Data = default;
                return null;
            }
            else if (node.Left == null)
            {
                return node.Right;
            }
            else if (node.Right == null)
            {
                return node.Left;
            }
            else
            {
                TreeNode<T> minNode = FindMin(node.Right);
                node.Data = minNode.Data;
                node.Right = Remove(node.Right, minNode.Data);
            }
            return node;
        }

        private TreeNode<T> FindMin(TreeNode<T> node)
        {
            while (node.Left != null)
            {
                node = node.Left;
            }
            return node;
        }
    }
}


using System;

namespace Лабораторная_12
{
    public class TreeNode<T> where T : IComparable
    {
        public T Data { get; set; }
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }

        public TreeNode()
        {
            Data = default(T);
            Left = null;   
            Right = null;
        }

        public TreeNode(T data)
        {
            Data = data;
            Left = null;
            Right = null;
        }

        public override string ToString()
        {
            return Data == null ? "": Data.ToString();
        }
    }
}

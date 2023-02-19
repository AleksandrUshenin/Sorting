using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorterMethods
{
    class PiramidalSort2<T>
    {
        private Node<T> root;
        private Comparer<T> Compare;
        private int Count { get; set; }
        private int Level;

        public PiramidalSort2() 
        {}
        public PiramidalSort2(Comparer<T> comparator)
        {
            this.Compare = comparator;
        }

        public void Add(T value)
        {
            if (root == null)
            {
                root = new Node<T>(value);
                Count++;
                return;
            }
            Add(root, value);
        }
        private void Add(Node<T> node, T value)
        {
            if (node.left == null)
            {
                node.left = new Node<T>(value, node);
                
            }
            else if (node.right == null)
            {
                node.right = new Node<T>(value, node);
            }
            else
            {
                if (node.right.left == null)
                {
                    Add(node.right, value);
                    Count++;
                    return;
                }
                else if (node.right.right == null)
                {
                    Add(node.right, value);
                    Count++;
                    return;
                }
                else
                {
                    Add(node.right, value);
                }
            }
            Count++;
        }

        private bool CheckLevel(Node<T> node) 
        {
            if (node.left.right == null)
                return true;
            if (node.left.left == null)
                return true;
            return false;
        }

        private int CompareNode(Node<T> n1, Node<T> n2) 
        {
            if (Compare == null)
                return n1.GetValue.Equals(n2.GetValue) == true ? 1 : -1;

            return Compare.Compare(n1.GetValue, n2.GetValue);

        }
    }
}

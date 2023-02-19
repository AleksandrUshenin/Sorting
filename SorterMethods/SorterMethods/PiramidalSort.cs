using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorterMethods
{
    class PiramidalSort<T>
    {
        private T[] NodeArry;
        private Node<T> root;
        private Comparer<T> Compare;
        public int Count { get; private set; }
        private int Level;

        private Node<T> Min;
        private Node<T> Max;

        public PiramidalSort() 
        {}
        public PiramidalSort(Comparer<T> comparator)
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
        public void Add(T[] value) 
        {
            for (int i = 0; i < value.Length; i++)
            {
                Add(value[i]);
            }
        }
        private void Add(Node<T> node, T value)
        {
            if (CompareNode(node.GetValue, value) > 0)
            {
                if (node.left == null)
                {
                    node.left = new Node<T>(value, node);
                    Count++;
                }
                else
                {
                    Add(node.left, value);
                }
            }
            if (CompareNode(node.GetValue, value) < 0)
            {
                if (node.right == null)
                {
                    node.right = new Node<T>(value, node);
                    Count++;
                }
                else
                {
                    Add(node.right, value);
                }
            }
        }

        public T[] GetArry()
        {
            return NodeArry;
        }

        public void Sorter()
        {
            Rebalsnce(root);
            NodeArry = new T[Count];
            int item = 0;
            var node = Min;
            while (node != root)
            {
                NodeArry[item] = node.GetValue;
                item++;
                node = node.Previous;
            }
            while (node != null)
            {
                NodeArry[item] = node.GetValue;
                item++;
                node = node.right;
            }
        }

        private void Rebalsnce(Node<T> node) 
        {
            var n1 = node;
            var n2 = node;
            while (n1 != null && n1.left != null)
            {
                n1 = n1.left;
                RebalsnceLeft(n1);
                Min = n1;
            }
            while (n2 != null && n2.right != null)
            {
                n2 = n2.right;
                RebalsnceRight(n2);
                Max = n2;
            }
        }
        private void RebalsnceLeft(Node<T> node)
        {
            if (node == null)
                return;
            if (node.right != null && (CompareNode(node.GetValue, node.right.GetValue) < 0))
            {
                //var preNode = node.Previous;
                node.Previous.left = node.right;
                node.right.Previous = node.Previous;
                node.Previous = node.right;
                node.right = null;
            }
        }
        private void RebalsnceRight(Node<T> node)
        {
            if (node == null)
                return;
            if (node.left != null && (CompareNode(node.GetValue, node.left.GetValue) > 0))
            {
                node.Previous.right = node.left;
                node.left.Previous = node.Previous;
                node.Previous = node.left;
                if (node.left.right != null)
                {
                    node.left = node.Previous.right;
                    RebalsnceRight(node);
                }
                else
                {
                    node.Previous.right = node;
                    node.left = null;
                }

                //RebalsnceRight(node.Previous);
            }
            else
            { }
        }

        private int CompareNode(T n1, T n2) 
        {
            if (Compare == null)
                return n1.Equals(n2) == true ? 1 : -1;

            return Compare.Compare(n1, n2);

        }
    }
}

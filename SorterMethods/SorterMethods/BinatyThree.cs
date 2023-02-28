using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorterMethods
{
    public class BinatyThree<T>
    {
        private Node Root;
        private Comparer<T> _Comparer;

        public BinatyThree()
        { }
        public BinatyThree(Comparer<T> comparer)
        {
            _Comparer = comparer;
        }

        /// <summary>
        /// добавление
        /// </summary>
        /// <param name="value">значение</param>
        /// <returns>результат добавления</returns>
        public bool Add(T value)
        {
            if (Root != null)
            {
                bool result = AddNode(Root, value);
                Root = Rebalance(Root);
                Root.Color = ColorNode.Black;
                return result;
            }
            else
            {
                Root = new Node(value);
                Root.Color = ColorNode.Black;
                return true;
            }
        }

        private bool AddNode(Node node, T value)
        {
            if (Equals(node.Value, value))
                return false;
            else
            {
                if (Compare(node.Value, value))
                {
                    if (node.LeftChild != null)
                    {
                        bool result = AddNode(node.LeftChild, value);
                        node.LeftChild = Rebalance(node.LeftChild);
                        return result;
                    }
                    else
                    {
                        node.LeftChild = new Node(value);
                        node.LeftChild.Color = ColorNode.Red;
                        return true;
                    }
                }
                else 
                {
                    if (node.RightChild != null)
                    {
                        bool result = AddNode(node.RightChild, value);
                        node.RightChild = Rebalance(node.RightChild);
                        return result;
                    }
                    else
                    {
                        node.RightChild = new Node(value);
                        node.Color = ColorNode.Red;
                        return true;
                    }
                }
            }
        }
        private Node Rebalance(Node node)
        {
            Node result = node;
            bool needRebalance;
            do
            {
                needRebalance = false;
                if (result.RightChild != null && result.RightChild.Color == ColorNode.Red &&
                    (result.LeftChild == null || result.LeftChild.Color == ColorNode.Black))
                {
                    needRebalance = true;
                    result = RightSwap(result);
                }
                if (result.LeftChild != null && result.LeftChild.Color == ColorNode.Red &&
                    result.LeftChild.LeftChild != null && result.LeftChild.LeftChild.Color == ColorNode.Red)
                {
                    needRebalance = true;
                    result = LeftSwap(result);
                }
                if (result.LeftChild != null && result.LeftChild.Color == ColorNode.Red &&
                        result.RightChild != null && result.RightChild.Color == ColorNode.Red)
                {
                    needRebalance = true;
                    ColorSwap(result);
                }
            }
            while (needRebalance);
            return result;
        }
        private Node RightSwap(Node node)
        {
            Node rightChild = node.RightChild;
            Node betweenChild = node.LeftChild;
            rightChild.LeftChild = node;
            node.RightChild = betweenChild;
            rightChild.Color = node.Color;
            node.Color = ColorNode.Red;
            return rightChild;
        }
        private Node LeftSwap(Node node)
        {
            Node leftChild = node.LeftChild;
            Node betweenChild = node.RightChild;
            leftChild.RightChild = node;
            node.LeftChild = betweenChild;
            leftChild.Color = node.Color;
            node.Color = ColorNode.Red;
            return leftChild;
        }
        private void ColorSwap(Node node)
        {
            node.RightChild.Color = ColorNode.Black;
            node.LeftChild.Color = ColorNode.Black;
            node.Color = ColorNode.Red;
        }

        public class Node
        {
            public T Value { get; private set; }
            public ColorNode Color;
            public Node LeftChild;
            public Node RightChild;

            public Node(T value)
            {
                this.Value = value;
            }
            public override string ToString()
            {
                return "{ " + Value.ToString() + " " + Color + " }";
            }
        }
        private bool Equals(T o1, T o2)
        {
            if (_Comparer != null)
            {
                if (_Comparer.Compare(o1, o2) == 0)
                    return true;
                return false;
            }
            return o1.Equals(o2);
        }
        private bool Compare(T o1, T o2)
        {
            if (_Comparer != null)
            {
                if (_Comparer.Compare(o1, o2) > 0)
                    return true;
                return false;
            }
            return o1.Equals(o2);
        }

    }
    public enum ColorNode
    {
        Red, Black
    }
}

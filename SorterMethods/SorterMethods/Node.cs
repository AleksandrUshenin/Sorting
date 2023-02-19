using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorterMethods
{
    class Node<T>
    {
        private T Value;

        public Node<T> Previous;
        public Node<T> left;
        public Node<T> right;

        public Node(T value)
        {
            this.Value = value;
        }
        public Node(T value, Node<T> previous) : this(value)
        {
            Previous = previous;
        }

        public T GetValue { get { return Value; } }
    }
}

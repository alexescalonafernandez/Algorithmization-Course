using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{

    class DSStack<T>
    {
        Node<T> top;
        public DSStack() { }

        public bool Empty()
        {
            return top == null;
        }

        public void Push(T e)
        {
            if (Empty())
                top = new Node<T>(e);
            else top = new Node<T>(e, top);
        }

        public T Top()
        {
            if (Empty())
                throw new Exception("Empty stack");
            return top.Element; 
        }

        public T Pop()
        {
            T e = Top();
            top = top.Next;
            return e;
        }

    }
}

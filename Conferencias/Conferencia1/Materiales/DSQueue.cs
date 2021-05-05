using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{

    class DSQueue<T>
    {
        Node<T> head, tail;

        public DSQueue() { }

        public bool Empty()
        {
            return head == null;
        }

        public void Enqueue(T e)
        {
            if (Empty())
                head = tail = new Node<T>(e);
            else
            {
                tail.Next = new Node<T>(e);
                tail = tail.Next;
            }
        }

        public T Peek()
        {
            if (Empty())
                throw new Exception("Empty queue");
            return head.Element;
        }

        public T Dequeue()
        {
            T e = Peek();
            head = head.Next;
            return e;
        }
    
    }
}

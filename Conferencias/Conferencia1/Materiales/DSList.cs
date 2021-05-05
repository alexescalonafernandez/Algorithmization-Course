using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{

    class DSList<T> : IEnumerable<T>
    {
        Node<T> head, tail;
        int lenght;

        public int Lenght
        {
            get { return lenght; }
        }

        public DSList() { }

        public bool Empty()
        {
            return lenght == 0;
        }

        public void Add(T e)
        {
            if (Empty())
                head = tail = new Node<T>(e);
            else
            {
                tail.Next = new Node<T>(e);
                tail = tail.Next;
            }
            lenght++;
        }

        public void AddRange(IEnumerable<T> enumerable)
        {
            foreach (T e in enumerable)
                Add(e);
        }
        
        private Node<T> getNode(int index)
        {
            Node<T> ptr = head;
            while (index-- > 0)
                ptr = ptr.Next;
            return ptr;
        }
        
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= lenght)
                    throw new IndexOutOfRangeException();
                return getNode(index).Element;
            }
            set
            {
                if (index < 0 || index >= lenght)
                    throw new IndexOutOfRangeException();
                getNode(index).Element = value; 
            }
        }

        public DSList<T> GetRange(int index, int count)
        {
            if (count < 0 || index < 0 || index + count >= lenght)
                throw new IndexOutOfRangeException();
            DSList<T> range = new DSList<T>();
            Node<T> ptr = index == 0 ? head : getNode(index);
            while (count-- > 0)
            {
                range.Add(ptr.Element);
                ptr = ptr.Next;
            }
            return range;
        }

        public void Insert(int index, T e)
        {
            if (index < 0 || index > lenght)
                throw new IndexOutOfRangeException();
            if (index == lenght)
                Add(e);
            else
            {
                if (index == 0)
                    head = new Node<T>(e, head);
                else
                {
                    Node<T> ptr = getNode(index - 1);
                    ptr.Next = new Node<T>(e, ptr.Next);
                }
                lenght++;
            }
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= lenght)
                throw new IndexOutOfRangeException();
            switch (index)
            {
                case 0:
                    head = head.Next; break;
                default:
                    Node<T> ptr = getNode(index - 1);
                    ptr.Next = ptr.Next.Next;
                    if (ptr.Next == null)
                        tail = ptr;
                    break;
            }
            lenght--;
        }

        public void Remove(T e)
        {
            Node<T> previous = null;
            Node<T> current = head;
            bool flag = false;
            for (int i = 0; i < lenght && !flag; i++)
                if (flag = current.Element.Equals(e))
                {
                    if (previous == null)
                        head = head.Next;
                    else
                    {
                        previous.Next = current.Next;
                        if (previous.Next == null)
                            tail = previous;
                    }
                }
                else
                {
                    previous = current;
                    current = current.Next;
                }
            if (flag)
                lenght--;
        }

        public void RemoveAll(T e)
        {
            Node<T> previous = null;
            Node<T> current = head;
            int counter = 0;
            for (int i = 0; i < lenght; i++)
                if (current.Element.Equals(e))
                {
                    counter++;
                    if (previous == null)
                        head = head.Next;
                    else
                    {
                        previous.Next = current.Next;
                        if (previous.Next == null)
                            tail = previous;
                    }
                    current = current.Next;
                }
                else
                {
                    previous = current;
                    current = current.Next;
                }
            lenght -= counter;
        }

        public void RemoveRange(int index, int count)
        {
            if (count < 0 || index < 0 || index + count >= lenght)
                throw new IndexOutOfRangeException();
            Node<T> ptr = index == 0 ? head : getNode(index - 1);
            while (count-- > 0)
                ptr = ptr.Next;
            if (ptr != null && ptr.Next == null)
                tail = ptr;
            lenght-=count;
        }

        public void Clear()
        {
            head = tail = null;
            lenght = 0;
        }

        public T[] ToArray()
        {
            T[] elements = new T[lenght];
            int index = 0;
            Node<T> ptr = head;
            while (ptr != null)
            {
                elements[index++] = ptr.Element;
                ptr = ptr.Next;
            }
            return elements;
        }

        public void Reverse()
        {
            if (!Empty())
            {
                Node<T> newHead = null, newTail = null;
                while (head != null)
                {
                    newHead = new Node<T>(head.Element, newHead);
                    if (newTail == null)
                        newTail = newHead;
                    head = head.Next;
                }
                head = newHead;
                tail = newTail;
            }
        }

        public bool Contains(T e)
        {
            Node<T> ptr = head;
            while (ptr != null)
            {
                if (ptr.Element.Equals(e))
                    return true;
            }
            return false;
        }

        public int IndexOf(T e)
        {
            int index = 0;
            Node<T> ptr = head;
            while (ptr != null)
            {
                if (ptr.Element.Equals(e))
                    return index;
                index++;
            }
            return -1;
        }

        public int IndexOf(T e, int index)
        {
            Node<T> ptr = getNode(index);
            while (ptr != null)
            {
                if (ptr.Element.Equals(e))
                    return index;
                index++;
            }
            return -1;
        }

        public int IndexOf(T e, int index, int count)
        {
            Node<T> ptr = getNode(index);
            while (ptr != null && count-- > 0)
            {
                if (ptr.Element.Equals(e))
                    return index;
                index++;
            }
            return -1;
        }

        #region Miembros de IEnumerable<T>

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> ptr = head;
            while (ptr != null)
            {
                yield return ptr.Element;
                ptr = ptr.Next;
            }
        }

        #endregion

        #region Miembros de IEnumerable

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    
    }
}

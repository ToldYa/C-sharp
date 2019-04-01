using System;

namespace Main
{
    class MyLinkedList<E> : IMyCollection<E> where E : IEquatable<E>
    {
        private Node headSentinel;
        private int size;

        public MyLinkedList()
        {
            headSentinel = new Node();
            size = 0;
        }

        public MyLinkedList(E element)
        {
            CheckElement(element);
            Node toAdd = new Node(element);
            headSentinel = new Node();
            headSentinel.next = toAdd;
            size = 1;
        }

        public bool Add(E element)
        {
            CheckElement(element);
            Node toAdd = new Node(element);
            toAdd.next = headSentinel.next;
            headSentinel.next = toAdd;
            size++;

            return true;
        }

        public bool Remove(E element)
        {
            CheckElement(element);
            Node current = headSentinel;
            bool deleted = false;

            while (current.next != null && !deleted)
            {
                if (current.next.element.Equals(element))
                {
                    if (current.next.next == null)
                        current.next = null;
                    else
                        current.next = current.next.next;
                    deleted = true;
                    size--;
                }
                current = current.next;
            }            

            return deleted;
        }

        public bool Contains(E element)
        {
            Node current = headSentinel;
            bool found = false;

            while (current.next != null && !found)
            {
                if (current.next.element.Equals(element))
                {
                    found = true;
                }
                current = current.next;
            }

            return found;
        }

        private void CheckElement(E element)
        {
            if (element == null)
            {
                throw new NullReferenceException("Cannot add null value to MyLinkedList.");
            }
        }

        public E Get(uint index)
        {
            E current = headSentinel.element;
            
            if(!(index > size || index < 0))
            {
                E temp = headSentinel.element;
                uint i = 0;
                CustomIterator ite = Iterator();
                bool found = false;

                while (ite.HasNext() && !found)
                {
                    current = ite.Next();
                    if (i == index)
                    {
                        temp = current;
                        found = true;
                    }
                    i++;
                }
            }
            else
            {
                Console.WriteLine("Bad index given to MyLinkedList.Get()");
            }
            
            return current;
        }

        public int Size()
        {
            return size;
        }

        public CustomIterator Iterator()
        {
            return new CustomIterator(headSentinel);
        }

        public class CustomIterator : IMyIterator<E>
        {
            Node previous;
            Node current;

            public CustomIterator(Node head)
            {
                current = head;
                previous = null;
            }

            public bool HasNext()
            {
                return current.next != null;
            }

            public E Next()
            {
                previous = current;
                current = current.next;
                return current.element;
            }

            public E Remove()
            {
                Node temp = current;
                previous.next = temp.next;
                current = temp.next;
                return temp.element;
            }
        }

        public class Node
        {
            public E element;
            public Node next;

            public Node() { }
            
            public Node(E element)
            {
                this.element = element;
            }
        }

    }
}

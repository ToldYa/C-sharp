using System;

namespace Main
{
    class MyHashSet<E> : IMyCollection<E> where E : IEquatable<E>
    {
        int size;
        const int DEFAULT_CAPACITY = 100;
        E[] elements;

        public MyHashSet()
        {
            elements = new E[DEFAULT_CAPACITY];
            size = 0;
        }

        public MyHashSet(int capacity)
        {
            elements = new E[capacity];
            size = 0;
        }
        
        public bool Add(E element)
        {
            bool added = false;
            int index = element.GetHashCode() % elements.Length;
            Console.WriteLine(index);
            EnsureCapacity();

            if(elements[index] != null)
            {
                if (!elements[index].Equals(element))
                {
                    while (!added)
                    {
                        if (elements[++index] == null || elements[index].Equals(element))
                        {
                            if(elements[index] == null)
                                size++;
                            elements[index] = element;
                            added = true;
                        }
                    }
                }
            }
            else
            {
                elements[index] = element;
                size++;
            }

            return added;
        }

        private void EnsureCapacity()
        {
            if(elements.Length / 2 < size)
            {
                Object[] temp = new Object[elements.Length * 2];
                elements.CopyTo(temp, 0);
            }
        }

        public bool Contains(E element)
        {
            bool contains = false;
            int hash = element.GetHashCode();
            int index = hash % elements.Length;

            if(elements[index] != null)
                if (elements[index].Equals(element))
                    contains = true;
            
            return contains;
        }

        public bool Remove(E element)
        {
            if (element == null)
                throw new NullReferenceException();

            bool removed = false;
            int index = element.GetHashCode() % elements.Length;

            if (elements[index].Equals(element))
            {
                elements[index % elements.Length] = default(E);
                removed = true;
                size--;
            }

            return removed;
        }

        public int Size()
        {
            return size;
        }

        public override string ToString()
        {
            string output = "";

            for (int i = 0; i < elements.Length; i++)
            {
                if(elements[i] != null) // || elements[i] != default(E))
                {
                    output += elements[i].ToString() + " - ";
                }
            }
            if(output.Length > 1)
                output = output.Remove(output.Length - 2, 2);

            return output;
        }

    }
}

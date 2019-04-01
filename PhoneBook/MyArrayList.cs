using System;

namespace Main
{
    class MyArrayList<E> : IMyCollection<E> where E : IEquatable<E> //, IEnumerable<E>
    {
        private int size;
        private Object[] elements;
        private const ushort DEFAULT_CAPACITY = 10;

        public MyArrayList(int initialCapacity)
        {
            size = 0;
            elements = new Object[initialCapacity];
        }

        public MyArrayList()
        {
            size = 0;
            elements = new Object[DEFAULT_CAPACITY];
        }

        public bool Add(E e)
        {
            if (++size == elements.Length - 1)
                AdjustCapacity();
            elements[size-1] = e;

            return true;
        }

        public void Set(E e, int index)
        {
            if (index < 0 || index > size)
                throw new IndexOutOfRangeException();
            if (index == size)
                size++;
            if (size == elements.Length - 1)
                AdjustCapacity();
            
            elements[index] = e;
        }

        private void AdjustCapacity()
        {
            Object[] temp = new Object[size * 2];

            elements.CopyTo(temp, 0);
            elements = temp;
        }

        public bool Remove(E e)
        {
            bool removed = false;
            for(int i = 0; i < size; i++)
            {
                if (elements[i].Equals(e))
                {
                    if (i == size - 1)
                        elements[i] = null;
                    else
                        ShiftRemove(i);
                    removed = true;
                    i = size;
                    size--;
                }
            }
            return removed;
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= size)
                throw new IndexOutOfRangeException();
            ShiftRemove(index);
            size--;
        }

        private void ShiftRemove(int index)
        {
            for (int i = index; i < size; i++)
            {
                elements[i] = elements[i + 1];
            }
        }

        public bool Contains(E e)
        {
            bool found = false;
            for(int i = 0; i < elements.Length; i++)
                if (elements[i].Equals(e))
                {
                    found = true;
                    i = elements.Length;
                }

            return found;
        }

        public int Size()
        {
            return size;
        }

    }
}

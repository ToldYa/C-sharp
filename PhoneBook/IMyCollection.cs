namespace Main
{
    interface IMyCollection<E>
    {
        bool Add(E element);
        bool Remove(E element);
        bool Contains(E element);
        int Size();
        string ToString();
    }
}

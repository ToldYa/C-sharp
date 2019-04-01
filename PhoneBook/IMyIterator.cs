namespace Main
{
    interface IMyIterator<T>
    {
        bool HasNext();
        T Next();
        T Remove();
    }
}

using System;

namespace Main
{
    abstract class ContactNumber
    {
        string number;

        public ContactNumber(string number)
        {
            this.number = number;
        }

        public void SetNumber(string number)
        {
            this.number = number;
        }

        public string GetNumber()
        {
            return number;
        }

        public abstract override string ToString();
    }
}

using System;

namespace Main
{
    class LastName : IComparable<LastName>, IEquatable<LastName>
    {
        private string lastName;

        public LastName(string lastName)
        {
            this.lastName = lastName;
        }

        public void SetLastName(string newLastName)
        {
            this.lastName = newLastName;
        }

        public string GetLastName()
        {
            return lastName;
        }

        public bool Equals(LastName other)
        {
            return lastName.Equals(other.lastName);
        }

        public override int GetHashCode()
        {
            return lastName.Length + (int)lastName[0];
        }

        public override string ToString()
        {
            return lastName;
        }

        public int CompareTo(LastName other)
        {
            return this.lastName.CompareTo(other.lastName);
        }
    }
}

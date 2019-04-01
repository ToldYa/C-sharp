using System;

namespace Main
{
    class FirstName : IComparable<FirstName>, IEquatable<FirstName>
    {
        private string firstName;

        public FirstName(string firstName)
        {
            this.firstName = firstName;
        }

        public void SetFirstName(string newFirstName)
        {
            this.firstName = newFirstName;
        }

        public string GetFirstName()
        {
            return firstName;
        }

        public bool Equals(FirstName other)
        {
            return firstName.Equals(other.firstName);
        }

        public override int GetHashCode()
        {
            return firstName.Length + (int)firstName[0];
        }

        public override string ToString()
        {
            return firstName;
        }

        public int CompareTo(FirstName other)
        {
            return this.firstName.CompareTo(other.firstName);
        }
    }
}
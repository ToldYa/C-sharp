using System;
using System.Collections.Generic;

namespace Main
{
    class Contact : IComparable<Contact>, IEqualityComparer<Contact>, IEquatable<Contact>
    {
        private FirstName firstName;
        private LastName lastName;
        private ContactNumber number;

        public Contact(string firstName, string lastName, ContactNumber number)
        {
            this.firstName = new FirstName(firstName);
            this.lastName = new LastName(lastName);
            this.number = number;
        }

        public Contact(string firstName, string lastName)
        {
            this.firstName = new FirstName(firstName);
            this.lastName = new LastName(lastName);
        }

        public FirstName GetFirstName()
        {
            return firstName;
        }

        public LastName GetLastName()
        {
            return lastName;
        }

        public ContactNumber GetContNumber()
        {
            return number;
        }

        public bool Equals(Contact other)
        {
            return firstName.Equals(other.firstName) && lastName.Equals(other.lastName);
        }

        public int CompareTo(Contact other)
        {
            int diff;

            if (firstName.CompareTo(other.firstName) == 0 && lastName.CompareTo(other.lastName) == 0)
                diff = 0;
            else
                diff = 0; //SE ÖVER HUR SKA RÄKNAS

            return diff;
        }

        public bool Equals(Contact x, Contact y)
        {
            return x.firstName.Equals(y.firstName) && x.lastName.Equals(y.lastName);
        }

        public int GetHashCode(Contact obj)
        {
            return obj.firstName.GetHashCode() * obj.lastName.GetHashCode() * 3;
        }

        public override int GetHashCode()
        {
            return firstName.GetHashCode() + lastName.GetHashCode();
        }

        public override string ToString()
        {
            if (number != null)
                return firstName.ToString() + " " + lastName.ToString() + ": " + number.ToString();
            else
                return firstName.ToString() + " " + lastName.ToString();
        }
    }
}

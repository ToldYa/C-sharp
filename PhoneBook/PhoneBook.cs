using System;

namespace Main
{
    class PhoneBook
    {
        private MyLinkedList<Contact> contactList;

        public PhoneBook()
        {
            contactList = new MyLinkedList<Contact>();
        }

        public void AddCont(Contact contact)
        {
            contactList.Add(contact);
        }

        public bool AddUndefinedCont()
        {
            bool added = false;
            Contact toAdd = RetrieveContactInfo();
            if(toAdd != null)
            {
                contactList.Add(toAdd);
                added = true;
            }

            return added;
        }

        private Contact RetrieveContactInfo()
        {
            bool valid = true;
            Contact contact = null;

            Console.Write("Contact first name: ");
            string firstName = Console.ReadLine().ToLower().Trim(' ');
            if (firstName == "")
            {
                Console.WriteLine("Bad first name!");
                valid = false;
            }
            if (!valid)
                return null;
                
            Console.Write("Contact last name: ");
            string lastName = Console.ReadLine().ToLower().Trim(' ');
            if (lastName == "")
            {
                Console.WriteLine("wrong lastname");
                valid = false;
            }
            if (!valid)
                return null;

            Console.Write("Contact number type {home, mobile}: ");
            string contactNumberType = Console.ReadLine().ToLower().Trim(' ');
            if (contactNumberType == "" || !(contactNumberType == "home" || contactNumberType == "mobile"))
            {
                Console.WriteLine("wrong contact number type");
                valid = false;
            }
            if (!valid)
                return null;

            Console.Write("Contact number: ");
            string contactNumber = Console.ReadLine().ToLower().Trim(' ');

            Console.WriteLine();

            ContactNumber number = AssignNumberType(contactNumberType, contactNumber);

            if (firstName != null && lastName != null && number != null)
                contact = new Contact(firstName, lastName, number);

            return contact;
        }

        private bool checkNumberType(string numberType)
        {
            if (numberType == "home" || numberType == "mobile")
                return true;
            else
                return false;
        }

        private ContactNumber AssignNumberType(string numberType, string contactNumber)
        {
            ContactNumber number = null;
            if(numberType != null)
            {
                switch (numberType)
                {
                    case "home":
                        if (contactNumber.Length == 9)
                            number = new HomeNumber(contactNumber);
                        else
                            Console.WriteLine("Wrong number length");
                        break;
                    case "mobile":
                        if (contactNumber.Length == 10)
                            number = new MobileNumber(contactNumber);
                        else
                            Console.WriteLine("Wrong number length");
                        break;
                }
            }
            
            return number;
        }

        public void RemoveCont()
        {
            Console.Write("Contact to remove information!\nFirst name: ");
            string firstName = Console.ReadLine();
            Console.Write("Last name: ");
            string lastName = Console.ReadLine();

            Contact toRemove = new Contact(firstName.ToLower().Trim(' '), lastName.ToLower().Trim(' '));

            IMyIterator<Contact> ite = contactList.Iterator();
            while (ite.HasNext())
            {
                Contact temp = ite.Next();
                if (temp.Equals(toRemove))
                {
                    ite.Remove();
                }
            }
            Console.WriteLine();
        }

        public void PrintBook()
        {
            IMyIterator<Contact> ite = contactList.Iterator();
            while (ite.HasNext())
            {
                Console.WriteLine(ite.Next().ToString());
            }
        }
        public MyLinkedList<Contact> getContactList()
        {
            return contactList;
        }
    }

}

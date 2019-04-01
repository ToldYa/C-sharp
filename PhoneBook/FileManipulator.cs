using System;
using System.IO;

namespace Main
{
    class FileManipulator
    {
        private PhoneBook book;

        public FileManipulator(PhoneBook book)
        {
            this.book = book;
        }

        public void SaveContactsToFile()
        {
            try
            {
                StreamWriter sw = new StreamWriter("C:/Users/Avaus/Desktop/contacts/contactFile.txt");
                MyLinkedList<Contact> contList = book.getContactList();
                IMyIterator<Contact> ite = contList.Iterator();

                while (ite.HasNext())
                {
                    String line = "";
                    Contact cont = ite.Next();
                    if(cont.GetContNumber() is HomeNumber)
                        line = cont.GetFirstName().ToString() + "," + cont.GetLastName().ToString() + ",home," + cont.GetContNumber().ToString();
                    if (cont.GetContNumber() is MobileNumber)
                        line = cont.GetFirstName().ToString() + "," + cont.GetLastName().ToString() + ",mobile," + cont.GetContNumber().ToString();
                    sw.WriteLine(line);
                }
                
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Saving contacts!");
            }
        }

        public void LoadContactsFromFile()
        {
            String line;
            try
            {
                StreamReader sr = new StreamReader("C:/Users/Avaus/Desktop/contacts/contactFile.txt");
                line = sr.ReadLine();

                while (line != null)
                {
                    String[] contactInfo = line.Split(',');
                    if(contactInfo[2] == "home")
                        book.AddCont(new Contact(contactInfo[0], contactInfo[1], new HomeNumber(contactInfo[3])));
                    if (contactInfo[2] == "mobile")
                        book.AddCont(new Contact(contactInfo[0], contactInfo[1], new MobileNumber(contactInfo[3])));
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Contacts retrieved!\n");
            }
        }
    }
}

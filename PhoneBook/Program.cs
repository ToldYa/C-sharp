using System;

namespace Main
{
    class Program
    {
        private static PhoneBook book;
        private bool running;
        private FileManipulator fileManip;

        public Program()
        {
            book = new PhoneBook();
            fileManip = new FileManipulator(book);
            fileManip.LoadContactsFromFile();
        }

        private void RunCommand(string cmd)
        {
            switch (cmd.ToLower().Trim(' '))
            {
                case "add":
                    book.AddUndefinedCont();
                    break;
                case "rem":
                    book.RemoveCont();
                    break;
                case "print":
                    book.PrintBook();
                    Console.WriteLine();
                    break;
                case "quit":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Non-valid command: \"" + cmd + "\"\n");
                    break;
            }
        }

        private void Run()
        {
            running = true;

            while (running)
            {
                Console.Write("Give command {add, rem, print, quit}: ");
                string cmd = Console.ReadLine();
                RunCommand(cmd);
            }
            fileManip.SaveContactsToFile();
            Console.WriteLine("Goodbye!\n------------------------end of program------------------------*\n");
        }

        public static void Main(string[] args)
        {
            /* ################################### BINARY TREE TESTING ###################################
            
            MyBinaryTree<int> tree = new MyBinaryTree<int>();

            tree.Add(50);
            tree.Add(25);
            tree.Add(40);
            tree.Add(15);
            tree.Add(75);
            tree.Add(60);
            tree.Add(90);
            tree.Add(62);
            tree.Add(64);
            tree.Add(66);
            tree.Add(65);
            tree.Add(61);

            Console.WriteLine("Contains 66: " + tree.Contains(66));
            Console.WriteLine("Printing tree:\n" + tree.ToString());
            Console.WriteLine("Tree size: " + tree.Size());

            Console.WriteLine("\nRemoving 75: " + tree.Remove(75));
            Console.WriteLine("Printing tree:\n" + tree.ToString());
            Console.WriteLine("Tree size: " + tree.Size());

            Console.WriteLine("\nRemoving 65: " + tree.Remove(65));
            Console.WriteLine("Printing tree:\n" + tree.ToString());
            Console.WriteLine("Tree size: " + tree.Size());
            */

            /* ################################### HASHSET TESTING ###################################
            
            MyHashSet<Contact> testSet = new MyHashSet<Contact>();

            testSet.Add(new Contact("a", "a"));
            testSet.Add(new Contact("b", "c"));
            testSet.Add(new Contact("f", "g"));
            testSet.Add(new Contact("a", "p", new HomeNumber("12345678")));
            testSet.Add(new Contact("a", "r"));
            testSet.Add(new Contact("a", "a"));

            Console.WriteLine("\nHashSet size: " + testSet.Size());
            Console.WriteLine(testSet.ToString() + "\n");

            Console.WriteLine("Removing \"a - a\"" + testSet.Remove(new Contact("a", "a")));
            Console.WriteLine("HashSet size: " + testSet.Size());
            Console.WriteLine(testSet.ToString() + "\n");
            */

            //Program prog = new Program();
            //prog.Run();
        }
    }
}
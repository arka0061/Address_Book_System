using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    public class AddressBookRegulator
    {
        public static Dictionary<string, List<AddressBook>> Dict = new Dictionary<string, List<AddressBook>>();
        public static void Regulator()
        {
            Console.WriteLine("Enter no. of AddressBooks");
            int noOfAddressBooks = Convert.ToInt32(Console.ReadLine());
            while (noOfAddressBooks > 0)
            {
                Console.WriteLine("Enter Address BookName :");
                string addressBookName = Console.ReadLine();
                AddressBookMain.Choice();
                Dict.Add(addressBookName, AddressBookMain.People);
                noOfAddressBooks--;
            }
            Display();
        }
        public static void Display()
        {
            string Select = "";
            Console.WriteLine("Enter 'dict' to Display Dictionaries");
            Console.WriteLine("Enter 'stop' to stop");
            while (Select != "stop")
            {
                Select = Console.ReadLine().ToLower();
                switch (Select)
                {
                    case "dict":
                        DisplayDictionaries();
                        break;
                }
            }
        }
        public static void DisplayDictionaries()
        {
            foreach (KeyValuePair<string, List<AddressBook>> kvp in AddressBookRegulator.Dict)
            {
                Console.WriteLine("Dictionary Name is :"+kvp.Key);
                foreach (var person in kvp.Value)
                {
                    Console.WriteLine("Value of Dictionary "+kvp.Key+" is :");
                    AddressBookMain.Display(person);
                }
            }
        }
    }
}
            
        
    

                
            
        

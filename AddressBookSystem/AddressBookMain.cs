using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    public class AddressBookMain
    {
        public static List<AddressBook> People;
        public static void AddPerson()
        {
            String NameFirst = "";
            People = new List<AddressBook>();
            AddressBook person = new AddressBook();
            Console.WriteLine("Enter your FirstName :");
            NameFirst = Console.ReadLine();
            person.FirstName = NameFirst;
            Console.WriteLine("Enter your Lastname :");
            person.LastName = Console.ReadLine();
            Console.WriteLine("Enter your Address : ");
            person.Address = Console.ReadLine();
            Console.WriteLine("Enter your City :");
            person.City = Console.ReadLine();
            Console.WriteLine("Enter your State :");
            person.State = Console.ReadLine();
            Console.WriteLine("Enter your PhoneNumber :");
            person.PhoneNumber = Console.ReadLine();
            Console.WriteLine("Enter your Zip :");
            person.Zip = Console.ReadLine();
            Console.WriteLine("Enter your Email Id :");
            person.Email = Console.ReadLine();
            People.Add(person);
        }

    }
}

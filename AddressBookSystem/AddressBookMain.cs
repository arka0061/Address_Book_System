using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    public class AddressBookMain
    {
        public static String Select = "";
        public static List<AddressBook> People;

        public static void Choice()
        {
            Select = "";
            Console.WriteLine("Enter 'add' if u want to Add a contact");
            Console.WriteLine("Enter 'edit' if u want to Edit a contact");
            ChoiceSelector();
        }
        public static void ChoiceSelector()
        {

            while (Select != "stop")
            {
                Select = Console.ReadLine().ToLower();
                switch (Select)
                {
                    case "add":
                        AddPerson();
                        break;

                    case "edit":
                        Edit();
                        break;
                }
            }
        }
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
        public static void Edit()
        {
            int counter = 0;
            AddressBook person = new AddressBook();
            Console.WriteLine("Enter the first name of the person to be edited :");
            String NameFirst = Console.ReadLine().ToLower();
            foreach (var data in People)
            {
                counter++;
                if (data.FirstName.ToLower() == NameFirst)
                {
                    Console.WriteLine("What do you want to edit: FirstName,Lastname,Address,City,State,PhoneNumber,Zip or EmailId");
                    String CheckEdit = Console.ReadLine().ToLower();
                    if (CheckEdit == "firstname")
                        data.FirstName = Console.ReadLine();
                    if (CheckEdit == "lastname")
                        data.LastName = Console.ReadLine();
                    if (CheckEdit == "addressname")
                        data.Address = Console.ReadLine();
                    if (CheckEdit == "city")
                        data.City = Console.ReadLine();
                    if (CheckEdit == "state")
                        data.State = Console.ReadLine();
                    if (CheckEdit == "phonenumber")
                        data.PhoneNumber = Console.ReadLine();
                    if (CheckEdit == "zip")
                        data.Zip = Console.ReadLine();
                    if (CheckEdit == "emailid")
                    {
                        data.Email = Console.ReadLine();
                    }
                }
                else
                {
                    if (counter == People.Count)
                        Console.WriteLine("The contact doesnt exist");
                }
            }
            Console.WriteLine("DATA EDITED!!");
            Console.WriteLine("********************************************************");
            Console.WriteLine("Enter your Choice!");
        }
    }
}

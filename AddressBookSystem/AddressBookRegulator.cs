using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBookSystem
{
    public class AddressBookRegulator
    {
        public static int countPersonByState = 0;
        public static int countPersonByCity = 0;
        public static Dictionary<string, List<AddressBook>> Dict = new Dictionary<string, List<AddressBook>>();
        public static Dictionary<string, List<AddressBook>> States = new Dictionary<string, List<AddressBook>>();
        public static Dictionary<string, List<AddressBook>> Cities = new Dictionary<string, List<AddressBook>>();
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
            Console.WriteLine("Enter 'search' to search person by city or state");
            Console.WriteLine("Enter 'show' to display persons in cities and state");
            Console.WriteLine("Enter 'count' to display number of persons living in cities and state");
            Console.WriteLine("Enter 'stop' to stop");
            while (Select != "stop")
            {
                Select = Console.ReadLine().ToLower();
                switch (Select)
                {
                    case "dict":
                        DisplayDictionaries();
                        break;

                    case "search":
                        SearchPersonByCityOrState();
                        break;

                    case "show":
                        ShowPersonsByCityOrState();
                        break;

                    case "count":
                        CountPerson();
                        break;
                }
            }
        }
        public static void DisplayDictionaries()
        {
            foreach (KeyValuePair<string, List<AddressBook>> kvp in AddressBookRegulator.Dict)
            {
                Console.WriteLine("Dictionary Name is :" + kvp.Key);
                foreach (var person in kvp.Value.OrderBy(x => x.FirstName))
                {
                    Console.WriteLine("Value of Dictionary " + kvp.Key + " is :");
                    AddressBookMain.Display(person);
                }
            }
        }
        public static void SearchPersonByCityOrState()
        {
            string checkStateOrCity = "";
            AddressBook person = new AddressBook();
            Console.WriteLine("Enter Your 'City' ot 'State' :");
            checkStateOrCity = Console.ReadLine().ToLower();
            switch (checkStateOrCity)
            {
                case "city":
                    int count = 0;
                    Console.WriteLine("Enter City Name :");
                    string cityName = Console.ReadLine();
                    foreach (KeyValuePair<string, List<AddressBook>> kvp in AddressBookRegulator.Dict)
                    {
                        var checkCity = kvp.Value.Any(item => item.City.Equals(cityName));
                        if (checkCity)
                        {
                            var result = kvp.Value.Where(x => x.City.Contains(cityName));
                            foreach (var item in result)
                            {
                                count++;
                                Console.WriteLine(item.FirstName);
                            }
                        }
                        else
                        {
                            if (count == 0)
                                Console.WriteLine("City not Found!");
                        }
                    }
                    break;


                case "state":
                    int count1 = 0;
                    Console.WriteLine("Enter State Name :");
                    string stateName = Console.ReadLine();
                    foreach (KeyValuePair<string, List<AddressBook>> kvp in AddressBookRegulator.Dict)
                    {
                        var checkState = kvp.Value.Any(item => item.State.Equals(stateName));
                        if (checkState)
                        {
                            var result = kvp.Value.Where(x => x.State.Contains(stateName));
                            foreach (var item in result)
                            {
                                count1++;
                                Console.WriteLine(item.FirstName);
                            }
                        }
                        else
                        {
                            if (count1 == 0)
                                Console.WriteLine("State not Found!");
                        }
                    }
                    break;

                default:
                    Console.WriteLine("Wrong Input!");
                    break;
            }
        }
        public static void ShowPersonsByCityOrState()
        {
            foreach (KeyValuePair<string, List<AddressBook>> kvp in AddressBookRegulator.Cities)
            {
                Console.WriteLine("City is :" + kvp.Key);
                Console.WriteLine("Deatils of the Persons Staying in the Same City :");
                foreach (var item in kvp.Value)
                {
                    if (item.City.Equals(kvp.Key))
                    {
                        AddressBookMain.Display(item);
                    }
                }
            }
            foreach (KeyValuePair<string, List<AddressBook>> kvp in AddressBookRegulator.States)
            {
                Console.WriteLine("State is :" + kvp.Key);
                Console.WriteLine("Deatils of the Persons Staying in the Same State :");
                foreach (var item in kvp.Value)
                {
                    if (item.State.Equals(kvp.Key))
                    {
                        AddressBookMain.Display(item);
                    }
                }
            }
        }
        public static void CountPerson()
        {
            foreach (KeyValuePair<string, List<AddressBook>> kvp in AddressBookRegulator.Cities)
            {
                foreach (var item in kvp.Value)
                {
                    if (item.City.Equals(kvp.Key))
                    {
                        countPersonByCity++;
                    }
                }                
                Console.WriteLine("Persons Living in City " + kvp.Key + " " + countPersonByCity);             
                countPersonByCity = 0;
            }
            foreach (KeyValuePair<string, List<AddressBook>> kvp in AddressBookRegulator.States)
            {
                foreach (var item in kvp.Value)
                {
                    if (item.State.Equals(kvp.Key))
                    {
                        countPersonByState++;
                    }
                }               
                Console.WriteLine("Persons Living in State " + kvp.Key + " " + countPersonByState);               
                countPersonByState = 0;
            }
        }
    }
}












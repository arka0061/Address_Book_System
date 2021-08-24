using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AddressBookSystem
{
    public class FileOperation
    {
        public static readonly string writerFile = @"E:\Bridglabz\Address_Book_System\AddressBookSystem\WriterFile.txt";
        public static readonly string readerFile = @"E:\Bridglabz\Address_Book_System\AddressBookSystem\ReaderFile.txt";

        public static void WriteToFile()
        {
            if (File.Exists(writerFile))
            {
                StreamWriter writer = new StreamWriter(writerFile);
                foreach (KeyValuePair<string, List<AddressBook>> kvp in AddressBookRegulator.Dict)
                {
                    writer.WriteLine("Dictionary Name is :" + kvp.Key);
                    foreach (var person in kvp.Value.OrderBy(x => x.FirstName))
                    {
                        writer.WriteLine("Value of Dictionary " + kvp.Key + " is :");
                        writer.WriteLine("First Name : " + person.FirstName);
                        writer.WriteLine("Last Name : " + person.LastName);
                        writer.WriteLine("Address : " + person.Address);
                        writer.WriteLine("City : " + person.City);
                        writer.WriteLine("State : " + person.State);
                        writer.WriteLine("Phone Number : " + person.PhoneNumber);
                        writer.WriteLine("Zip : " + person.Zip);
                        writer.WriteLine("Email : " + person.Email);
                        writer.WriteLine("----------------------------------------------------------------------");
                    }
                }
                writer.Close();
                Console.WriteLine("DATA WRITTEN ON ReaderFile.txt Sucessfully!");
            }
            else
            {
                Console.WriteLine("File not exists");
            }
        }
        public static void ReadFromFile()
        {
            string[] lines = File.ReadAllLines(readerFile);
            int counter = 0;
            AddressBook person = new AddressBook();
            for (int i = 0; i <lines.Length; i++)
            {
                counter++;             
                if (lines[i].Contains("FirstName:"))
                    person.FirstName = lines[i].Substring(lines[i].IndexOf(':')+1);
                if (lines[i].Contains("LastName:"))
                    person.LastName = lines[i].Substring(lines[i].IndexOf(':')+1);
                if (lines[i].Contains("Address:"))
                    person.Address = lines[i].Substring(lines[i].IndexOf(':')+1);
                if (lines[i].Contains("City:"))
                    person.City = lines[i].Substring(lines[i].IndexOf(':')+1);
                if (lines[i].Contains("State:"))
                    person.State = lines[i].Substring(lines[i].IndexOf(':')+1);
                if (lines[i].Contains("PhoneNumber:"))
                    person.PhoneNumber = (int.Parse(lines[i].Substring(lines[i].IndexOf(':')+1)));
                if (lines[i].Contains("Zip:"))
                    person.Zip = (int.Parse(lines[i].Substring(lines[i].IndexOf(':') + 1)));
                if (lines[i].Contains("Email:"))
                    person.Email = lines[i].Substring(lines[i].IndexOf(':') + 1);
                if (counter == 8)
                {
                    AddressBookMain.People.Add(person);
                    person = new AddressBook();
                    counter = 0;
                }
            }
            Console.WriteLine("DATA ADDED!");
            Console.WriteLine("*************************************************************************");
            Console.WriteLine("Enter your Choice!");
        }
    }
}


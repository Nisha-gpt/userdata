using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Newtonsoft.Json;
using userdata.Models;

namespace userdata
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Read users from sample.xml
            Console.WriteLine("Reading users from sample.xml:\n");

            XmlDocument doc = new XmlDocument();
            doc.Load("sample.xml");

            XmlNodeList userNodes = doc.SelectNodes("/Users/User");

            foreach (XmlNode user in userNodes)
            {
                string name = user["Name"]?.InnerText;
                string age = user["Age"]?.InnerText;
                string city = user["City"]?.InnerText;
                string nationality = user["Nationality"]?.InnerText;
                string phone = user["Contact"]?["Phone"]?.InnerText;
                string email = user["Contact"]?["Email"]?.InnerText;

                Console.WriteLine($"Name: {name}");
                Console.WriteLine($"Age: {age}");
                Console.WriteLine($"City: {city}");
                Console.WriteLine($"Nationality: {nationality}");
                Console.WriteLine($"Phone: {phone}");
                Console.WriteLine($"Email: {email}");
                Console.WriteLine("---------------------------");
            }

            // 2. Add new user to users.json
            Console.WriteLine("\nEnter new user details:");

            Console.Write("Name: ");
            string newName = Console.ReadLine();

            Console.Write("Age: ");
            int newAge = int.Parse(Console.ReadLine());

            Console.Write("City: ");
            string newCity = Console.ReadLine();

            Console.Write("Nationality: ");
            string newNationality = Console.ReadLine();

            Console.Write("Phone: ");
            string newPhone = Console.ReadLine();

            Console.Write("Email: ");
            string newEmail = Console.ReadLine();

            var newUser = new User
            {
                Name = newName,
                Age = newAge,
                City = newCity,
                Nationality = newNationality,
                Contact = new ContactDetails
                {
                    Phone = newPhone,
                    Email = newEmail
                }
            };

            string jsonPath = "users.json";
            List<User> users = new List<User>();

            if (File.Exists(jsonPath))
            {
                string existingJson = File.ReadAllText(jsonPath);
                users = JsonConvert.DeserializeObject<List<User>>(existingJson) ?? new List<User>();
            }

            users.Add(newUser);
string updatedJson = JsonConvert.SerializeObject(users, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(jsonPath, updatedJson);

            Console.WriteLine("\n✅ New user added successfully to users.json!");

            // 3. Display all users from users.json
            Console.WriteLine("\nAll Users in users.json:\n");

            if (File.Exists("users.json"))
            {
                string json = File.ReadAllText("users.json");
                var allUsers = JsonConvert.DeserializeObject<List<User>>(json);

                foreach (var user in allUsers)
                {
                    Console.WriteLine($"Name: {user.Name}");
                    Console.WriteLine($"Age: {user.Age}");
                    Console.WriteLine($"City: {user.City}");
                    Console.WriteLine($"Nationality: {user.Nationality}");
                    Console.WriteLine($"Phone: {user.Contact?.Phone}");
                    Console.WriteLine($"Email: {user.Contact?.Email}");
                    Console.WriteLine("------------------------------");
                }
            }
            else
            {
                Console.WriteLine("users.json file not found.");
            }
        }
    }
}

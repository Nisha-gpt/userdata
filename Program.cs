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
            // --- V2: XML Reader ---
            Console.WriteLine("✅ V2: Reading users from sample.xml\n");

            XmlDocument doc = new XmlDocument();
            doc.Load("sample.xml");

            XmlNodeList userNodes = doc.SelectNodes("/Users/User");

            foreach (XmlNode user in userNodes)
            {
                string? name = user["Name"]?.InnerText;
                string? age = user["Age"]?.InnerText;
                string? city = user["City"]?.InnerText;
                string? nationality = user["Nationality"]?.InnerText;
                string? phone = user["Contact"]?["Phone"]?.InnerText;
                string? email = user["Contact"]?["Email"]?.InnerText;

                Console.WriteLine($"Name: {name}");
                Console.WriteLine($"Age: {age}");
                Console.WriteLine($"City: {city}");
                Console.WriteLine($"Nationality: {nationality}");
                Console.WriteLine($"Phone: {phone}");
                Console.WriteLine($"Email: {email}");
                Console.WriteLine("---------------------------");
            }

            // --- V3: Add new user to users.json ---
            Console.WriteLine("\n📝 Enter new user details:");

            Console.Write("Name: ");
            string? nameInput = Console.ReadLine();

            Console.Write("Age: ");
            int ageInput = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("City: ");
            string? cityInput = Console.ReadLine();

            Console.Write("Nationality: ");
            string? nationalityInput = Console.ReadLine();

            Console.Write("Phone: ");
            string? phoneInput = Console.ReadLine();

            Console.Write("Email: ");
            string? emailInput = Console.ReadLine();

            var newUser = new User
            {
                Name = nameInput,
                Age = ageInput,
                City = cityInput,
                Nationality = nationalityInput,
                Contact = new ContactDetails
                {
                    Phone = phoneInput,
                    Email = emailInput
                }
            };

            string jsonPath = "users.json";
            var users = new List<User>();

            if (File.Exists(jsonPath))
            {
                string existingJson = File.ReadAllText(jsonPath);
                users = JsonConvert.DeserializeObject<List<User>>(existingJson) ?? new List<User>();
            }

            users.Add(newUser);

            string updatedJson = JsonConvert.SerializeObject(users, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(jsonPath, updatedJson);

            Console.WriteLine("\n✅ User added successfully to users.json!");

            // --- V4: Display all users from users.json ---
            Console.WriteLine("\n📋 All Users in users.json:\n");

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
                    Console.WriteLine("---------------------------");
                }
            }
            else
            {
                Console.WriteLine("❌ users.json not found.");
            }

            // --- V5: Deserialize Admin & RegularUser from users_extended.json ---
            Console.WriteLine("\n✅ V5: Reading users_extended.json with inheritance:\n");

            if (File.Exists("users_extended.json"))
            {
                string json = File.ReadAllText("users_extended.json");
                var rawList = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(json);

                foreach (var item in rawList)
                {
                    string userType = item["UserType"].ToString();
                    string userJson = JsonConvert.SerializeObject(item);

                    if (userType == "Admin")
                    {
                        var admin = JsonConvert.DeserializeObject<Admin>(userJson);
                        Console.WriteLine($"[ADMIN] {admin.Name}, Level {admin.AdminLevel} – {admin.Contact?.Email}");
                    }
                    else if (userType == "RegularUser")
                    {
                        var user = JsonConvert.DeserializeObject<RegularUser>(userJson);
                        Console.WriteLine($"[USER] {user.Name}, Subscription: {user.SubscriptionStatus} – {user.Contact?.Email}");
                    }

                    Console.WriteLine("---------------------------");
                }
            }
            else
            {
                Console.WriteLine("❌ users_extended.json not found.");
            }

            Console.ReadLine(); // Keeps console open
        }
    }
}

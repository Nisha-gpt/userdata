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
            Console.WriteLine("✅ V3: Add a new user to users.json\n");

            // Get user input
            Console.Write("Enter Name: ");
            string? name = Console.ReadLine();

            Console.Write("Enter Age: ");
            int age = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Enter City: ");
            string? city = Console.ReadLine();

            Console.Write("Enter Nationality: ");
            string? nationality = Console.ReadLine();

            Console.Write("Enter Phone: ");
            string? phone = Console.ReadLine();

            Console.Write("Enter Email: ");
            string? email = Console.ReadLine();

            // Create a new User object
            var newUser = new User
            {
                Name = name,
                Age = age,
                City = city,
                Nationality = nationality,
                Contact = new ContactDetails
                {
                    Phone = phone,
                    Email = email
                }
            };

            // Load existing users from users.json
            string path = "users.json";
            var users = new List<User>();

            if (File.Exists(path))
            {
                string existingJson = File.ReadAllText(path);
                users = JsonConvert.DeserializeObject<List<User>>(existingJson) ?? new List<User>();
            }

            // Add the new user
            users.Add(newUser);

            // Save updated users back to users.json
            string updatedJson = JsonConvert.SerializeObject(users, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(path, updatedJson);

            Console.WriteLine("\n✅ User added successfully!");
            Console.ReadLine();
        }
    }
}

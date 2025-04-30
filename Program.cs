using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using userdata.Models;

namespace userdata
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("✅ V4: Displaying all users from users.json\n");

            string path = "users.json";

            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                var users = JsonConvert.DeserializeObject<List<User>>(json);

                foreach (var user in users)
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
                Console.WriteLine("❌ users.json file not found.");
            }

            Console.ReadLine(); // Keeps the window open
        }
    }
}

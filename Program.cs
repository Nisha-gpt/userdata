using System;
using System.Xml;

namespace userdata
{
    class Program
    {
        static void Main(string[] args)
        {
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
        }
    }
}

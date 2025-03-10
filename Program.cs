// dotnet add package Dumpify
using Dumpify;
using System.IO.Compression;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;



class Program
{
    static void Main()
    {
        LinqChallenge1.Run();
        LinqChallenge2.Run();
        var users = new List<User>
{
    new User { Name = "Anna Müller", Email = "anna@example.com" },
    new User { Name = "Jonas Meier", Email = "jonas@example.com" },
    new User { Name = "Lena Schmidt", Email = "lena@example.com" }
};

        var orders = new List<Order>
{
    new Order { OrderId = 1, OrderDate = new DateTime(2023, 1, 10), TotalAmount = 500m, UserEmail = "anna@example.com" },
    new Order { OrderId = 2, OrderDate = new DateTime(2023, 2, 5), TotalAmount = 800m, UserEmail = "anna@example.com" },
    new Order { OrderId = 3, OrderDate = new DateTime(2023, 3, 15), TotalAmount = 400m, UserEmail = "jonas@example.com" },
    new Order { OrderId = 4, OrderDate = new DateTime(2023, 4, 20), TotalAmount = 560m, UserEmail = "jonas@example.com" },
    new Order { OrderId = 5, OrderDate = new DateTime(2024, 1, 10), TotalAmount = 750m, UserEmail = "anna@example.com" },
    new Order { OrderId = 6, OrderDate = new DateTime(2024, 2, 14), TotalAmount = 680m, UserEmail = "lena@example.com" },
    new Order { OrderId = 7, OrderDate = new DateTime(2024, 3, 22), TotalAmount = 720m, UserEmail = "lena@example.com" }
};
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        string json = File.ReadAllText("people.json");
        //List<Person> people = JsonSerializer.Deserialize<List<Person>>(json, options);

        //var result = people.Where(x => x.city?.StartsWith("A") ?? false).Select(x => x.city);
        // Berechne für jeden Benutzer den durchschnittlichen Bestellbetrag pro Jahr.
       

        //result.Dump();
    }
    
}


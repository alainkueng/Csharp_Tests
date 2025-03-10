// LinqChallenge1.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using Dumpify;



public static class LinqChallenge1
{
    // Methode, die alles erledigt
    public static void Run()
    {
        Console.WriteLine("Linq Challenge – Top Kunde pro Jahr");

        // Beispiel-Daten
        var users = new List<User>
        {
            new User { Name = "Anna Müller", Email = "anna@example.com" },
            new User { Name = "Jonas Meier", Email = "jonas@example.com" },
            new User { Name = "Lena Schmidt", Email = "lena@example.com" }
        };

        var orders = new List<Order>
        {
            new Order { OrderId = 1, OrderDate = new DateTime(2023, 1, 10), TotalAmount = 500m, UserEmail = "anna@example.com" },
            new Order { OrderId = 2, OrderDate = new DateTime(2023, 2, 5), TotalAmount = 2200m, UserEmail = "anna@example.com" },
            new Order { OrderId = 3, OrderDate = new DateTime(2023, 3, 15), TotalAmount = 400m, UserEmail = "jonas@example.com" },
            new Order { OrderId = 4, OrderDate = new DateTime(2023, 4, 20), TotalAmount = 560m, UserEmail = "jonas@example.com" },
            new Order { OrderId = 5, OrderDate = new DateTime(2024, 1, 10), TotalAmount = 750m, UserEmail = "anna@example.com" },
            new Order { OrderId = 6, OrderDate = new DateTime(2024, 2, 14), TotalAmount = 680m, UserEmail = "lena@example.com" },
            new Order { OrderId = 7, OrderDate = new DateTime(2024, 3, 22), TotalAmount = 720m, UserEmail = "lena@example.com" },
            new Order { OrderId = 8, OrderDate = new DateTime(2024, 4, 5), TotalAmount = 3050m, UserEmail = "jonas@example.com" }
        };

        // Finde pro Jahr den Kunden mit dem höchsten Gesamtumsatz (also Summe aller Orders des Kunden in dem Jahr).
        var topCustomersPerYear = orders
            .GroupBy(order => order.OrderDate.Year)
            .Select(yearGroup =>
            {
                var userSums = yearGroup
                    .GroupBy(o => o.UserEmail)
                    .Select(userGroup => new
                    {
                        Year = yearGroup.Key,
                        UserEmail = userGroup.Key,
                        TotalSum = userGroup.Sum(o => o.TotalAmount)
                    })
                    .OrderByDescending(x => x.TotalSum)
                    .First();

                var user = users.FirstOrDefault(u => u.Email == userSums.UserEmail);

                return new
                {
                    Year = userSums.Year,
                    UserName = user?.Name ?? "Unbekannt",
                    TotalSum = userSums.TotalSum
                };
            });

        // Ausgabe
        foreach (var result in topCustomersPerYear)
        {
            Console.WriteLine($"Year: {result.Year}, Top Customer: {result.UserName}, Total Sales: {result.TotalSum}");
        }

        // „Finde pro Jahr den durchschnittlichen Bestellwert pro Benutzer und gib alle Benutzer aus, deren durchschnittlicher Wert über 600 liegt.“
        // Version 1
        var averageSpendover600 = orders
            .GroupBy(order => order.OrderDate.Year)
            .Select(yearGroup =>
            {
                var averageSpends = yearGroup
                    .GroupBy(o => o.UserEmail)
                    .Select(userGroup => new
                    {
                        Year = yearGroup.Key,
                        UserEmail = userGroup.Key,
                        averageSpend = userGroup.Average(o => o.TotalAmount)
                    })
                    .Where(x => x.averageSpend > 600);


                return averageSpends;
            });

        // Version 2
        var averageSpendover600again = orders
            .GroupBy(order => order.OrderDate.Year) // Gruppieren nach Jahr
            .SelectMany(yearGroup => // Wir flachen die Gruppen auf
            {
                return yearGroup
                    .GroupBy(o => o.UserEmail) // Gruppieren nach UserEmail
                    .Where(userGroup => userGroup.Average(o => o.TotalAmount) > 600) // Filtern der User, deren Durchschnitt > 600 ist
                    .Select(userGroup => new
                    {
                        Year = yearGroup.Key, // Jahr
                        UserEmail = userGroup.Key, // User-Email
                        AverageSpend = userGroup.Average(o => o.TotalAmount) // Durchschnittlicher Spend
                    });
            });

        // filter customers who have a total spend greater than 2000.
        var top3customers = orders
            .GroupBy(order => order.UserEmail)  // Group by UserEmail (each user)
            .Select(sums => new
            {
                User = users.First(x => x.Email == sums.Key).Name, // User's email
                Spend = sums.Sum(userGroup => userGroup.TotalAmount) // Sum of the total amount spent by the user
            })
            .Where(x => x.Spend > 2000)  // Filter users who spent more than 2000
            .OrderByDescending(x => x.Spend)  // Order by total spend in descending order
            .Take(3)  // Get top 3 customers
            .ToList();  // Convert to list if needed

        

        // berechne für jede Besellung ob die Besellung teurer als 1000 war
        var crazyorders = orders
            .Where(order => order.TotalAmount > 1000) // Filter orders that are > 1000
            .GroupBy(order => order.UserEmail) // Group orders by UserEmail
            .Select(group => new {
                User = group.Key, // Get the UserEmail from the group
                count = group.Count(), // Count the number of orders > 1000 for each user
                totalAmount = group.Sum(order => order.TotalAmount) // Sum the total amount for each user
            })
            ; // Display the results
        
        var averageorders = orders
            .GroupBy(order =>order.OrderDate.Year).Select(group => new {
                Year = group.Key,
                Amount = group.Average(o => o.TotalAmount)
            }).Where(t => t.Amount >500);

        var howmanystuff = orders
            .GroupBy(order => order.UserEmail)
            .Select(usergroup=> new {
                Mail = usergroup.Key,
                User = users.First(u=>u.Email == usergroup.Key).Name,
                Amount = usergroup.Count()


        }
        ).OrderByDescending(o=>o.Amount)
        .Take(3);

        var totalspend = orders
            .GroupBy(order => order.UserEmail)
            .Select(usergroup=> new
            {
                email = usergroup.Key,
                user = users.FirstOrDefault(u => u.Email == usergroup.Key)?.Name ?? null,
                amount = usergroup.Sum(s => s.TotalAmount)
            }
        
        ).OrderByDescending(o=>o.amount).Take(3);

        var countering = orders
            .GroupBy(order=>order.UserEmail)
            .Select(usergroup => new
            {
                user= usergroup.Key,
                counter = usergroup.Count(),
            }).OrderByDescending(o=>o.counter).Take(3).Dump();
    }
}
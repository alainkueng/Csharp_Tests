using System;
using System.Collections.Generic;
using System.Linq;

public class Product2
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}

public class User2
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}

public class Order2
{
    public int OrderId { get; set; }
    public int UserId { get; set; }
    public DateTime OrderDate { get; set; }
}

public class OrderItem2
{
    public int OrderItemId { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}

public static class LinqChallenge2
{
    // Method that does everything
    public static void Run()
    {
        // Sample Products Data
        var products2 = new List<Product2>
        {
            new Product2 { ProductId = 1, Name = "Laptop", Price = 1000 },
            new Product2 { ProductId = 2, Name = "Smartphone", Price = 500 },
            new Product2 { ProductId = 3, Name = "Tablet", Price = 300 }
        };

        // Sample Users Data
        var users2 = new List<User2>
        {
            new User2 { UserId = 1, Name = "John Doe", Email = "john.doe@example.com" },
            new User2 { UserId = 2, Name = "Jane Smith", Email = "jane.smith@example.com" },
            new User2 { UserId = 3, Name = "Alice Johnson", Email = "alice.johnson@example.com" }
        };

        // Sample Orders Data
        var orders2 = new List<Order2>
        {
            new Order2 { OrderId = 1, UserId = 1, OrderDate = new DateTime(2025, 1, 10) },
            new Order2 { OrderId = 2, UserId = 2, OrderDate = new DateTime(2025, 2, 5) },
            new Order2 { OrderId = 3, UserId = 3, OrderDate = new DateTime(2025, 3, 15) },
            new Order2 { OrderId = 4, UserId = 1, OrderDate = new DateTime(2025, 4, 10) }
        };

        // Sample OrderItems Data
        var orderItems2 = new List<OrderItem2>
        {
            new OrderItem2 { OrderItemId = 1, OrderId = 1, ProductId = 1, Quantity = 2 },
            new OrderItem2 { OrderItemId = 2, OrderId = 1, ProductId = 2, Quantity = 1 },
            new OrderItem2 { OrderItemId = 3, OrderId = 2, ProductId = 3, Quantity = 1 },
            new OrderItem2 { OrderItemId = 4, OrderId = 3, ProductId = 2, Quantity = 3 },
            new OrderItem2 { OrderItemId = 5, OrderId = 4, ProductId = 1, Quantity = 1 }
        };

        var letsdoit = users2.Join(orders2, u=>u.UserId, p=>p.ProductId, (u, p) => (u.UserId, p.))

    }
}

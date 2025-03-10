public class Order
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string UserEmail { get; set; }
}

public class User
{
    public string Name { get; set; }
    public string Email { get; set; }
}
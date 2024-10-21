namespace FinanceTracker.Api.Models;

public class TransactionEntity
{
    public TransactionEntity(
        string name,
        string category,
        string description,
        decimal price
    )
    {
        Name = name;
        Category = category;
        Description = description;
        Price = price;
        TransactionDate = new(
            DateTime.UtcNow.Year,
            DateTime.UtcNow.Month,
            DateTime.UtcNow.Day
        );
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public DateOnly TransactionDate { get; set; }
}

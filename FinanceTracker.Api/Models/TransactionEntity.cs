namespace FinanceTracker.Api.Models;

public class TransactionEntity
{
    public TransactionEntity() { }

    public TransactionEntity(
        string name,
        string category,
        string description,
        decimal price,
        int year,
        int month,
        int day
    )
    {
        Name = name;
        Category = category;
        Description = description;
        Price = price;
        TransactionDate = new DateOnly(year, month, day);
    }

    public Guid Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Category { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public decimal Price { get; set; }
    public DateOnly TransactionDate { get; set; } =
        new(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day);
}

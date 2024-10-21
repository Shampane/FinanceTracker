using FinanceTracker.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Api.DataAccess;

public class FinanceDbContext : DbContext
{
    public FinanceDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public DbSet<TransactionEntity> Transactions { get; set; }
    private readonly IConfiguration _configuration;

    protected override void OnConfiguring(
        DbContextOptionsBuilder options
    )
    {
        options.UseNpgsql(
            _configuration.GetConnectionString("Database")
        );
    }
}

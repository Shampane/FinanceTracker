using FinanceTracker.Api.DataAccess;
using FinanceTracker.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Api.Repositories;

public class TransactionsRepository : ITransactionsRepository
{
    public TransactionsRepository(FinanceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    private readonly FinanceDbContext _dbContext;

    public async Task<IEnumerable<TransactionEntity>> GetEntities()
    {
        var list = await _dbContext
            .Transactions.AsNoTracking()
            .ToListAsync();
        return list;
    }

    public async Task InsertEntity(TransactionEntity entity)
    {
        await _dbContext.Transactions.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task RemoveEntity(TransactionEntity entity)
    {
        _dbContext.Transactions.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<TransactionEntity?> SearchEntityById(Guid id)
    {
        TransactionEntity? entity =
            await _dbContext.Transactions.FindAsync(id);
        return entity;
    }
}

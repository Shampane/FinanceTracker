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
        var list = await _dbContext.Transactions.AsNoTracking().ToListAsync();
        return list;
    }

    public async Task InsertEntity(TransactionEntity entity)
    {
        await _dbContext.Transactions.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateEntity(
        TransactionEntity entity,
        TransactionEntity updateEntity
    )
    {
        entity.Name = updateEntity.Name;
        entity.Category = updateEntity.Category;
        entity.Description = updateEntity.Description;
        entity.Price = updateEntity.Price;

        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task RemoveEntity(TransactionEntity entity)
    {
        _dbContext.Transactions.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<TransactionEntity?> SearchEntityById(Guid id)
    {
        TransactionEntity? entity = await _dbContext.Transactions.FindAsync(id);
        return entity;
    }

    public async Task<IEnumerable<TransactionEntity>> SearchEntities(
        string? searchName,
        string? searchCategory
    )
    {
        var query = _dbContext.Transactions.AsNoTracking().AsQueryable();
        if (!string.IsNullOrEmpty(searchName))
            query = query.Where(e =>
                e.Name.ToLower().StartsWith(searchName.ToLower())
            );
        if (!string.IsNullOrEmpty(searchCategory))
            query = query.Where(e =>
                e.Category.ToLower().StartsWith(searchCategory.ToLower())
            );
        var list = await query.ToListAsync();
        return list;
    }
}

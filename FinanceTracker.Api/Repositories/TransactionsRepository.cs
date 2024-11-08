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

    public async Task<IEnumerable<TransactionEntity>> GetEntitiesWithConditions(
        string? searchName,
        string? searchCategory,
        string? sortType,
        string? sortOrder,
        uint? limitSize,
        uint? limitPage
    )
    {
        var query = _dbContext.Transactions.AsNoTracking().AsQueryable();
        query = query.OrderByDescending(e => e.TransactionDate);

        if (!string.IsNullOrEmpty(sortType))
        {
            if (
                !string.IsNullOrEmpty(sortOrder)
                && (
                    sortOrder.ToLower() == "asc"
                    || sortOrder.ToLower() == "desc"
                )
            )
            {
                bool isDesc =
                    sortOrder.ToLower() == "desc"
                        ? sortOrder.ToLower() == "desc"
                        : false;

                query = sortType.ToLower() switch
                {
                    "category"
                        => isDesc
                            ? query.OrderByDescending(e => e.Category)
                            : query.OrderBy(e => e.Category),
                    "price"
                        => isDesc
                            ? query.OrderByDescending(e => e.Price)
                            : query.OrderBy(e => e.Price),
                    "date"
                        => isDesc
                            ? query.OrderByDescending(e => e.TransactionDate)
                            : query.OrderBy(e => e.TransactionDate),
                    _ => query
                };
            }
            else if (sortOrder == null)
            {
                query = sortType.ToLower() switch
                {
                    "category" => query.OrderBy(e => e.Category),
                    "price" => query.OrderBy(e => e.Price),
                    "date" => query.OrderBy(e => e.TransactionDate),
                    _ => query
                };
            }
            else
            {
                return new List<TransactionEntity>();
            }
        }

        if (limitSize != null)
        {
            if (limitPage != null)
                query = query
                    .Skip((int)limitSize * (int)(limitPage - 1))
                    .Take((int)limitSize);
            else
                query = query.Take((int)limitSize);
        }

        if (!string.IsNullOrEmpty(searchName))
            query = query.Where(e =>
                e.Name.ToLower().Contains(searchName.ToLower())
            );
        if (!string.IsNullOrEmpty(searchCategory))
            query = query.Where(e =>
                e.Category.ToLower().Contains(searchCategory.ToLower())
            );

        var list = await query.ToListAsync();
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
        entity.TransactionDate = updateEntity.TransactionDate;

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
}

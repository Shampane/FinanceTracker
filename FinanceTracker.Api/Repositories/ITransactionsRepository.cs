using FinanceTracker.Api.Models;

namespace FinanceTracker.Api.Repositories;

public interface ITransactionsRepository
{
    Task<IEnumerable<TransactionEntity>> GetEntities();
    Task<IEnumerable<TransactionEntity>> GetEntitiesWithConditions(
        string? searchName,
        string? searchCategory,
        string? sortType,
        string? sortOrder
    );
    Task InsertEntity(TransactionEntity entity);
    Task UpdateEntity(TransactionEntity entity, TransactionEntity updateEntity);
    Task RemoveEntity(TransactionEntity entity);
    Task<TransactionEntity?> SearchEntityById(Guid id);
}

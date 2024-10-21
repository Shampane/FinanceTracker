using FinanceTracker.Api.Models;

namespace FinanceTracker.Api.Repositories;

public interface ITransactionsRepository
{
    Task<IEnumerable<TransactionEntity>> GetEntities();
    Task InsertEntity(TransactionEntity entity);
    Task RemoveEntity(TransactionEntity entity);
    Task<TransactionEntity?> SearchEntityById(Guid id);
}

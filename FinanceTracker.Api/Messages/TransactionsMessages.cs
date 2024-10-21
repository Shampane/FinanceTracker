using FinanceTracker.Api.Models;

namespace FinanceTracker.Api.Messages;

public record TransactionsCreateRequest(
    string Name,
    string Category,
    string Description,
    decimal Price
);

public record TransactionsCreateResponse(
    IEnumerable<TransactionEntity?> List
);

public record TransactionsUpdateRequest(
    string Name,
    string Category,
    string Description,
    decimal Price
);

public record TransactionsDeleteRequest(Guid Id);

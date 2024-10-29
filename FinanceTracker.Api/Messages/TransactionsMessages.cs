using FinanceTracker.Api.Models;

namespace FinanceTracker.Api.Messages;

public record TransactionsGetRequest(
    Guid Id,
    string? SearchName,
    string? SearchCategory,
    string? SortType,
    string? SortOrder
);

public record TransactionsCreateRequest(
    string Name,
    string Category,
    string Description,
    decimal Price,
    int Year,
    int Month,
    int Day
);

public record TransactionsCreateResponse(IEnumerable<TransactionEntity?> List);

public record TransactionsUpdateRequest(
    string Name,
    string Category,
    string Description,
    decimal Price,
    int Year,
    int Month,
    int Day
);

public record TransactionsDeleteRequest(Guid Id);

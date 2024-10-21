using System.Transactions;
using FinanceTracker.Api.DataAccess;
using FinanceTracker.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TransactionsController : ControllerBase
{
    public TransactionsController(FinanceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    private readonly FinanceDbContext _dbContext;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var list = await _dbContext
            .Transactions.AsNoTracking()
            .ToListAsync();
        return Ok(list);
    }

    [HttpPost]
    public async Task<IActionResult> Post(
        string name,
        string category,
        decimal price
    )
    {
        TransactionEntity entity = new(name, category, price);
        await _dbContext.Transactions.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Remove(Guid id)
    {
        TransactionEntity? entity =
            await _dbContext.Transactions.FindAsync(id);
        if (entity == null)
        {
            return NotFound();
        }
        return Ok();
    }
}

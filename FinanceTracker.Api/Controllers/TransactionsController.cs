using FinanceTracker.Api.Messages;
using FinanceTracker.Api.Models;
using FinanceTracker.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTracker.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TransactionsController : ControllerBase
{
    public TransactionsController(ITransactionsRepository repository)
    {
        _repository = repository;
    }

    private readonly ITransactionsRepository _repository;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var list = await _repository.GetEntities();
        return Ok(new TransactionsCreateResponse(list));
    }

    [HttpPost]
    public IActionResult Create(
        [FromBody] TransactionsCreateRequest request
    )
    {
        TransactionEntity entity =
            new(
                request.Name,
                request.Category,
                request.Description,
                request.Price
            );

        _repository.InsertEntity(entity);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update(
        [FromQuery] Guid id,
        [FromBody] TransactionsUpdateRequest request
    )
    {
        var entity = await _repository.SearchEntityById(id);
        if (entity == null)
        {
            return NotFound();
        }

        TransactionEntity updateEntity =
            new(
                request.Name,
                request.Category,
                request.Description,
                request.Price
            );

        await _repository.UpdateEntity(entity, updateEntity);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(
        [FromQuery] TransactionsDeleteRequest request
    )
    {
        var entity = await _repository.SearchEntityById(request.Id);
        if (entity == null)
        {
            return NotFound();
        }
        await _repository.RemoveEntity(entity);
        return Ok();
    }
}

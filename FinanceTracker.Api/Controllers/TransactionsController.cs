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
    public async Task<IActionResult> Get(
        [FromQuery] TransactionsGetRequest request
    )
    {
        if (request.Id != Guid.Empty)
        {
            var entity = await _repository.SearchEntityById(request.Id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        var list = await _repository.GetEntitiesWithConditions(
            request.SearchName,
            request.SearchCategory,
            request.SortType,
            request.SortOrder
        );

        return Ok(new TransactionsCreateResponse(list));
    }

    [HttpPost]
    public IActionResult Create([FromBody] TransactionsCreateRequest request)
    {
        try
        {
            TransactionEntity entity =
                new(
                    request.Name,
                    request.Category,
                    request.Description,
                    request.Price,
                    request.Year,
                    request.Month,
                    request.Day
                );

            _repository.InsertEntity(entity);
            return Ok("Entity was created");
        }
        catch
        {
            return BadRequest();
        }
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

        try
        {
            TransactionEntity updateEntity =
                new(
                    request.Name,
                    request.Category,
                    request.Description,
                    request.Price,
                    request.Year,
                    request.Month,
                    request.Day
                );

            await _repository.UpdateEntity(entity, updateEntity);
            return Ok("Entity was updated");
        }
        catch
        {
            return BadRequest();
        }
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
        return Ok("Entity was removed");
    }
}

using FinanceApi.Data;
using FinanceApi.Dto;
using FinanceApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinanceApi.Controllers;

[ApiController]
[Route("api/transactions")]
public class TransactionController(FinanceDbContext dbContext) : ControllerBase
{
    private FinanceDbContext _dbContext = dbContext;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var all = await _dbContext.Transactions.ToListAsync();
        
        return Ok(all.Select(t => new TransactionResponse {Id = t.Id, Description = t.Description, Value = t.Value, CreatedAt = t.CreatedAt}));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TransactionCreateRequest createRequest)
    {
        Transaction ts = new Transaction
        {
            Description = createRequest.Description,
            Value = createRequest.Value,
            CreatedAt = DateTime.UtcNow
        };

        await _dbContext.Transactions.AddAsync(ts);
        await _dbContext.SaveChangesAsync();

        return Ok(ts);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var ts = await _dbContext.Transactions.FirstOrDefaultAsync(ts => ts.Id == id);

        if (ts == null)
        {
            return NotFound("Transaction not found");
        }

        return NoContent();
    }
}
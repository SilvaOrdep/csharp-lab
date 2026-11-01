using FinanceApi.Data;
using FinanceApi.Dto;
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

}
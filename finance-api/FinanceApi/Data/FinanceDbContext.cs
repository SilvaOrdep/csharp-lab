using FinanceApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceApi.Data;

public class FinanceDbContext(DbContextOptions<FinanceDbContext> options) : DbContext(options)
{
    public DbSet<Transaction> Transactions { get; set; }
    
    
}
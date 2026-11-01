using System.ComponentModel.DataAnnotations;

namespace FinanceApi.Dto;

public class TransactionResponse
{
    [Required]
    public int Id { get; set; }
    public string Description { get; set; }
    public decimal Value { get; set; }
    public DateTime CreatedAt { get; set; }
}
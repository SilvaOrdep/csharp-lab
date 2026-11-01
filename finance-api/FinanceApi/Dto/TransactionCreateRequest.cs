using System.ComponentModel.DataAnnotations;

namespace FinanceApi.Dto;

public class TransactionCreateRequest
{
    [Required(ErrorMessage = "Description is required.")]
    [StringLength(100, ErrorMessage = "Description cannot exceed 100 characters.")]
    public string Description { get; set; }

    [Range(0.01, 1000.00, ErrorMessage = "Price must be between 0.01 and 1000.00.")]
    public decimal Value { get; set; }
}
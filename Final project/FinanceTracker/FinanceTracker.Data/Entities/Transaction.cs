using System.ComponentModel.DataAnnotations;

namespace FinanceTracker.Data.Entities;

public record Transaction
{
    [Key]
    [Required]
    public Guid Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [StringLength(500)]
    public string Description { get; set; }

    [Required]
    [RegularExpression(@"^(\+?\d*\.?\d*)$", ErrorMessage = "Sum can't be less than zero or equal")]
    public decimal Sum { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    public Guid TypeId { get; set; }

    public Guid UserId { get; set; }

    public virtual TransactionType TransactionType { get; set; }
}

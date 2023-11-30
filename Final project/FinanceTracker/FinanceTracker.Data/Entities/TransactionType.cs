using System.ComponentModel.DataAnnotations;

namespace FinanceTracker.Data.Entities;

public record TransactionType
{
    [Key]
    [Required]
    public Guid Id { get; set; }

    [Required]
    [StringLength(maximumLength: 50)]
    public string Name { get; set; }

    [Required]
    [StringLength(maximumLength: 500)]
    public string Description { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace FinanceTracker.Data.Entities;

public record Goal
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
    public DateTime CreatedAt { get; set; }

    [Required]
    public DateTime Deadline { get; set;}

    public Guid UserId { get; set; }
}

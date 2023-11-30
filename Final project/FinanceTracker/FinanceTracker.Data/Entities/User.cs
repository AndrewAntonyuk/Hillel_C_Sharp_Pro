using System.ComponentModel.DataAnnotations;

namespace FinanceTracker.Data.Entities;

public record User
{
    [Key]
    [Required]
    public Guid Id { get; set; }

    [StringLength(maximumLength:200)]
    [Required]
    public string UserName { get; set; }

    [StringLength(maximumLength: 200)]
    [Required]
    public string FirstName { get; set; }

    [StringLength(maximumLength: 200)]
    public string MiddleName { get; set; }

    [StringLength(maximumLength: 200)]
    public string LastName { get; set; }

    [EmailAddress]
    [Required]
    public string Email { get; set; }

    [Phone]
    public string Phone { get; set; }

    public string PasswordHash { get; set; }

    public string PasswordSalt { get; set; }

    public virtual IEnumerable<Goal> Goals { get; set; }

    public virtual IEnumerable<Transaction> Transactions { get; set; }
}

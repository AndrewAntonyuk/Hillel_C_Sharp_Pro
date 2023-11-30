using FinanceTracker.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Data.Context;

public class FinanceTrackerContext : DbContext
{
    public FinanceTrackerContext(DbContextOptions<FinanceTrackerContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Goal> Goals { get; set; }
    public DbSet<TransactionType> TransactionTypes { get; set; }
    public DbSet<Transaction> Transactions { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(o =>
        {
            o.HasIndex(u => u.UserName)
            .IsUnique();

            o.HasIndex(u => u.Email)
           .IsUnique();

            o.HasIndex(u => u.Phone)
           .IsUnique();
        });

        modelBuilder.Entity<Goal>(o =>
        {
            o.HasOne<User>()
            .WithMany(u => u.Goals)
            .HasForeignKey(x => x.UserId);
        });

        modelBuilder.Entity<Transaction>(o =>
        {
            o.HasOne(x => x.TransactionType)
            .WithMany()
            .HasForeignKey(x => x.TypeId);

            o.HasOne<User>()
            .WithMany(u => u.Transactions)
            .HasForeignKey(x => x.UserId);
        });
    }
}

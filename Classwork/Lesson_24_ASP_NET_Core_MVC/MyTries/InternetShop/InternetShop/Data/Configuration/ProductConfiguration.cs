using InternetShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InternetShop.Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).HasColumnType("VARCHAR").IsRequired().HasMaxLength(100);
            builder.Property(p => p.Description).HasColumnType("VARCHAR").HasMaxLength(200);
            builder.Property(p => p.Price).IsRequired().HasColumnType("DECIMAL(18,2)");
            builder.Property(p => p.CreatedAt).IsRequired();

            // Define relationships

            builder.HasMany(p => p.OrderDetails)
                   .WithOne(od => od.Product)
                   .HasForeignKey(od => od.ProductId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

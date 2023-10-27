using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task_12_Cinema.Models;

namespace Task_12_Cinema.Data.DbConfigs
{
    public class GenreDbConfig : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable(nameof(Genre), t => t.HasCheckConstraint(
                                                  $"CK_{nameof(Genre)}_Name", $"LEN(TRIM([Name])) > 0"));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Id).IsRequired();

            builder.Property(x  => x.Name)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(30)
                .IsRequired();
            builder.HasIndex(x => new {x.Name}).IsUnique();

            builder.Property(x => x.Description).HasMaxLength(500).HasColumnType("NVARCHAR");
        }
    }
}

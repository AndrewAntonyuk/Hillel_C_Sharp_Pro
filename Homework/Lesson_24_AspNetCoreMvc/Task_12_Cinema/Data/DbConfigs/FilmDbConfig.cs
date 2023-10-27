using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task_12_Cinema.Models;

namespace Task_12_Cinema.Data.DbConfigs
{
    public class FilmDbConfig : IEntityTypeConfiguration<Film>
    {
        public void Configure(EntityTypeBuilder<Film> builder)
        {
            builder.ToTable(nameof(Film), t => t.HasCheckConstraint(
                                                 $"CK_{nameof(Film)}_Name", "LEN(TRIM([Name])) > 0"));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Id).IsRequired();

            builder.Property(x => x.Name).HasMaxLength(50).HasColumnType("NVARCHAR").IsRequired();

            builder.Property(x => x.GenreId).IsRequired().HasColumnType("INT").HasDefaultValue(0);

            builder.Property(x => x.DirectorId).IsRequired().HasColumnType("INT").HasDefaultValue(0);

            builder.Property(x => x.Description).HasMaxLength(1500).HasColumnType("NVARCHAR");

            builder.HasIndex(x => new { x.Name }).IsUnique();

            builder.HasOne(x => x.Genre)
                   .WithMany()
                   .HasForeignKey(x => x.GenreId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Director)
                   .WithMany(d => d.Films)
                   .HasForeignKey(x => x.DirectorId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

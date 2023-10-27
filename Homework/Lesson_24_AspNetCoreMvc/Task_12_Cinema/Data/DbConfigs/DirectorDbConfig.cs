using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task_12_Cinema.Models;

namespace Task_12_Cinema.Data.DbConfigs
{
    public class DirectorDbConfig : IEntityTypeConfiguration<Director>
    {
        public void Configure(EntityTypeBuilder<Director> builder)
        {
            builder.ToTable(nameof(Director), t => t.HasCheckConstraint(
                                                  $"CK_{nameof(Director)}_FirstName", $"LEN(TRIM([FirstName])) > 0"));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Id).IsRequired();

            builder.Property(x => x.FirstName).IsRequired().HasColumnType("NVARCHAR").HasMaxLength(30);

            builder.Property(x => x.MiddleName).HasColumnType("NVARCHAR").HasMaxLength(30);

            builder.Property(x => x.LastName).HasColumnType("NVARCHAR").HasMaxLength(30);

            builder.Property(x => x.ShortBio).HasColumnType("NVARCHAR").HasMaxLength(1500);

            builder.HasIndex(x => new { x.FirstName, x.MiddleName, x.LastName}).IsUnique();
        }
    }
}

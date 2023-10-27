using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task_12_Cinema.Models;

namespace Task_12_Cinema.Data.DbConfigs
{
    public class SessionDbConfig : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.ToTable(nameof(Session));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Id).IsRequired();

            builder.Property(x => x.EventDateTime).IsRequired().HasColumnType("DATETIME2").HasDefaultValue(DateTime.UtcNow);

            builder.Property(x => x.FilmId).IsRequired().HasColumnType("INT");

            builder.HasIndex(x => new { x.FilmId, x.EventDateTime}).IsUnique();

            builder.HasOne(x => x.Film)
                   .WithMany(f => f.Sessions)
                   .HasForeignKey(x => x.FilmId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

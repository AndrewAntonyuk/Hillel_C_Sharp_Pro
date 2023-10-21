using Microsoft.EntityFrameworkCore;
using Task_1_NoteContact.Models;

namespace Task_1_NoteContact.Data
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Note> Notes { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}

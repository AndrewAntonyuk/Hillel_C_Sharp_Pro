using InternetShop.Models;
using Microsoft.EntityFrameworkCore;

namespace InternetShop.Data
{
    public class DbInitializer
    {
        private readonly ModelBuilder _modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            _modelBuilder.Entity<User>(x =>
            {
                x.HasData(new User
                {
                    Id = 22,
                    Username = "Vasya",
                    Email = "vasya@gmail.com",
                    Address = "test-1",
                    Fullname = "Vasya Pupkin",
                    CreatedAt = DateTime.UtcNow
                });
                x.HasData(new User
                {
                    Id = 25,
                    Username = "Petya",
                    Email = "petya@gmail.com",
                    Address = "test-2",
                    Fullname = "Petya Pupkin",
                    CreatedAt = DateTime.UtcNow
                });
            });
        }
    }
}

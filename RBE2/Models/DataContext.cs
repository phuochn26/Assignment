using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RBE2.Models
{
    public class DataContext : DbContext
    {
        public DataContext() { }
        public DataContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Book>().HasMany(b => b.Authors);
            modelBuilder.Entity<Author>().HasMany(b => b.Books);
            modelBuilder.Entity<Client>().HasMany(b => b.Books);
            modelBuilder.Entity<Client>().HasData(new Client
            {
                ClientId = 1,
                ClientName = "Client1",
            });
            modelBuilder.Entity<Author>().HasData(new Author
            {
                AuthorId = 1,
                AuthorName = "Author1",
            });

            modelBuilder.Entity<Book>().HasData(new Book
            {
                BookId = 1,
                BookName = "Book1",
                ClientId = 1
            });

        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Client> Cilents { get; set; }
    }
}
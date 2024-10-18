using BookLibrary.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Book { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Publisher> Publisher { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>()
                .HasData(new IdentityRole() { Name = "Admin", NormalizedName = "ADMIN" });
        }
    }
}


public class ApplicationUser : IdentityUser
{
    [StringLength(50)]
    public string? FirstName { get; set; }
    [StringLength(50)]
    public string? LastName { get; set; }
    [StringLength(150)]
    public string? Address { get; set; }
    [StringLength(50)]
    public string? City { get; set; }
    [StringLength(50)]
    public string? ZipCode { get; set; }
    [StringLength(50)]
    public string? Country { get; set; }
    public DateTime? DateOfBirth { get; set; }
}
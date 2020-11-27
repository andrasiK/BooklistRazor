using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BooklistRazor.Model
{
    public class ApplicationDbContext : DbContext
    {
        // Constructor with pass the DbContext options passing to the parent class
        // This is an empty constructor, but the parameter is needed to dependency injection
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Book { get; set; } 
    }
}

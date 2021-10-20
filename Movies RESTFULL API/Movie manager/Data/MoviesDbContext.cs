using Microsoft.EntityFrameworkCore;
using Movie_manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_manager.Data
{
    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext(DbContextOptions<MoviesDbContext> option) : base(option)
        {
                
        }

        public DbSet<Movie> Movie { get; set; }
    }
}

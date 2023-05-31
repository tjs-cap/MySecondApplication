using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MySecondApp.Models;

namespace MySecondApp.Data
{
    public class MoviesDBContext : DbContext
    {
        public MoviesDBContext (DbContextOptions<MoviesDBContext> options)
            : base(options)
        {
        }

        public DbSet<MySecondApp.Models.Movie> Movie { get; set; } = default!;
    }
}

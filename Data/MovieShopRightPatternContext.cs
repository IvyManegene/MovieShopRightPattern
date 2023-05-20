using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieShopRightPattern.Models;

namespace MovieShopRightPattern.Data
{
    public class MovieShopRightPatternContext : DbContext
    {
        public MovieShopRightPatternContext (DbContextOptions<MovieShopRightPatternContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; } = default!;
    }
}

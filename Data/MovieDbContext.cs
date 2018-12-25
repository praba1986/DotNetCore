using Microsoft.EntityFrameworkCore;
using myfirstdotnetcore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myfirstdotnetcore.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions options)
            :base(options)
        {

        }
        public DbSet<Movie> Movies { get; set; }
    }
}

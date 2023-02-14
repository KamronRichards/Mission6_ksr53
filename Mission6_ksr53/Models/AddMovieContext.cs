using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6_ksr53.Models
{
    public class AddMovieContext : DbContext
    {
        //Constructor
        public AddMovieContext(DbContextOptions<AddMovieContext> options) : base(options)
        {

        }

        public DbSet<MovieResponse> responses { get; set; }
    }
}

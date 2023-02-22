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

        public DbSet<Category> Categorys { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryID = 1, CategoryName = "Action/Adventure" },
                new Category { CategoryID = 2, CategoryName = "Comedy" },
                new Category { CategoryID = 3, CategoryName = "Drama" },
                new Category { CategoryID = 4, CategoryName = "Family" },
                new Category { CategoryID = 5, CategoryName = "Horror/Suspense" },
                new Category { CategoryID = 6, CategoryName = "Miscellaneous" }
                );

            //Seed the data with three movies
            mb.Entity<MovieResponse>().HasData(

                new MovieResponse
                {
                    MovieID = 1,
                    CategoryID = 1,
                    Title = "The Avengers",
                    Year = 2012,
                    Director = "Joss Whedon",
                    Rating = "PG-13",
                    Edited = true,
                    Lentto = "",
                    Notes = ""
                },

                new MovieResponse
                {
                    MovieID = 2,
                    CategoryID = 1,
                    Title = "Top Gun: Maverick",
                    Year = 2022,
                    Director = "Joseph Kosinski",
                    Rating = "PG-13",
                    Edited = true,
                    Lentto = "",
                    Notes = ""
                },

                new MovieResponse
                {
                    MovieID = 3,
                    CategoryID = 2,
                    Title = "Talladega Nights: The Ballard of Ricky Bobby",
                    Year = 2006,
                    Director = "Adam Mckay",
                    Rating = "PG-13",
                    Edited = true,
                    Lentto = "",
                    Notes = ""
                }
            );
        }
    }
}

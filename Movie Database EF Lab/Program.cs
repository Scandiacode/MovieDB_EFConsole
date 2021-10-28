using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieDB
{
    class Program
    {
        static void Main(string[] args)
        {
            //CreateDB();

            bool runAgain = true;
            while (runAgain == true)
            {
                Console.WriteLine("\nWould you like to search by Genre or Title?\nEnter 1 for 'Genre' | 2 for 'Title'");

                int input = Validator.Validator.GetInt(1, 2);
                if (input == 1)
                {
                    List<Movie> genreSearch = SearchByGenre();
                    Console.WriteLine("\nMovies in selected genre:");
                    for (int i = 0; i < genreSearch.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {genreSearch[i].Title}. Runtime: {genreSearch[i].Runtime} minutes.");
                    }
                }
                else if (input == 2)
                {
                    List<Movie> titleSearch = SearchByTitle();
                    for (int i = 0; i < titleSearch.Count; i++)
                    {
                        Console.WriteLine($"\n{titleSearch[i].Title} is part of the {titleSearch[i].Genre} genre. Runtime: {titleSearch[i].Runtime} minutes");
                    }
                }

                runAgain = Validator.Validator.Repeat();
            }
        }
        static void DisplayMovieDB()
        {
            using (MovieDBContext context = new MovieDBContext())
            {
                foreach (Movie m in context.Movies)
                {
                    Console.WriteLine($"{m.Id}. {m.Title}");
                }
            }
        }

        static List<Movie> SearchByGenre()
        {
            using (MovieDBContext context = new MovieDBContext())
            {
                List<string> genres = new List<string>();
                Console.WriteLine("Film database:");
                
                foreach (Movie m in context.Movies)
                {
                    genres.Add(m.Genre);
                }
                genres = genres.Distinct().ToList();

                foreach (string g in genres)
                {
                    Console.WriteLine(g);
                }

                Console.WriteLine("\nWhich genre?");
                string input = Validator.Validator.GetGenreMovies();

                List<Movie> movies = context.Movies.Where(m => m.Genre == input).ToList();

                return movies;
            }
        }
        static List<Movie> SearchByTitle()
        {
            using (MovieDBContext context = new MovieDBContext())
            {
                List<Movie> movies = new List<Movie>();

                DisplayMovieDB();

                Console.WriteLine("\nSelect a Title");
                int input = Validator.Validator.GetInt(1, context.Movies.Count());
                
                foreach (Movie m in context.Movies)
                {
                    if (m.Id == input)
                    {
                        movies.Add(m);
                        break;
                    }
                }
                return movies;
            }
        }
        static void CreateDB()
        {
            using (MovieDBContext context = new MovieDBContext())
            {
                Movie m1 = new Movie
                {
                    Title = "Slient Voice",
                    Genre = "Animated",
                    Runtime = 129
                };
                Movie m2 = new Movie
                {
                    Title = "Her",
                    Genre = "Sci-Fi",
                    Runtime = 126
                };
                Movie m3 = new Movie
                {
                    Title = "Chappie",
                    Genre = "Sci-Fi",
                    Runtime = 120
                };
                Movie m4 = new Movie
                {
                    Title = "Patema Inverted",
                    Genre = "Animated",
                    Runtime = 99
                };
                Movie m5 = new Movie
                {
                    Title = "Hellraiser",
                    Genre = "Horror",
                    Runtime = 94
                };
                Movie m6 = new Movie
                {
                    Title = "Goonies",
                    Genre = "Adventure",
                    Runtime = 114
                };
                Movie m7 = new Movie
                {
                    Title = "Citizen Kane",
                    Genre = "Mystery",
                    Runtime = 119
                };
                Movie m8 = new Movie
                {
                    Title = "",
                    Genre = "Comedy",
                    Runtime = 86
                };
                Movie m9 = new Movie
                {
                    Title = "Scooby-Doo: The Movie",
                    Genre = "Adventure",
                    Runtime = 104
                };
                Movie m10 = new Movie
                {
                    Title = "Edge of Darkness",
                    Genre = "Crime",
                    Runtime = 117
                };
                Movie m11 = new Movie
                {
                    Title = "Candyman",
                    Genre = "Horror",
                    Runtime = 99
                };
                Movie m12 = new Movie
                {
                    Title = "Your Name",
                    Genre = "Animated",
                    Runtime = 112
                };
                Movie m13 = new Movie
                {
                    Title = "Megamind",
                    Genre = "Animated",
                    Runtime = 96
                };

                context.Movies.Add(m1);
                context.Movies.Add(m2);
                context.Movies.Add(m3);
                context.Movies.Add(m4);
                context.Movies.Add(m5);
                context.Movies.Add(m6);
                context.Movies.Add(m7);
                context.Movies.Add(m8);
                context.Movies.Add(m9);
                context.Movies.Add(m10);
                context.Movies.Add(m11);
                context.Movies.Add(m12);
                context.Movies.Add(m13);

                context.SaveChanges();
            }
        }
    }
}

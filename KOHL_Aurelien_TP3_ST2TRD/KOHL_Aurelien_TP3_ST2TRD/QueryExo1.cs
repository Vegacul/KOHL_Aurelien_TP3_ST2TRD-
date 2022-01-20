using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace KOHL_Aurelien_TP3_ST2TRD
{
    class QueryExo1
    {


        public static void ListMovie()
        {
            var MovieList = new MovieCollection().Movies;
            foreach (var Movie in MovieList)
            {
                Console.Write($"{Movie.Title }\n ");
            }


        }

        public static void OldestMovie()
        {
            var MovieList = new MovieCollection().Movies;

            var query = MovieList
                        .OrderBy(c => c.ReleaseDate)
                        .First()
                        .Title;

            Console.WriteLine($"{query}");

        }

        public static void CountMovie()
        {
            var MovieList = new MovieCollection().Movies;

            var query = MovieList
                        .Count();

            Console.WriteLine($"{query}");

        }

        public static void EMovie()
        {
            var MovieList = new MovieCollection().Movies;

            var query = (from Movie in MovieList
                         select Movie);
            var query3 = query.Count(c => c.Title.Contains('e'));


            Console.WriteLine($"{query3}");

        }

        public static void FInMovie()
        {
            var MovieList = new MovieCollection().Movies;

            var query = (from Movie in MovieList
                         where Movie.Title.Contains('f')
                         select Movie.Title);
            int total = 0;

            foreach (var title in query)
            {
                int count = 0;
                foreach (char c in title)
                {
                    if (c == 'f')
                    {
                        count++;
                    }
                }
                total = total + count;
            }


            Console.WriteLine(total);


        }

        public static void HigherBudgestMovie()
        {
            var MovieList = new MovieCollection().Movies;

            var query = MovieList
                        .OrderBy(c => c.Budget)
                        .Last()
                        .Title;

            Console.WriteLine($"{query}");

        }

        public static void LowestBoxtMovie()
        {
            var MovieList = new MovieCollection().Movies;

            var query = MovieList
                        .OrderBy(c => c.BoxOffice)
                        .First()
                        .Title;

            Console.WriteLine($"{query}");

        }

        public static void ReversMovie()
        {
            var MovieList = new MovieCollection().Movies;

            var query = MovieList
                        .OrderBy(c => c.Title)
                        .Reverse()
                        .Take(11);

            foreach (var Movie in query)
            {
                Console.Write($"{Movie.Title }\n ");
            }

        }

        public static void Before1980Movie()
        {
            var MovieList = new MovieCollection().Movies;

            var query = MovieList
                        .Count(c => c.ReleaseDate.Year < 1980);

            Console.WriteLine($"{query}");

        }

        public static void TimeVowelMovie()
        {
            var MovieList = new MovieCollection().Movies;

            var query = MovieList
                        .Where(c => c.Title.StartsWith("A") || c.Title.StartsWith("E") || c.Title.StartsWith("I") || c.Title.StartsWith("O") || c.Title.StartsWith("U") || c.Title.StartsWith("Y"))
                        .Average(x => x.RunningTime);

            Console.Write($"{ query}\n ");

        }


        public static void HWMovie()
        {
            var MovieList = new MovieCollection().Movies;

            var query = MovieList
                        .Where(c => (c.Title.Contains("h") || c.Title.Contains("w")) & (c.Title.Contains("i") == false || c.Title.Contains("t") == false));

            foreach (var item in query)
            {
                Console.WriteLine($"{item.Title}");
            }

        }


        public static void MeanBudgetBoxOfficeMovie()
        {
            var MovieList = new MovieCollection().Movies;

            var query = MovieList
                        .Average(x => x.Budget / x.BoxOffice);

            Console.Write($"{ query}\n ");

        }


        public static void CharMovie()
        {
            var MovieList = new MovieCollection().Movies;


            var result =
                       from p in MovieList
                       group p by p.Title.Length into g
                       select new { NBChar = g.Key, COunt = g.Count()};

            foreach (var movie in result)
            {
                Console.Write($"{movie.NBChar } CHAR => {movie.COunt } FILMS\n ");
            }
        }

        public static void MeanBudgetBoxOfficeMovieByYEar()
        {
            var MovieList = new MovieCollection().Movies;


            var result =
               from p in MovieList
               group p by p.ReleaseDate.Year into g
               select new { YEAR = g.Key, AverageRev = g.Average(p => p.Budget / p.BoxOffice) };
            
            foreach (var movie in result)
            {
                Console.Write($"{movie.YEAR }  => {movie.AverageRev } \n ");
            }

        }
    }
}

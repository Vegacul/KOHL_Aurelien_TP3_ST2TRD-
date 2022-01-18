using System;
using System.Linq;
using System.Threading;



namespace KOHL_Aurelien_TP3_ST2TRD
{
    class Program
    {
        static void Main(string[] args)
        {
            var MovieList = new MovieCollection().Movies;
            Before1980Movie();

        }

        private static Mutex mut = new Mutex();

        public static void exo2()
        {
            // Déclaration du thread
            Thread myThread1;
            Thread myThread2;
            Thread myThread3;
           

            // Instanciation du thread, on spécifie dans le 
            // délégué ThreadStart le nom de la méthode qui
            // sera exécutée lorsque l'on appelle la méthode
            // Start() de notre thread.

            myThread1 = new Thread((o=> GLobalThread(10000,50,' ')));
            myThread2 = new Thread((w=> GLobalThread(11000, 40, '*')));
            myThread3 = new Thread((y=> GLobalThread(9000, 20, '°')));

            
            // Lancement du thread
            myThread1.Start();
            myThread2.Start();
            myThread3.Start();

            myThread1.Join();
            myThread2.Join();
            myThread3.Join();

        }

        public static void GLobalThread(int duree, int freq, char caractere )
        {
            
            for (int i = 0; i < (duree/freq); i++)
            {
                mut.WaitOne();
                Console.Write(caractere);
                mut.ReleaseMutex();
                Thread.Sleep(freq);
            }
            
        }


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
            var query3 = query .Count(c => c.Title.Contains('e'));


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

            var query = (from Movie in MovieList
                         select Movie);

            var query3 = query.Count(c => c.Title.Contains('h') || c.Title.Contains('w'));


            Console.WriteLine($"{query3}");

        }



    }
}

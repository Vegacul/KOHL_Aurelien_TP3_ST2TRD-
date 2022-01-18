using System;
using System.Linq;
using System.Threading;



namespace KOHL_Aurelien_TP3_ST2TRD
{
    class Program
    {
        private static int AskUserForParameter()
        {
            int.TryParse(Console.ReadLine(), out var result);
            return result;
        }

        static void Main(string[] args)
        {

            int choice;
            do
            {
                Console.Write(getMainMenu());
                choice = AskUserForParameter();
                Console.WriteLine("\n");
                string result = computeMainMenuChoice(choice);
                Console.WriteLine(result);
            } while (choice != 16);
            Console.ReadLine();
        }

        public static string getMainMenu()
        {

            return "\n************ Menu ************\n "
                + " Exercise 1 :\n"
                    + " 1: Display the title of the oldest movie \n"
                    + " 2: Count all movies \n"
                    + " 3: Count all movies with the letter e. at least once in the title. \n"
                    + " 4: Count how many time the letter f is in all the titles from this list. \n"
                    + " 5: Display the title of the film with the higher budget \n"
                    + " 6: Display the title of the movie with the lowest box office \n"
                    + " 7: Order the movies by reversed alphabetical order and print the first 11 of the list \n"
                    + " 8: Count all the movies made before 1980 \n"
                    + " 9: Display the average running time of movies having a vowel as the first letter \n"
                    + " 10: Print all movies with the letter H or W in the title, but not the letter I or T \n"
                    + " 11: Calculate the mean of all Budget / Box Office of every movie ever \n"
                    + " 12: Group all films by the number of characters in the title screen and print the count of movies by letter in the film \n"
                    + " 13: Calculate the mean of all Budget / Box Office of every movie grouped by yearly release date \n"
                    + " 14: Exercice 2 : Thread étoilé\n"
                    + " 15: MOURIR et coder en Python car c'est mieux\n"
                    + "\n Whats is your choice ? :\n ";
        }

        public static string computeMainMenuChoice(int choice)
        {
            string result = " ";

            switch (choice)
            {
                case 1:
                    QueryExo1.OldestMovie();
                    break;
                case 2:
                    QueryExo1.CountMovie();
                    break;
                case 3:
                    QueryExo1.EMovie();
                    break;
                case 4:
                    QueryExo1.FInMovie();
                    break;
                case 5:
                    QueryExo1.HigherBudgestMovie();
                    break;
                case 6:
                    QueryExo1.LowestBoxtMovie();
                    break;
                case 7:
                    QueryExo1.ReversMovie();
                    break;
                case 8:
                    QueryExo1.Before1980Movie();
                    break;
                case 9:
                    QueryExo1.TimeVowelMovie();
                    break;
                case 10:
                    QueryExo1.HWMovie();
                    break;
                case 11:
                    QueryExo1.MeanBudgetBoxOfficeMovie();
                    break;
                case 12:
                    QueryExo1.CharMovie();
                    break;
                case 13:
                    QueryExo1.MeanBudgetBoxOfficeMovieByYEar();
                    break;
                case 14:
                    ThreadExo2.exo2();
                    break;
                case 15:
                    result += "\nC'est un bon choix mais malheuresement il est en rupture de stock, sorry";
                    break;
                default:
                    result += "\nBad choice, try again";
                    break;
            }
            return result;
        }


    }
}

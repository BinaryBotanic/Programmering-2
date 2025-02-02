using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Moment_4_uppgift_D
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ber användaren om text
            Console.WriteLine("Skriv en text med mist 50 ord. För att kontrollera ord i din text klicka enter:");

            // Läs in texten
            string text = Console.ReadLine();

            // Kontrollera att texten har minst 50 ord
            while (text.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length < 50)
            {
                Console.WriteLine("Texten måste innehålla minst 50 ord. Vänligen försök igen: ");
                text = Console.ReadLine();
            }

            // Skapa en Dictionry för att räkna orden
            Dictionary<string, int> wordCount = new Dictionary<string, int>();

            // Ta bort onödiga tecken
            string[] words = Regex.Replace(text, @"[.,!?]", "").Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            // Kollar igenom alla ord
            foreach (string word in words)
            {
                if (!string.IsNullOrWhiteSpace(word))
                {
                    if (wordCount.ContainsKey(word))
                    {
                        wordCount[word]++;
                    }
                    else
                    {
                        wordCount[word] = 1;
                    }
                }
            }

            // Sortera efter antal och resultatet
            var sortedWordCount = wordCount.OrderByDescending(x => x.Value);

            // Skriver ut resultaten
            Console.WriteLine("\nFörekomst av ord i texten:");
            foreach (var pair in sortedWordCount)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }

            // Vänta på att användaren trycker på något för att avsluta
            Console.ReadLine();
        }
    }
}
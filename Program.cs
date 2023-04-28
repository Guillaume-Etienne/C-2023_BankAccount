using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bankscan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sourceFile = "C:/temp/account.txt";
            //var targetFile = "C:/temp/resultat.txt";

            var input = File.ReadAllLines(sourceFile);

            //foreach (var line in input)
            //{
            //    Console.WriteLine(line);
            //}

            SplitEntries splitEntries = new SplitEntries();
            int ammountOfEntries = splitEntries.AmmountOfEntries(sourceFile);
            Console.WriteLine("Nombre d'entrée : " + ammountOfEntries);

            // Split into Entities         
            var splittedEntries = splitEntries.SplitString(input);



            // Loop into Translation's loop
            
            foreach (var splittedEntry in splittedEntries)
            {
                Console.WriteLine(splittedEntry);

                List<string> splittedNumbers = splitEntries.SplitNumber(splittedEntry);

                foreach (var number in splittedNumbers)
                {
                    var test = splitEntries.TranslateToNumber(number);
                    Console.Write(test);
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}

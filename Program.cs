using System;
using System.Collections.Generic;
using System.IO;


namespace Bankscan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sourceFile = args.Length == 1 ? args[0] : "c:/temp/account.txt";
            string[] input;

            try
            {
                input = File.ReadAllLines(sourceFile);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Votre Document n'a pas été trouvé, On prend la valeur par défaut");
                sourceFile = "c:/temp/account.txt";
                input = File.ReadAllLines(sourceFile);
            }

            Console.WriteLine("On va donc taper dans le fichier : " +sourceFile);
            

            
            // Identifier le nombre d'entrée
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
                string numberSequenceTranslated=null;

                foreach (var number in splittedNumbers)
                {
                    var numberTranslated = splitEntries.TranslateToNumber(number);
                    numberSequenceTranslated += numberTranslated;                    
                }

                Console.WriteLine(numberSequenceTranslated);
                int checkResult = splitEntries.CheckIfAccountValid(numberSequenceTranslated);
                if (checkResult == 0) { Console.WriteLine("Numéro vérifié, il est valide."); }
                else { Console.WriteLine("Ce compte est FAUX d'après le vérificateur"); }
            }

            Console.ReadLine();
        }
    }
}

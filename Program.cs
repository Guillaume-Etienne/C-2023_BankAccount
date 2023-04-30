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
            //string sourceFile = "c:/temp/account.txt";
            //var input = File.ReadAllLines(sourceFile);

            //if (args.Length == 1)
            //{
            //    try
            //    {
            //        sourceFile = args[0];
            //        input = File.ReadAllLines(sourceFile);
            //    }
            //    catch (FileNotFoundException)
            //    {
            //        Console.WriteLine("Votre Document n'a pas été trouvé, On prend la valeur par défaut");
            //        sourceFile = "c:/temp/account.txt";
            //        input = File.ReadAllLines(sourceFile);
            //    }
            //}


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

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

            foreach (var line in input)
            {
                Console.WriteLine(line);
            }

            SplitEntries splitEntries = new SplitEntries();
            int ammountOfEntries = splitEntries.AmmountOfEntries(sourceFile);
            Console.WriteLine("Nombre d'entrée : " + ammountOfEntries);

            // Split into Entities         
            var splittedEntries = splitEntries.SplitString(input);


            // 

            Console.WriteLine(splittedEntries[0]);
            Console.WriteLine(splittedEntries[0].Length);

            List<string> test = splitEntries.SplitNumber(splittedEntries[0]);
                    



            Console.ReadLine();
        }
    }
}

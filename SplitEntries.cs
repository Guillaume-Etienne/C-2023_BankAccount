using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankscan
{
    class SplitEntries
    {
        public int AmmountOfEntries (string sourceFile)
        {
            int nbTotalLines = sourceFile.Length;
            //Console.WriteLine("From Split ! Nb de lignes lues : " + nbTotalLines);
            int nbEntries = (nbTotalLines + 1)/4;
            //Console.WriteLine("Nb d'Entries détecté : " + nbEntries);
            
            return nbEntries;
        }

        public List<string> SplitString(string[] stringArray)
        {
            List<string> entrieSplitted = new List<string>();

            for (int i = 0; i < stringArray.Length; i += 4)
            {
                int remainingCount = stringArray.Length - i;

                if (remainingCount >= 4)
                {
                    entrieSplitted.Add(string.Join("\n", stringArray, i, 4));
                }
                else
                {
                    entrieSplitted.Add(string.Join("\n", stringArray, i, remainingCount));
                }
            }

            return entrieSplitted;
        }


        public List<string> SplitNumber(string stringArray)
        {
            int nbrOfElementsToSplit = 9;
            int sizeOfOneElement = 3;

            List<string> entrieSplittedOneByOne = new List<string>();

            for (int i = 0;i<nbrOfElementsToSplit;i++)
            {
                int increment = i * sizeOfOneElement;

                string triple1 = stringArray.Substring(increment, 3);                
                string triple2 = stringArray.Substring(increment + 28, 3);                
                string triple3 = stringArray.Substring(increment + 28 * 2, 3);                
                
                string tripleComplet = triple1 + triple2 + triple3;
               
                entrieSplittedOneByOne.Add(tripleComplet);
            }
                        
            return entrieSplittedOneByOne;
        }
        public int TranslateToNumber(string entryToTranslate)
        {
            //tester le triple et retourner sa traduction  ------ retourne -1 si pas de correspondance ----------
            Digitdictionary digitDictionary = new Digitdictionary();
            Dictionary<int, string> templates = digitDictionary.digitTemplates;
            
            int key;
            try
            {
                key = templates.First(x => x.Value == entryToTranslate).Key;
            }
            catch (InvalidOperationException)
            {
                key = -1;
            }

            return key;


        }
        public int CheckIfAccountValid(string account)     // Vérifie si le compte est correcte d'après l'équation fournie
        {         
            int[] weights = { 9, 8, 7, 6, 5, 4, 3, 2, 1 };   // les dn (définis par la position du chiffre à tester)
            int sum = 0;

            for (int i = 0; i < 9; i++)
            {
                int digit = int.Parse(account[i].ToString());
                sum += digit * weights[i];                
            }

            int remainder = sum % 11;               // le résultat doit être 0 pour un compte valide
              
            return remainder;
        }
    }
}

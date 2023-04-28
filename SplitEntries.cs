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
                //Console.WriteLine("Triple trouvé : " + tripleComplet);
                entrieSplittedOneByOne.Add(tripleComplet);
            }
                        
            return entrieSplittedOneByOne;
        }
        public int TranslateToNumber(string entryToTranslate)
        {
            //tester le triple et retourner sa traduction
            Digitdictionary digitDictionary = new Digitdictionary();
            Dictionary<int, string> templates = digitDictionary.digitTemplates;
            int key = templates.First(x => x.Value == entryToTranslate).Key;
            //Console.WriteLine("Dans la fonction : " + key);
            return key;
        }
    }
}

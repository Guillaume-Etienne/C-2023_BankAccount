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
            Console.WriteLine("From Split ! Nb de lignes lues : " + nbTotalLines);
            int nbEntries = (nbTotalLines + 1)/4;
            Console.WriteLine("Nb d'Entries détecté : " + nbEntries);
            
            return nbEntries;
        }

        public List<string> SplitString(string[] stringArray)
        {
            List<string> result = new List<string>();

            for (int i = 0; i < stringArray.Length; i += 4)
            {
                int remainingCount = stringArray.Length - i;

                if (remainingCount >= 4)
                {
                    result.Add(string.Join("\n", stringArray, i, 4));
                }
                else
                {
                    result.Add(string.Join("\n", stringArray, i, remainingCount));
                }
            }

            return result;
        }


        public List<string> SplitNumber(string stringArray)
        {
            Digitdictionary digitDictionary = new Digitdictionary();

            int totalAmount = 84;
            int nbrOfElementsToSplit = 9;
            int sizeOfOneElement = 3;

            for (int i = 0;i<nbrOfElementsToSplit;i++)
            {
                int increment = i * sizeOfOneElement;

                string triple1 = stringArray.Substring(increment, 3);
                Console.WriteLine(" triple1 : " + triple1);
                string triple2 = stringArray.Substring(increment + 28, 3);
                Console.WriteLine(" triple2 : " + triple2);
                string triple3 = stringArray.Substring(increment + 28 * 2, 3);
                Console.WriteLine(" triple3 : " + triple3);

                //retourner un triple complet
                string tripleComplet= triple1+triple2+ triple3;
                Console.WriteLine("Triple complet : " + tripleComplet);
                
                
                //tester le triple et retourner sa traduction

              
                // Gui : comment taper dans la clef en envoyant la value
            }

            // tests avec le dictionnaire
           
                //Digitdictionary digitDictionary = new Digitdictionary();
                string digitTemplate = digitDictionary.digitTemplates[0]; // Access the dictionary
                Console.WriteLine("Coucou voici le dico : " + digitTemplate);
            


            return null;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//*** TryToFixIll : for ILL : identify where are the '?'
//*** ReplaceAllQM : for ILL : replace  '?' by 0-9
//*** CheckThemAll : for ILL and ERR : Check if they are valid
//*** TryToFixErr : for ERR

namespace Bankscan
{
    class FixUnreadable      
    {
        public int TryToFixIll(string bankAccountInError)
        {
            List<int> listOfIndexMistakes = new List<int>(); 
            
            int index = bankAccountInError.IndexOf('?');
            while (index != -1)
            {                
                listOfIndexMistakes.Add(index);
                index = bankAccountInError.IndexOf('?', index + 1);                
            }

            //Console.WriteLine("Nombre de chiffres en erreur : " + listOfIndexMistakes.Count);

            // ------------------------

           List<string> allNumberPossible = new List<string>();

            allNumberPossible = ReplaceAllQuestionMarks(allNumberPossible, bankAccountInError, listOfIndexMistakes, listOfIndexMistakes.Count, listOfIndexMistakes.Count);

            //Console.WriteLine("Nombre de possibilité : "+ allNumberPossible.Count);

            int resultOfCheckThemAll = CheckThemAll(allNumberPossible);
                
            // -------------------------
            return resultOfCheckThemAll;
        }

        public List<string> ReplaceAllQuestionMarks(List<string> resultList, string input, List<int> indexes, int numberOfErrorsLeft, int numberOfErrorsTotal)
        {
            if (numberOfErrorsLeft > 0)
            {
                int currentIndex = numberOfErrorsTotal - numberOfErrorsLeft;
                for (int i = 0; i < 10; i++)
                {
                    string newInput = input.Remove(indexes[currentIndex], 1).Insert(indexes[currentIndex], i.ToString());
                    ReplaceAllQuestionMarks(resultList, newInput, indexes, numberOfErrorsLeft - 1, numberOfErrorsTotal);
                }
            }
            else
            {
                resultList.Add(input);
            }

            return resultList;
        }


        int CheckThemAll(List<string> accountList)  //va vérifier si les comptes sont bons.   Si 1 l'est : il est renvoyé, si aucun :0    -  si >1, nombre renvoyé en négatif
        {
            List<int> checkResult = new List<int>();
            foreach (string account in accountList)
            {
                SplitEntries splitEntries = new SplitEntries();
                checkResult.Add(splitEntries.CheckIfAccountValid(account));
            }

            int resultCount = checkResult.Count;

            Console.WriteLine("CheckThemAll a bossé sur : " + resultCount + " Comptes");

            int numberOFPotentialRealAccount = checkResult.Count(x => x == 0);
            

            if (numberOFPotentialRealAccount == 1)
            {
                int theAccountPossible = checkResult.FindIndex(x => x == 0);
                Console.WriteLine("Il y a un élu, c'est lui : " + accountList[theAccountPossible]);
                return  int.Parse(accountList[theAccountPossible]);
            }
            else if (numberOFPotentialRealAccount == 0)
            {
                Console.WriteLine("Pas de correction possible");
                return 0;
            }
            else
            {
                Console.WriteLine($"Il a trouvé {numberOFPotentialRealAccount} comptes potentielements vrai, il y a ambiguité");
                return -1;
            }
            
        }

        public int TryToFixErr(string bankAccountInError)
        {
            Console.WriteLine("--- Try To fix ERR lancé sur  : " + bankAccountInError);

            List<string> listOfPossibleAccount = new List<string>();
            // changer tout les chiffres par leur digiswapPossibilities
            
            // test gui :
            listOfPossibleAccount.Add(bankAccountInError);
            // fin Test
            

            List<string> allNumberPossible = SwapAllNumbers(listOfPossibleAccount, bankAccountInError);
            
            Console.WriteLine("Possibilités trouvées : " + allNumberPossible.Count);

            
            

            

            int resultOfCheckThemAll = CheckThemAll(allNumberPossible);

            // -------------------------
            return resultOfCheckThemAll;
        }

        public List<string> SwapAllNumbers(List<string> workingtList, string input, int index=0)
        {            
            Digitdictionary digitDictionary = new Digitdictionary();
            Dictionary<char, char[]> swapDictionary = digitDictionary.swapDictionary;

            Console.WriteLine("----------");
            Console.WriteLine("index : " + index);

            if (index == input.Length)
            {
                return workingtList;
            }

            List<string> newWorkingList = new List<string>();

            char currentChar = input[index];

            Console.WriteLine("currentChar : " + currentChar);
            
            if (swapDictionary.ContainsKey(currentChar))
            {
                char[] possibleChars = swapDictionary[currentChar];

                                    

                foreach (char possibleChar in possibleChars)
                {   
                    Console.WriteLine("possibleChar : " + possibleChar);
                    foreach (string workingString in workingtList)
                    {
                        Console.WriteLine("workingString : " + workingString);
                        string newString = workingString.Substring(0, index) + possibleChar + workingString.Substring(index + 1);
                        newWorkingList.Add(newString);
                    }
                }
            }
            else
            {
                foreach (string workingString in workingtList)
                {
                    newWorkingList.Add(workingString);
                }
            }

            return SwapAllNumbers(newWorkingList, input, index + 1);
        }
    }
}

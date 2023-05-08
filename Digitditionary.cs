using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankscan
{
    public class Digitdictionary
    {
        public Dictionary<int, string> digitTemplates = new Dictionary<int, string>()
        {
            {0, " _ | ||_|"},
            {1, "    |  | "},
            {2, " _  _||_ "},
            {3, " _  _| _|"},
            {4, "   |_|  |"},
            {5, " _ |_  _|"},
            {6, "   |_ |_|"},
            {7, " _   |  |"},
            {8, " _ |_||_|"},
            {9, " _ |_| _|"}
        };

        public Dictionary<char, char[]> swapDictionary = new Dictionary<char, char[]>()
        {
            {'0', new char[] { '0', '1' }},
            {'1', new char[] { '1', '7' }},
            {'2', new char[] {'2'}},
            {'3', new char[] { '3', '9' }},
            {'4', new char[] {'4'}},
            {'5', new char[] { '5', '9' }},
            {'6', new char[] {'6'}},
            {'7', new char[] { '7', '1' }},
            {'8', new char[] { '8', '9', '0'}},
            {'9', new char[] { '9', '8' }}
        };


        // tout ce qui ci dessous :  des backups   -------------- oui je sais, c'est pas bien....
        public Dictionary<char, char[]> swapDictionary2 = new Dictionary<char, char[]>()
        {
            {'0', new char[] {'1'}},
            {'1', new char[] {'7'}},
            {'2', new char[0]},
            {'3', new char[] {'9'}},
            {'4', new char[0]},
            {'5', new char[] {'9'}},
            {'6', new char[0]},
            {'7', new char[] {'1'}},
            {'8', new char[] {'9', '0'}},
            {'9', new char[] {'8'}}
        };
        public Dictionary<int, int[]> digitSwapPossibilitiesBackup = new Dictionary<int, int[]>()
        {
            {0, new int[] { 1}},
            {1, new int[] { 7}},
            {2, new int[] { }},
            {3, new int[] { 9}},
            {4, new int[] { }},
            {5, new int[] { 9}},
            {6, new int[] { }},
            {7, new int[] { 1}},
            {8, new int[] { 9, 0 }},
            {9, new int[] { 8}},
        };

        public Dictionary<int, int[]> digitSwapPossibilities2 = new Dictionary<int, int[]>
        {
            {0, new [] {1}},
            {1, new [] {7}},
            {2, new int[0]},
            {3, new [] {9}},
            {4, new int[0]},
            {5, new [] {9}},
            {6, new int[0]},
            {7, new [] {1}},
            {8, new [] {9, 0}},
            {9, new [] {8}}
        };
    }
}


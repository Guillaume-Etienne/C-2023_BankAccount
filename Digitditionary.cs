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
            {1, "     |  |"},
            {2, " _  _||_ "},
            {3, " _  _| _|"},
            {4, "   |_|  |"},
            {5, " _ |_  _|"},
            {6, " _ |_ |_|"},
            {7, " _   |  |"},
            {8, " _ |_||_|"},
            {9, " _ |_| _|"}
        };
    }
}


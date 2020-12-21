using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    class Day2
    {
        public int Num1 { get; set; }
        public int Num2 { get; set; }
        public char Letter { get; set; }
        public string pass { get; set; }

        public Day2(int num1, int num2, char letter, string pass)
        {
            Num1 = num1;
            Num2 = num2;
            Letter = letter;
            this.pass = pass;
        }
    }
}

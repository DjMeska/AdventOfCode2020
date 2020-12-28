using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    class Day16
    {
        public string Name;
        public int[] Range1;
        public int[] Range2;
        public List<int> possibleIndex = new List<int>();
        public Day16(string name, int[] range1, int[] range2)
        {
            Name = name;
            Range1 = range1;
            Range2 = range2;
            for (int i = 0; i < 20; i++)
            {
                possibleIndex.Add(i);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020
{


    class Day8
    {
        public string Type { get; set; }
        public int Values { get; set; }
        public bool Executed { get; set; }

        public Day8(string type, int values, bool executed)
        {
            Type = type;
            Values = values;
            Executed = executed;
        }
    }
}


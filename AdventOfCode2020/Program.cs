using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdventOfCode2020
{
    class Program
    {
        static void Main(string[] args)
        {
            /*var watch = System.Diagnostics.Stopwatch.StartNew();
            //code
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine(elapsedMs);*/

            //int[] numbers = InOutUtils.Day1("Day1.txt"); //Day 1;
            TasksUtils Register = new TasksUtils();
            /*int ansDay1 = Register.Day1Solve(numbers);
            Console.WriteLine(ansDay1); 
            int ansDay1Part2 = Register.Day1Part2Solve(numbers);
            Console.WriteLine(ansDay1Part2); //End Day1
            List<Day2> day2 = InOutUtils.ReadDay2("Day2.txt"); //Day 2;
            int ansDay2Part1 = Register.Day2Part1Solve(day2);
            int ansDay2Part2 = Register.Day2Part2Solve(day2);
            Console.WriteLine(ansDay2Part1);
            char[,] map = InOutUtils.ReadDay3("Day3.txt"); //Day3
            int tree = Register.Day3Part1Solve(map);
            InOutUtils.ReadDay4("Day4.txt"); //Day4
            List<string> day5 = InOutUtils.ReadDay5("Day5.txt"); //Day5
            Register.Day5Part1Solve(day5);
            InOutUtils.ReadDay6Part1("Day6.txt"); //Day 6
            InOutUtils.ReadDay6Part2("Day6.txt");
            Console.WriteLine(Register.Day7Part1Solve(InOutUtils.ReadDay7("Day7.txt"))); //Day7
           
            Console.WriteLine(Register.Day8Part1(InOutUtils.ReadDay8("Day8.txt")));
            Register.Day10Part1(InOutUtils.ReadDay10("Day10.txt"));
            Register.Day10Part2(InOutUtils.ReadDay10("Day10.txt"));
            Register.Day11(InOutUtils.ReadDay11("Day11.txt"));
            InOutUtils.SolveDay12("Day12.txt");
            Console.WriteLine("Part 1: " + InOutUtils.Day15(2020, 0, 14, 6, 20, 1, 4));
            Console.WriteLine("Part 2: " + InOutUtils.Day15(30000000, 0, 14, 6, 20, 1, 4));*/
            Register.Day18Part1("Day18.txt");
            Register.Day18Part2("Day18.txt");
            
            
            
            Console.ReadKey();


        }

    }

}

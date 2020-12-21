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
            char[,] map = InOutUtils.ReadDay3("Day3.txt");
            int tree = Register.Day3Part1Solve(map);
            InOutUtils.ReadDay4("Day4.txt");
            List<string> day5 = InOutUtils.ReadDay5("Day5.txt");
            Register.Day5Part1Solve(day5);
            InOutUtils.ReadDay6Part1("Day6.txt");
            InOutUtils.ReadDay6Part2("Day6.txt");*/
            Register.Day7Part1Solve(InOutUtils.ReadDay7("Day7.txt"));
           

            /*Part2
            List<string> Foundbags2 = new List<string>();
            for (int i = 0; i < copylist.Count; i++)
                if (copylist[i].Maincolor == "shiny gold")
                    for (int j = 0; j < copylist[i].bags.Count; j++)
                        for (int k = copylist[i].bags[j].Number - 1; k >= 0; k--)
                            Foundbags2.Add(copylist[i].bags[j].Color);

            for (int a = 0; a < Foundbags2.Count; a++)
                for (int i = 0; i < copylist.Count; i++)
                    if (copylist[i].Maincolor == Foundbags2[a])
                        for (int j = 0; j < copylist[i].bags.Count; j++)
                            for (int k = copylist[i].bags[j].Number - 1; k >= 0; k--)
                                Foundbags2.Add(copylist[i].bags[j].Color);



            Console.WriteLine(Foundbags.Count);
            Console.WriteLine(Foundbags2.Count);
            Console.ReadKey();*/
            Console.ReadKey();
            
        }

    }
    
}

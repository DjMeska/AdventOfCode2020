using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    class TasksUtils
    {
        public int Day1Solve(int[] numbers)
        {
            int ans = 0;
            int[] copy = new int[numbers.Length];
            bool foundTwoNum = false;
            Array.Copy(numbers, copy, numbers.Length);
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < copy.Length; j++)
                {
                    if(numbers[i] + copy[j] == 2020 && foundTwoNum == false)
                    {
                        ans = numbers[i] * copy[j];
                        foundTwoNum = true;
                    }
                }
            }
            return ans;
        }
        public int Day1Part2Solve(int[] numbers)
        {
            int ans = 0;
            bool foundTwoNum = false;
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < numbers.Length; j++)
                {
                    for (int z = 0; z < numbers.Length; z++)
                    {
                        if (numbers[i] + numbers[j] + numbers[z] == 2020 && foundTwoNum == false)
                        {
                            ans = numbers[i] * numbers[j] * numbers[z];
                            foundTwoNum = true;
                        }
                    }
                   
                }
            }
            return ans;
        }
        public int Day2Part1Solve(List<Day2> day2)
        {
            int wrongpass = day2.Count;
            foreach (Day2 day in day2)
            {
                int CorrectLetters = 0;
                for (int i = 0; i < day.pass.Length; i++)
                {
                    
                    if(day.pass[i]==day.Letter)
                    {
                        CorrectLetters++;
                    }
                }
                if(CorrectLetters >= day.Num1 && CorrectLetters <= day.Num2)
                {
                    //Good job
                }
                else
                {
                    wrongpass--;
                }
            }
            return wrongpass;
        }
        public int Day2Part2Solve(List<Day2> day2)
        {
            int wrongpass = 0;
            foreach (Day2 day in day2)
            {
                bool FirstPos = false;
                bool SecondPos = false;
                bool longerThanPass = false;
                if (day.Num1-1 > day.pass.Length || day.Num2-1 > day.pass.Length)
                {
                    longerThanPass = true;
                }
                if(!longerThanPass)
                {
                    if (day.pass[day.Num1-1] == day.Letter)
                        FirstPos = true;
                    if (day.pass[day.Num2-1] == day.Letter)
                        SecondPos = true;
                }
                if ((FirstPos == true && SecondPos == false) || (FirstPos == false && SecondPos == true))
                {
                    wrongpass++;
                }
            }
            return wrongpass;
        }
        public int Day3Part1Solve(Char[,] map)
        {
            //First 65
            //Second 237
            //Third 59
            //Fourth 61
            //Fith 38
            int tree = 0;
            int x_pos = 1;
            int y_pos = 1;
            while(y_pos < 324) 
            {
                
                if (x_pos >=31)
                {
                    x_pos = 1;
                  
                }
                /*else if (x_pos >= 30)
                {
                    x_pos = 2;
                   
                }
                else if (x_pos >= 29)
                {
                    x_pos = 1;
                    
                }*/
                else
                {
                    x_pos += 1;
                }
                if(y_pos +2 > 324)
                {
                    y_pos++;
                }
                else
                {
                    y_pos += 2;
                }
                   

                if(map[y_pos-1,x_pos-1] == '#')
                {
                    tree++;
                }
            } 
            return tree;
        }
        public int Day5Part1Solve(List<string> day5)
        {
            int lowest = int.MaxValue;
            int highest = 0;
            int sum = 0;
            for (int i = 0; i < day5.Count; i++)
            {
                string seat = day5[i];
                int id = 0;
                for (int j = 0; j < seat.Length; j++)
                {
                    if (seat[j] == 'B' || seat[j] == 'R')
                    {
                        id |= 1 << (9 - j);
                    }
                }

                sum += id;

                if (id > highest)
                {
                    highest = id;
                }
                else if (id < lowest)
                {
                    lowest = id;
                }
            }

            // Part 1
            Console.WriteLine($"id: {highest}");

            // Part 2
            int n = day5.Count;
            int mySeat = ((n + 1) * (n + (2 * lowest)) / 2) - sum;
            Console.WriteLine($"seat: {mySeat}");
            return 0;
        }

        public int Day7Part1Solve(List<Got> day7)
        {
            List<string> Foundbags = new List<string>();
            List<Got> copylist = day7;
            for (int i = 0; i < day7.Count; i++)
                for (int j = 0; j < day7[i].bags.Count; j++)
                    if (day7[i].bags[j].Color == "shiny gold")
                    {
                        Foundbags.Add(day7[i].Maincolor);
                        day7.RemoveAt(i);
                        i--;
                        break;
                    }
            for (int a = 0; a < Foundbags.Count; a++)
            {
                for (int i = 0; i < day7.Count; i++)
                    for (int j = 0; j < day7[i].bags.Count; j++)
                        if (day7[i].bags[j].Color == Foundbags[a])
                        {
                            Foundbags.Add(day7[i].Maincolor);
                            day7.RemoveAt(i);
                            i--;
                            break;
                        }
            }
            Console.WriteLine(Foundbags.Count);
            //Console.WriteLine(Foundbags2.Count);

            return Foundbags.Count;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdventOfCode2020
{
    class InOutUtils
    {
        public static int[] Day1(string fileName)
        {

            int[] numbers = new int[999];
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);
            for (int i = 0; i < Lines.Length; i++)
            {
                numbers[i] = int.Parse(Lines[i]);
            }
            return numbers;
        }
        public static List<Day2> ReadDay2(string fileName)
        {

            List<Day2> day2 = new List<Day2>();
            string[] Lines = File.ReadAllLines(fileName);
            foreach (string line in Lines)
            {
                string[] Values = line.Split('-', ' ', ':');
                int num1 = Convert.ToInt32(Values[0]);
                int num2 = Convert.ToInt32(Values[1]);
                char letter = Convert.ToChar(Values[2]);
                string pass = Values[4];
                Day2 day2new = new Day2(num1, num2, letter, pass);
                if (!day2.Contains(day2new))
                    day2.Add(day2new);

            }
            return day2;

        }
        public static Char[,] ReadDay3(string fileName)
        {
            Char[,] map = new char[324, 32];
            string[] Lines = File.ReadAllLines(fileName);
            for (int i = 0; i < Lines.Count(); i++)
            {
                string line = Lines[i];
                for (int j = 0; j < line.Length; j++)
                {
                    map[i, j] = line[j];
                }

            }
            return map;
        }
        public static List<Day4> ReadDay4(string fileName)
        {
            List<Day4> allData = new List<Day4>();
            string[] blocks = File.ReadAllText(fileName, Encoding.UTF8).Split(new string[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            
            for (int i = 0; i < blocks.Count(); i++)
            {

                blocks[i] = blocks[i].Replace('\r',' ');
                blocks[i] = blocks[i].Replace('\n', ' ');
                blocks[i] = string.Join(" ", blocks[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
                string[] Values = blocks[i].Split(' ');
                string[] dataClass = new string[8];
                for (int j = 0; j < Values.Count(); j++)
                {
                    string dataType = Values[j].Substring(0, 3);
                    string data = Values[j].Substring(4, Values[j].Length-4);
                    
                    if (dataType == "byr")
                    {
                        dataClass[0] = data;
                    }
                    if (dataType == "iyr")
                    {
                        dataClass[1] = data;
                    }
                    if (dataType == "eyr")
                    {
                        dataClass[2] = data;
                    }
                    if (dataType == "hgt")
                    {
                        dataClass[3] = data;
                    }
                    if (dataType == "hcl")
                    {
                        dataClass[4] = data;
                    }
                    if (dataType == "ecl")
                    {
                        dataClass[5] = data;
                    }
                    if (dataType == "pid")
                    {
                        dataClass[6] = data;
                    }
                    if (dataType == "cid")
                    {
                        dataClass[7] = data;
                    }
                    
                }
                if(dataClass[7] == null)
                {
                    dataClass[7] = "Ignore";
                }
               
                if (dataClass.Contains(null))
                {
                    //skips
                }
                else
                {
                    Day4 temp = new Day4(dataClass[0], dataClass[1], dataClass[2], dataClass[3], dataClass[4], dataClass[5], dataClass[6], dataClass[7]);
                    allData.Add(temp);
                }

                

            }
            List<Day4> Returned = new List<Day4>();
            for (int i = 0; i < allData.Count(); i++)
            {
                //bool wow = allData[i].CheckIfValid;
                if (allData[i].CheckIfValid == true)
                {
                    Returned.Add(allData[i]);
                }
            }
            return Returned;

        }
        public static List<string> ReadDay5(string fileName)
        {
            List<string> allData = new List<string>();
            string[] Lines = File.ReadAllLines(fileName);
            allData = Lines.ToList();
            return allData;
        }
        public static int ReadDay6Part1(string fileName)
        {
            int result = 0;
            List<Dictionary<char, int>> answers = new List<Dictionary<char, int>>();
            string input = File.ReadAllText(fileName, Encoding.UTF8);
            var groups = input.Replace("\r", "").Replace("\n\n", "@").Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string group in groups)
            {
                string cleaned = group.Replace(" ", "").Replace("\n", "");
                Dictionary<char, int> groupAnswers = new Dictionary<char, int>();
                foreach (char answer in cleaned)
                {
                    groupAnswers[answer] = groupAnswers.TryGetValue(answer, out int occurence) ? occurence + 1 : 1;
                   
                }
                answers.Add(groupAnswers);
                result += groupAnswers.Count;
                Console.WriteLine($"Group {answers.Count}: {groupAnswers.Count} (running total: {result})");
            }

            return result;
        }
        public static int ReadDay6Part2(string fileName)
        {
            int result = 0;
            List<HashSet<char>> answers = new List<HashSet<char>>();
            string input = File.ReadAllText(fileName, Encoding.UTF8);
            var groups = input.Replace("\r", "").Replace("\n\n", "@").Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string group in groups)
            {
                string[] people = group.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                HashSet<char> everyBody = new HashSet<char>(people[0]);

                for (int i = 1; i < people.Length; i++)
                {
                    everyBody.IntersectWith(new HashSet<char>(people[i]));
                    if (everyBody.Count == 0)
                        break;
                }
                answers.Add(everyBody);
                result += everyBody.Count;
                Console.WriteLine($"Group {answers.Count}: {everyBody.Count} (running total: {result})");
            }

            return result;
        }
        public static List<Got> ReadDay7(string fileName)
        {
            List<string> list = new List<string>(File.ReadAllLines("Day7.txt"));
            List<Got> mainbag = new List<Got>();
            foreach (var line in list)
            {
                string[] value = line.Split(' ');
                Got one = new Got();
                one.bags = new List<Bag>();
                one.Maincolor = value[0] + " " + value[1];
                Bag second = new Bag();
                for (int i = 4; i < value.Length; i++)
                {
                    if (value.Length > 7)
                    {
                        second.Number = Convert.ToInt32(value[i]); i += 2;
                        second.Color = value[i - 1] + " " + value[i]; i++;
                    }
                    else
                    {
                        second.Number = 0;
                        second.Color = "No other bag";
                    }
                    one.bags.Add(second);
                    second = new Bag();
                }
                mainbag.Add(one);
            }
            return mainbag;
        }

    }    
}




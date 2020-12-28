using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

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
                    if (numbers[i] + copy[j] == 2020 && foundTwoNum == false)
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

                    if (day.pass[i] == day.Letter)
                    {
                        CorrectLetters++;
                    }
                }
                if (CorrectLetters >= day.Num1 && CorrectLetters <= day.Num2)
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
                if (day.Num1 - 1 > day.pass.Length || day.Num2 - 1 > day.pass.Length)
                {
                    longerThanPass = true;
                }
                if (!longerThanPass)
                {
                    if (day.pass[day.Num1 - 1] == day.Letter)
                        FirstPos = true;
                    if (day.pass[day.Num2 - 1] == day.Letter)
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
            while (y_pos < 324)
            {

                if (x_pos >= 31)
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
                if (y_pos + 2 > 324)
                {
                    y_pos++;
                }
                else
                {
                    y_pos += 2;
                }


                if (map[y_pos - 1, x_pos - 1] == '#')
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

            Console.WriteLine(Foundbags2.Count);


            return Foundbags.Count;
        }
        public int Day8Part1(List<Day8> day8)
        {
            int i = 0;
            int acc = 0;
            int memory = 0;
            while (day8[i].Executed == false)
            {

                if (day8[i].Type == "acc")
                {
                    day8[i].Executed = true;
                    acc += day8[i].Values;
                    i++;
                }
                memory = i;
                if (day8[i].Type == "jmp")
                {
                    day8[i].Executed = true;
                    i += day8[i].Values;
                }
                if (day8[i].Type == "nop")
                {
                    day8[i].Executed = true;
                    i++;
                }
                Console.WriteLine(day8[i].Type + " " + day8[i].Values);

            }
            return acc;
        }
        public void Day9Solve(List<long> Nums)
        {
            long invalid = 0;
            for (int i = 25; i < Nums.Count; i++)
            {
                bool found = false;
                for (int j = i - 25; j < i - 1; j++)
                {
                    for (int k = j + 1; k < i; k++)
                    {
                        if (Nums[j] + Nums[k] == Nums[i])
                        {
                            found = true;
                            break;
                        }
                    }
                    if (found) break;
                }
                if (!found)
                {
                    invalid = Nums[i];
                    //Console.WriteLine($"Part 1: {invalid}");
                    break;
                }
            }

            for (int i = 0; i < Nums.Count; i++)
            {
                long sum = Nums[i];
                long smallest = sum;
                long largest = sum;

                for (int j = i + 1; j < Nums.Count; j++)
                {
                    sum += Nums[j];
                    if (sum > invalid)
                        break;
                    if (Nums[j] < smallest)
                        smallest = Nums[j];
                    if (Nums[j] > largest)
                        largest = Nums[j];
                    if (sum == invalid)
                    {
                        //Console.WriteLine($"Part 2: {smallest + largest}");
                        return;
                    }
                }
            }
        }
        public void Day10Part1(List<int> joltages)
        {
            int[] joltageRangeCounts = new int[3];  //Stores the histogram of joltages for gaps of 1,2, and 3 (in positions 0,1,2)
            GenerateJoltageHistogram(joltageRangeCounts, joltages);
            int oneJoltDifferences = joltageRangeCounts[0];
            int threeJoltDifferences = joltageRangeCounts[2];


            Console.WriteLine($"1-jolt Differences: {oneJoltDifferences}");
            Console.WriteLine($"3-jolt Differences: {threeJoltDifferences}");
            Console.WriteLine($"1-jolt differences multiplied by 3-jolt differences: { oneJoltDifferences * threeJoltDifferences}");
        }
        void GenerateJoltageHistogram(int[] joltageRangeCounts, List<int> joltages)
        {
            for (int i = 0; i < joltages.Count - 1; i++)
            {
                int joltageRange = joltages[i + 1] - joltages[i];

                joltageRangeCounts[joltageRange - 1]++;
            }
        }
        public void Day10Part2(List<int> joltages)
        {
            List<int> oneJoltRunLengths = new List<int>();
            int contiguousCount = 0;
            for (int i = 0; i < joltages.Count - 1; i++)
            {
                if (joltages[i + 1] - joltages[i] == 1)
                {
                    contiguousCount++;
                }
                else
                {
                    contiguousCount--;
                    if (contiguousCount >= 1)
                    {
                        oneJoltRunLengths.Add(contiguousCount);
                    }
                    contiguousCount = 0;
                }

            }
            long totalCombinations = 1;
            int[] runCombinations = { 1, 2, 4, 7 };
            foreach (int c in oneJoltRunLengths)
            {
                totalCombinations *= runCombinations[c];
            }

            Console.WriteLine($"Total number of adapter combinations: {totalCombinations}");
        }
        public void Day11(List<string> input)
        {
            List<string> _seat = new List<string>();
            foreach (var item in input)
            {
                var temp = Regex.Replace(item, @"\t|\n|\r", "");
                if (temp.Length != 0) _seat.Add(temp);
            }
            char[][][] seat = new char[_seat.Count][][];
            char[][][] newSeat = new char[_seat.Count][][];
            for (int i = 0; i < _seat.Count; i++)
            {
                seat[i] = new char[_seat[i].Length][];
                newSeat[i] = new char[_seat[i].Length][];
                for (int j = 0; j < _seat[0].Length; j++)
                {
                    seat[i][j] = new char[2];
                    seat[i][j][0] = _seat[i][j];
                    seat[i][j][1] = _seat[i][j];

                    newSeat[i][j] = new char[2];
                    newSeat[i][j][0] = _seat[i][j];
                    newSeat[i][j][1] = _seat[i][j];
                }
            }
            bool didChange = false;
            int run = 0;
            while (true)
            {
                didChange = false;
                for (int i = 0; i < _seat.Count; i++)
                {
                    for (int j = 0; j < _seat[0].Length; j++)
                    {
                        for (int k = 0; k < 2; k++)
                        {
                            int neighbors = 0;
                            if (seat[i][j][k] != '.')
                            {
                                for (int x = -1; x <= 1; x++)
                                {
                                    for (int y = -1; y <= 1; y++)
                                    {
                                        if (x == 0 && y == 0) continue;
                                        int s = 1;
                                        while ((0 <= (i + x * s) && (i + x * s) < _seat[0].Length) && (0 <= (j + y * s) && (j + y * s) < _seat.Count))
                                        {
                                            if (seat[i + x * s][j + y * s][k] == '#')
                                            {
                                                neighbors++;
                                                break;
                                            }
                                            if (seat[i + x * s][j + y * s][k] == 'L')
                                            {
                                                break;
                                            }
                                            if (k == 0) break;
                                            s++;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                newSeat[i][j][k] = '.';
                                continue;
                            }
                            if (neighbors >= 4 + k && seat[i][j][k] == '#')
                            {
                                newSeat[i][j][k] = 'L';
                                didChange = true;
                            }
                            else if (neighbors == 0 && seat[i][j][k] == 'L')
                            {
                                newSeat[i][j][k] = '#';
                                didChange = true;
                            }
                            else
                            {
                                newSeat[i][j][k] = seat[i][j][k];
                            }
                        }

                    }
                }
                for (int i = 0; i < seat.Length; i++)
                {
                    for (int j = 0; j < seat[i].Length; j++)
                    {
                        seat[i][j][0] = newSeat[i][j][0];
                        seat[i][j][1] = newSeat[i][j][1];
                    }
                }
                if (!didChange) break;
                run++;
            }
            int seats = 0;
            int seats2 = 0;
            for (int i = 0; i < seat.Length; i++)
            {
                for (int j = 0; j < seat[i].Length; j++)
                {
                    if (seat[i][j][0] == '#') seats++;
                    if (seat[i][j][1] == '#') seats2++;
                }
            }
            Console.WriteLine(seats);
            Console.WriteLine(seats2);

        }
        public void Day13Part1(string fileName)
        {
            string[] lines = File.ReadLines(fileName).ToArray();
            int departure = int.Parse(lines[0]);
            List<int> buses = new List<int>();

            foreach (string s in lines[1].Split(','))
            {
                if (s != "x")
                {
                    buses.Add(int.Parse(s));
                }
            }

            int bestTime = int.MaxValue;
            int bestService = -1;

            foreach (int bus in buses)
            {
                int time = bus;
                while (time < departure)
                {
                    time += bus;
                }
                if (bestTime - departure > time - departure)
                {
                    bestTime = time;
                    bestService = bus;
                }
            }

            Console.WriteLine("Timestamp: {0}", departure);
            Console.WriteLine("Best service: {0}, Best time: {1}", bestService, bestTime);
            Console.WriteLine("Wait time: {0}, Wait time X ID: {1}", bestTime - departure, bestService * (bestTime - departure));
        }
        private struct Pair
        {
            public uint id;
            public uint offset;
        }
        public void Day13Part2(string fileName)
        {
            string[] lines = File.ReadLines(fileName).ToArray();
            List<Pair> buses = new List<Pair>();

            uint i = 0;
            foreach (string s in lines[1].Split(','))
            {
                if (s != "x")
                {
                    Pair pair = new Pair
                    {
                        id = uint.Parse(s),
                        offset = i
                    };
                    buses.Add(pair);

                    Console.WriteLine("Service {0}, offset {1}", pair.id, pair.offset);
                }
                i++;
            }

            ulong step = buses[0].id;
            ulong departure = buses[0].id;

            foreach (Pair pair in buses.Skip(1))
            {
                while ((departure + pair.offset) % pair.id != 0)
                {
                    departure = checked(departure + step);
                }
                Console.WriteLine("Timestamp {0} is valid for service {1}", departure, pair.id);
                step = step * pair.id;
            }

            Console.WriteLine("First valid timestamp: " + departure);
        }

        
    }
}

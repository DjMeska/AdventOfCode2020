using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    class Day4
    {
        public string Byr { get; set; }
        public string Iyr { get; set; }
        public string Eyr { get; set; }
        public string Hgt { get; set; }
        public string Hcl { get; set; }
        public string Ecl { get; set; }
        public string Pid { get; set; }
        public string Cid { get; set; }

        public Day4(string byr, string iyr, string eyr, string hgt, string hcl, string ecl, string pid, string cid)
        {
            Byr = byr;
            Iyr = iyr;
            Eyr = eyr;
            Hgt = hgt;
            Hcl = hcl;
            Ecl = ecl;
            Pid = pid;
            Cid = cid;
        }
        public bool CheckIfValid
        {
            get
            {


                bool byear = false;
                if (Convert.ToInt32(this.Byr) >= 1920 && Convert.ToInt32(this.Byr) <= 2002)
                {
                    byear = true;
                }
                bool issueyear = false;
                if (Convert.ToInt32(this.Iyr) >= 2010 && Convert.ToInt32(this.Iyr) <= 2020)
                {
                    issueyear = true;
                }
                bool expyear = false;
                if (Convert.ToInt32(this.Eyr) >= 2020 && Convert.ToInt32(this.Eyr) <= 2030)
                {
                    expyear = true;
                }
                string mesurement = this.Hgt.Substring(this.Hgt.Length-2,2);
                string b = "";
                int height = 0;
                for (int i = 0; i < this.Hgt.Length; i++)
                {
                    if (Char.IsDigit(this.Hgt[i]))
                        b += this.Hgt[i];
                }
                if (b.Length > 0)
                    height = int.Parse(b);

                bool heightcheck = false;
                if (mesurement == "cm")
                {
                    if (height >= 150 && height <= 193)
                        heightcheck = true;

                }
                else
                {
                    if (height >= 59 && height <= 76)
                        heightcheck = true;

                }
                bool haircolor = false;
                
                if (this.Hcl.Length == 7 && this.Hcl[0] == '#' && this.Hcl.All(c => "#0123456789abcdef".Contains(c)))
                    haircolor = true;
                bool eyecolor = false;
                if (this.Ecl == "amb" || this.Ecl == "blu" || this.Ecl == "brn" || this.Ecl == "gry" || this.Ecl == "grn" || this.Ecl == "hzl" || this.Ecl == "oth")
                    eyecolor = true;
                bool passport = false;
                if (this.Pid.All(x => "0123456789".Contains(x)) && this.Pid.Length == 9)
                    passport = true;
                if (byear && issueyear && expyear && heightcheck && haircolor && eyecolor && passport)
                    return true;
                return false;
            }
        }

    }
}

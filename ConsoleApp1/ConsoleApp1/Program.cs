using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\Rafał\Desktop\afile.xls");
            fixStuff(file);
            Console.Read();
            /*
            DateTime D1, D2;
            int people;
            Dictionary<string, object> ROW;
            ArrayList ROWSet = new ArrayList();
            string line;
            bool first = true;
            while ((line = file.ReadLine()) != null)
            {
                ROW = new Dictionary<string, object>();
                string[] temp = line.Split(';');
                if (first)
                {
                    ROW.Add("D1", temp[0]);
                    ROW.Add("D2", temp[1]);
                    ROW.Add("OS", temp[2]);
                    ROWSet.Add(ROW);
                    first = false;
                    continue;
                }
                D1 = Convert.ToDateTime(temp[0]);
                D2 = Convert.ToDateTime(temp[1]);
                people = Int32.Parse(temp[2]);
                ROW.Add("D1", D1);
                ROW.Add("D2", D2);
                ROW.Add("OS", people);
                ROWSet.Add(ROW);
            }
            foreach (Dictionary<string, object> d in ROWSet)
            {
                Console.WriteLine(d["D1"] + "\t\t" + d["D2"] + "\t\t" + d["OS"]);
            }
            DateTime chk;
            first = true;

            for (int i = 1; i <= 31; i++)
            {
                chk = new DateTime(2016, 3, i);
                foreach (Dictionary<string, object> d in ROWSet)
                {
                    if (first)
                    {
                        Console.WriteLine("====================first line------------------");
                        first = false;
                        continue;
                    }
                    if (!first) ;
                    
                }
            }

            */

        }

        private static void fixStuff(StreamReader file)
        {
            string line;
            int i = 0;
            StringBuilder sb = new StringBuilder();
            
            sb.Append("sep=;\r\nID;NAZWA\r\n");
           // Regex.m
            while ((line = file.ReadLine()) != null)
            {
                if (Regex.Match(line,@".*\d{3}\-\d{3}.*|.*A\d{5}\/\d{2}").Length<=0)
                    continue;
                else
                {
                   // Console.WriteLine("B4 fix:"+line);
                    line = line.Replace("@|", "");
                    MatchCollection m = Regex.Matches(line.TrimEnd().TrimStart(), @"(\d{1,3}\-\d{1,3}\-\d{1,3}\-\d{1,3})\s+\-\s(.*)");
                    if(m.Count!=1)
                        m = Regex.Matches(line.TrimEnd().TrimStart(), @"(A\d{5}\/\d{2})\s+\-\s(.*)");
                    string lineout = m[0].ToString().Replace("  - ", ";").Replace(" ;",";").Replace("    ;",";");
                    Console.WriteLine(lineout);
                    sb.Append(lineout+"\r\n");
                }
                i++;
            }
            Console.WriteLine("Checked " + i + " lines...");
            File.WriteAllText(@"C:\Users\Rafał\Desktop\inewnt.csv",sb.ToString());
           // f.WriteLine(sb.ToString());
        }
    }
}

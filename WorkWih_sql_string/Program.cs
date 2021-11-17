using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWih_sql_string
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string problem = "MM:T-NKM2DEUC-1807.0:2021-10-18,MM:T-NKM2DEUC-1805.4:2021-09-15,MM:T-NKM2DEUC-1708.0:2021-08-27,MM:T-NKM2DEUC-1506.0:2021-08-12,MT:-A00M1U0M20:2020-12-14,SM:T-NM2INTV-1007:2021-11-03,SM:T-NM2INTV-1005:2021-07-23,SM:T-NM2INTV-1003:2021-05-11,SO:T-NKM-255149.2109071.2109150:2021-10-18,SO:T-NKM-254148.2108311.2108200:2021-09-15,SO:T-NKM-254147.2108201.2108200:2021-08-27,SO:T-NKM-252141.2107071.2108020:2021-08-12,SO:T-NKM-249138.2107071.2107300:2021-08-05";
            problem = UniqueSW(problem);
            Console.WriteLine(problem);

        }
        public static string UniqueSW(string problem)
        {            
            string[] vs = { "MM", "SM", "SO", "MT" };
            Dictionary<string, string> filteredCollection = new Dictionary<string, string>();
            foreach (string key in vs)
                if (!filteredCollection.ContainsKey(key))
                    filteredCollection.Add(key, null);
            string[] sw_list = problem.Split(new char[] { ',' }); ;
            foreach (string s in sw_list)
            {
                foreach (string header in vs)
                {
                    if (s.StartsWith(header) && filteredCollection[header] == null)
                        filteredCollection[header] = s;
                }
            }
            string filteredCollectionstr = string.Join(",", filteredCollection.Values);
            return filteredCollectionstr;
        }
    }
}

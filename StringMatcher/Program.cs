using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringMatcher
{
    class Program
    {
        const string fileName = "data.txt";
        static Dictionary<string, string> Data = new Dictionary<string, string>();
        static Dictionary<string, string> lines = new Dictionary<string, string>();
        static string line;
        static string sortedString;
        static string input;

        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    sortedString = Utils.SortString(line);
                    if (!lines.ContainsKey(sortedString))
                    {
                        lines.Add(sortedString, line);
                    }

                }
                reader.Close();
            }
            //input = new String();
            while (true)
            {
                while (string.IsNullOrEmpty(input) || input.Length != 5)
                {
                    Console.WriteLine("Please enter a 5 character string: ");
                    input = Console.ReadLine();
                }
                input = Utils.SortString(input);
                if (lines.ContainsKey(input))
                    Console.WriteLine("First match found in data: {0}.", lines[input]);
                else
                    Console.WriteLine("No match found.");
                input = null;
            }

        }
    }
}
        
   


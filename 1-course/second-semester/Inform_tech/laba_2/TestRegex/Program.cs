using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestRegex
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var text = "hello ss kitty dd, i'm eath test";
            var words = new String[] {"dd", "ss", "test"};
            var minWordLength = 2;

            var minLengthWords = words.Where(w => w.Length == minWordLength).ToArray();

            foreach (var word in minLengthWords)
            {
                Regex regExp = new Regex(@"\b" + word + @"\b");

                foreach (Match match in regExp.Matches(text))
                {
                    Console.WriteLine(match.Index);
                //rtb.Select(match.Index, match.Length);
                //rtb.SelectionColor = Color.Blue;
                }
            }
 
            Console.ReadKey();
        }
    }
}

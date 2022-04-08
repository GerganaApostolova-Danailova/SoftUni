using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._Match_Phone_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            var regex = @"\+359([ -])2\1\d{3}\1\d{4}\b";

            var phones = Console.ReadLine();

            var phoneMaches = Regex.Matches(phones, regex);

            var machedPhone = phoneMaches
                .Cast<Match>()
                .Select(a => a.Value.Trim())
                .ToArray();

            Console.Write(string.Join(", ", machedPhone));
        }
    }
}

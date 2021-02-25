using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ExampleCodes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string email = "aabc @gmail.com";
            bool match = false;
            
            match = IsValidEmail(email);
            Console.WriteLine($">> result: {match}");
        }

        private static bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }

            try
            {
                email = Regex.Replace(email,
                    @"(@)(.+)$",
                    DomainMapper,
                    RegexOptions.None);
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase);
            }
            catch
            {
                return false;
            }
        }

        private static string DomainMapper(Match match)
        {
            Console.WriteLine(match.Groups[0].Value, 
                match.Groups[1].Value,
                match.Groups[2].Value);
            
            var idn = new IdnMapping();
            string domainName = idn.GetAscii(match.Groups[2].Value);
            return match.Groups[1].Value + domainName;
        }
    }
}
using System.Text.RegularExpressions;

namespace _03.Strings2
{
    public class UpperCaseMaker
    {
        public string Run(string text)
        {
            string pattern = @"(<upcase>)(.*?)(<\/upcase>)";
            return Regex.Replace(text, pattern, match => match.Groups[2].Value.ToUpper());
        }
    }
}

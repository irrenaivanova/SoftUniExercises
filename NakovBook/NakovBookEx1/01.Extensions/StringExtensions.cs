namespace _01.Extensions
{
    public static class StringExtensions
    {
        public static string ToTitleCase (this string str) 
        {
            var words = str.Split (' ',StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i< words.Length; i++)
            {
                words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
            }
            return string.Join (" ", words);
        }
    }
}

using System.Text;

namespace _01.Extensions
{
    public static class StringBuilderExtensions
    {
        public static string Substring (this StringBuilder sb, int index, int length)
        {
            StringBuilder sb2 = new StringBuilder ();
            for (int i = index; i < Math.Min(sb.Length,index+length); i++)
            {
                sb2.Append(sb[i]);
            }
            return sb2.ToString();
        }
    }
}

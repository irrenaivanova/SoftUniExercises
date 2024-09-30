namespace SUS.HTTP
{
    public class Cookie
    {
        public Cookie (string name, string value)
        {
            Name= name; Value = value;
        }
        public Cookie(string cookiesString)
        {
            var cookieParts = cookiesString.Split(new char[] { '=' },2);
            Name = cookieParts[0];
            Value = cookieParts[1];
        }

        public string Name { get; set; }
        public string Value { get; set; }
    }
}
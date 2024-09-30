namespace SUS.HTTP
{
    public class Header
    {
        public Header(string name, string value)
        {
            Name = name;
            Value =value;
        }
        public Header(string headerString)
        {
            var headersArg = headerString.Split(new string[] { ": " }, 2, StringSplitOptions.RemoveEmptyEntries);
            Name = headersArg[0];
            Value = headersArg[1];
        }
    

        public string Name { get; set; }
        public string Value { get; set; }
    }
}
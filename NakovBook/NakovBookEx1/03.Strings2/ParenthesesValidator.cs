namespace _03.Strings2
{
    public class ParenthesesValidator
    {
        private string text;

        public ParenthesesValidator(string text)
        {
            this.text = text;
        }

        public bool Validate()
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }

            List<int> openingP = CountRepetition('(');
            List<int> closingP = CountRepetition(')');

            if (openingP.Count != closingP.Count)
            { 
                return false; 
            }
            if (openingP.Max() > closingP.Min())
            {
                return false;
            }
            return true;
        }

        private List<int> CountRepetition(char v)
        {
            var list = new List<int>();
            int indexOp = text.IndexOf(v);
            while (indexOp != -1)
            {
                list.Add(indexOp);
                indexOp = text.IndexOf(v, indexOp + 1);
            }
            return list;
        }
    }
}

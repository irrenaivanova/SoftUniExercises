namespace WebApi2.Models
{
    public class OutputSums
    {
        public OutputSums(int alan, int bob, List<int> alanTakes)
        {
            Alan = alan;
            Bob = bob;
            AlanTakes = alanTakes;
        }

        public int Alan { get; set; }

        public int Bob { get; set; }

        public List<int> AlanTakes { get; set; } = new List<int>();
    }
}

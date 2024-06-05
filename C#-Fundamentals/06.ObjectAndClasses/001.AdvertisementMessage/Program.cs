using _001.AdvertisementMessage;
using System;
int n = int.Parse(Console.ReadLine());
Advert phrases = new Advert(new List<string>()
 {
     "Excellent product.",
     "Such a great product.",
     "I always use that product.",
     "Best product of its category.",
     "Exceptional product.",
     "I can't live without this product."
 });

Advert events = new Advert(new List<string>()
    {
    "Now I feel good.",
    "I have succeeded with this product.",
    "Makes miracles. I am happy of the results!",
    "I cannot believe but now I feel awesome.",
    "Try it yourself, I am very satisfied.",
    "I feel great!"
    });

Advert authors = new Advert(new List<string>()
{
"Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva"
});

Advert cities = new Advert(new List<string>()
    { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" });




for (int i = 0; i < n; i++)
{
    Console.WriteLine($"{phrases.GetRandomWord()} {events.GetRandomWord()} {authors.GetRandomWord()} – {cities.GetRandomWord()}.");
}

namespace _001.AdvertisementMessage
{
    public class Advert
    {
        public Advert(List<string> phrases)
        {
            Phrases = phrases;
        }
        public List<string> Phrases { get; set; }

        public string GetRandomWord()
        {
            Random number = new Random();
            return Phrases[number.Next(Phrases.Count)];
        }

    }
}
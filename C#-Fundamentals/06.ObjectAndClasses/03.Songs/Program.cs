using _03.Songs;

int n = int.Parse(Console.ReadLine());
Song[] songs = new Song[n];

for (int i = 0; i < n; i++)
{
    string[] input = Console.ReadLine().Split("_");
    songs[i] = new Song(input[0], input[1], input[2]);
}

string printList = Console.ReadLine();

foreach (Song song in songs)
{
    if (song.Type == printList)
        Console.WriteLine(song.Name);
    if (printList == "all")
        Console.WriteLine(song.Name);
}
namespace _03.Songs
{
    internal class Song
    {
        public Song(string type, string name, string time)
        {
            Type = type;
            Name = name;
            Time = time;

        }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
    }
}
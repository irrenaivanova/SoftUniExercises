using System.Text;

string[] mazeInput = new string[]
{
    "010001",
    "01010E",
    "010100",
    "000000"
};

string[] newInput = new string[]
{
        "1010001E",
        "00100100",
        "01101101",
        "01100101",
        "01110101",
        "00110100",
        "10000010",
        "00111000",
};
var maze = new MazePathFinder(newInput);
Console.WriteLine(string.Join("\n",maze.FindAllPaths(7,0)));
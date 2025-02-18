string[] mazeInput = new string[]
{
    "010001",
    "01010E",
    "010100",
    "000000"
};
var maze = new MazePathFinder(mazeInput);

public class MazePathFinder
{
    public MazePathFinder(string[] maze)
    {
        Maze = maze;
    }

    public string[] Maze { get; set; }




}
//string[] maze = new string[]
//{
//    "010001",
//    "01010E",
//    "010100",
//    "000000"
//};

int n = int.Parse(Console.ReadLine());
int m = int.Parse(Console.ReadLine());
string[] maze = new string[n];
for (int i = 0; i < n; i++)
{
    maze[i] = Console.ReadLine();
}

bool[,] visited = new bool[maze.Length,maze[0].Length];

GetThePaths(maze, 0, 0, visited, "");

void GetThePaths(string[] maze, int row, int col, bool[,] visited, string path)
{
    if (maze[row][col] =='e')
    {
        Console.WriteLine(path);
        return;
    }
    
    visited[row,col] =true;
     if(isSafe(maze,row+1,col,visited))
    {
        GetThePaths(maze, row + 1, col, visited, path+"D");
    }
    if (isSafe(maze, row - 1, col,visited))
    {
        GetThePaths(maze, row - 1, col, visited, path + "U");
    }
    if (isSafe(maze, row, col+1,visited))
    {
        GetThePaths(maze, row, col+1, visited, path + "R");
    }
    if (isSafe(maze, row, col - 1, visited))
    {
        GetThePaths(maze, row, col -1, visited, path + "R");
    }

    visited[row,col] = false;
}

bool isSafe(string[] maze, int row, int col,bool[,] visited)
{
    if (row < 0 || col < 0 || row >= maze.Length || col >= maze[0].Length)
    {
        return false;
    }
    if (visited[row,col] || maze[row][col]=='*')
    {
        return false;
    }
    return true;
}
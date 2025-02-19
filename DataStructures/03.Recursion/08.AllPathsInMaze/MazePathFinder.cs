// state retention across multiple calls because of the private fields visited and paths
public class MazePathFinder
{
    private readonly string[] maze;
    private bool[,] visited;
    private List<string> paths;
    public MazePathFinder(string[] maze)
    {
        this.maze = maze;
        this.visited = new bool[maze.Length,maze[0].Length];
        this.paths = new List<string>();
    }


    public List<string> FindAllPaths(int startRow, int startCol)
    {
        FindPath(startRow, startCol, "");
        return new List<string>(paths);
    }

    private void FindPath(int row, int col, string path)
    {
        if (maze[row][col] == 'E')
        {
            paths.Add(path);
            return;
        }

        visited[row, col] = true;

        if (IsSafe(row+1,col))
        {
            FindPath(row+1, col, path + 'D');
        }

        if (IsSafe(row - 1, col))
        {
            FindPath(row - 1, col, path + 'U');
        }

        if (IsSafe(row, col+1))
        {
            FindPath(row, col+1, path + 'R');
        }

        if (IsSafe(row, col - 1))
        {
            FindPath(row, col - 1, path + 'L');
        }

        visited[row, col] = false;
    }

    private bool IsSafe(int row, int col)
    {
        if (row < 0 || row >= maze.Length || col < 0 || col >= maze[0].Length)
        {
            return false;
        }
        if (visited[row, col] || maze[row][col] == '1')
        {
            return false;
        }

        return true;
    }
}


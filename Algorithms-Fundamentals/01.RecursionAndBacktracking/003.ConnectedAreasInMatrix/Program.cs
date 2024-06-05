int n = int.Parse(Console.ReadLine());
int m = int.Parse(Console.ReadLine());
List<Area> areas = new();

char[,] maze = new char[n, m];

for (int i = 0; i < n; i++)
{
    string input = Console.ReadLine();
    for (int j = 0; j < m; j++)
    {
        maze[i, j] = input[j];
    }
}

while(true)
{
    (int startRow, int startColumn) = FindTheSTart(maze);
    
    if (startRow == -1)
    {
        break;
    }
    areas.Add(new Area(startRow, startColumn, GetTheArea(maze, startRow, startColumn)));
}
areas = areas.OrderByDescending(x=>x.Size).ThenBy(x=>x.Row).ThenBy(x=>x.Column).ToList();
Console.WriteLine($"Total areas found: {areas.Count}");
int count = 1;
foreach (var area in areas)
{
    Console.WriteLine($"Area #{count++} at ({area.Row}, {area.Column}), size: {area.Size}");
}


(int startRow, int startColumn) FindTheSTart(char[,] maze)
{
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            if (maze[i, j] != 'v' && maze[i, j] != '*')
            {
                return (i,j);
            }
        }
    }
    return (-1, -1);
}

int GetTheArea(char[,] maze, int row, int col)
{
    int size = 1;
    
    maze[row, col] = 'v';
    
    if (IsSafe(maze,row+1,col))
    { 
        size += GetTheArea(maze, row + 1, col);
    }
    else if (IsSafe(maze, row -1 , col))
    {
        size += GetTheArea(maze, row-1, col);
    }
    else if (IsSafe(maze, row, col+1))
    {
        size += GetTheArea(maze, row, col+1);
    }
    else if (IsSafe(maze, row, col-1))
    {
        size += GetTheArea(maze, row, col-1);
    }
    else
    {
        return 1;
    }
    return size;
}

bool IsSafe(char[,] maze, int row, int col)
{
    if (row < 0 || col < 0 || row >= maze.GetLength(0) || col >= maze.GetLength(1))
    {
        return false;
    }
    if (maze[row,col] == '*' || maze[row,col] == 'v')
    {
        return false;
    }
    return true;
}

public class Area
{
    public Area(int row, int column, int size)
    {
        Size = size;
        Row = row;
        Column = column;
    }

    public int Size { get; set; }

    public int Row { get; set; }
    public int Column { get; set; }
}
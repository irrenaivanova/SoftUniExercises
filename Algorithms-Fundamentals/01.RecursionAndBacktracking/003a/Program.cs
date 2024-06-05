using System.Runtime.CompilerServices;

int n = int.Parse(Console.ReadLine());
int m = int.Parse(Console.ReadLine());
List<Area> areas = new();
int size = 0;

char[,] maze = new char[n, m];

for (int i = 0; i < n; i++)
{
    string input = Console.ReadLine();
    for (int j = 0; j < m; j++)
    {
        maze[i, j] = input[j];
    }
}

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
    {
        if (maze[i, j] != '*' || maze[i, j] != 'v')
        {
            size = 0;
            
            ExploreArea(i, j);
            
            if (size != 0)
            {
                areas.Add(new Area(i, j, size));
            }
        }
    }
}
areas = areas.OrderByDescending(x => x.Size).ThenBy(x => x.Row).ThenBy(x => x.Column).ToList();
Console.WriteLine($"Total areas found: {areas.Count}");
int count = 1;
foreach (var area in areas)
{
    Console.WriteLine($"Area #{count++} at ({area.Row}, {area.Column}), size: {area.Size}");
}

void ExploreArea (int row, int col)
{
    if (IsOutSide(row, col) || IsWall(row,col) || IsVisited (row,col))
    {
        return;
    }

    size += 1;
    maze[row, col] = 'v';
    ExploreArea(row - 1, col);
    ExploreArea(row + 1, col);
    ExploreArea(row , col - 1);
    ExploreArea(row, col + 1);
}

bool IsVisited(int row, int col)
{
    return maze[row, col] == 'v';
}

bool IsWall(int row, int col)
{
    return maze[row, col] == '*';
}

bool IsOutSide(int row, int col)
{
    if (row < 0 || col < 0 || row >= maze.GetLength(0) || col >= maze.GetLength(1))
    {
        return true;
    }
    return false;
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
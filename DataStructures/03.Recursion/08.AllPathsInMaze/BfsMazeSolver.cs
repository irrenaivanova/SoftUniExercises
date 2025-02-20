namespace _08.AllPathsInMaze
{

    public class BfsMazeSolver
    {
        private static readonly List<int[]> Directions = new List<int[]>
        {
                new int[2] { 1, 0 },
                new int[2] { -1, 0 },
                new int[2] { 0, 1 },
                new int[2] { 0, -1 }
        };

        private readonly string[] inputMaze = null!;
        private int[,] maze;
        private Queue<Point> points = new Queue<Point>();
        private Dictionary<Point,Point> cameFrom = new Dictionary<Point,Point>();
        private Point startPoint;
        public BfsMazeSolver(string[] inputMaze)
        {
            if (inputMaze == null || inputMaze.Length == 0)
            {
                throw new ArgumentNullException(nameof(inputMaze));
            }

            maze = new int[inputMaze.Length,inputMaze[0].Length];
            for (int i = 0; i < inputMaze.Length; i++)
            {
                for(int j = 0; j < inputMaze[i].Length; j++)
                {
                    if (inputMaze[i][j] == 'E')
                    {
                        maze[i, j] = 2;
                        continue;
                    }
                    maze[i,j] = int.Parse(inputMaze[i][j].ToString());
                }
            }
        }

        public string FindTheShortestPath(int row, int col)
        {
            startPoint = new Point(row, col);
            if (!IsValidMove(row, row))
            {
                throw new ArgumentException("Invalid start point");
            }

            points.Enqueue(startPoint);
            maze[row,col] = -1;

            while (points.Count > 0)
            {
                var currentPoint = points.Dequeue();

                foreach (var direction in Directions)
                {
                    int newRow = currentPoint.Row + direction[0];
                    int newCol = currentPoint.Col + direction[1];

                    if (IsValidMove(newRow, newCol))
                    {
                        var next = new Point(newRow, newCol);
                        points.Enqueue(next);
                        cameFrom[next] = currentPoint;
                        if (maze[next.Row, next.Col] == 2)
                        {
                            return TrackThePath(next);
                        }
                        maze[next.Row, next.Col] = -1;     
                    }
                }
            }
            return "No Path";
        }

        private string TrackThePath(Point current)
        {
            Stack<Point> points = new Stack<Point>();
            points.Push(current);
            while(!current.Equals(startPoint))
            {
                current = cameFrom[current];
                points.Push(current);
            }

            return string.Join("\n",points.Select(x => $"Row: {x.Row}, Col: {x.Col}"));
        }

        private bool IsValidMove(int row, int col)
        {
            return row >= 0 && col >= 0 &&
                   row < maze.GetLength(0) &&
                   col < maze.GetLength(1) &&
                   maze[row, col] != 1 &&
                   maze[row, col] != -1;
        }

        public struct Point
        {
            public int Row;
            public int Col;

            public Point(int row, int col)
            {
                Row = row;
                Col = col;
            }
        }
    }
}

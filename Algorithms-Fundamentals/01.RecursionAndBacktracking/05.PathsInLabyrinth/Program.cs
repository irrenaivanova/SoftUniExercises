
using System;
using System.Collections;
using System.Collections.Generic;


namespace Algorithms
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            List<string> paths = new();

            char[,] maze = new char[n, m];

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < m; j++)
                {
                    maze[i, j] = input[j];
                }
            }

            bool[,] visited = new bool[n, m];
            string path = string.Empty;
            FindThePathes(maze, 0, 0,visited,"",paths);
        }

        private static void FindThePathes(char[,] maze, int row, int column, 
            bool[,] visited,string path, List<string> paths)
        {
            if (maze[row,column]=='e')
            {
                Console.WriteLine(path);
                paths.Add(path);
                return;
            }

            visited[row, column] = true;

            if (IsSafe(maze,row+1,column,visited))
            {
                FindThePathes(maze, row +1, column,visited,path+"D", paths);
            }
            if (IsSafe(maze, row - 1, column, visited))
            {
               
                FindThePathes(maze, row - 1, column, visited, path+"U", paths);
            }
            if (IsSafe(maze, row, column+1, visited))
            {
                
                FindThePathes(maze, row, column+1, visited, path+"R", paths);
            }
            if (IsSafe(maze, row, column - 1, visited))
            {
            
                FindThePathes(maze, row, column - 1, visited, path+"L", paths);
            }
            visited[row, column] = false;
        }

        private static bool IsSafe(char[,] maze, int row, int column, bool[,] visited)
        {
            if (row<0 || column<0 || row>=maze.GetLength(0) || 
                column>=maze.GetLength(1))
            {
                return false;
            }
            if (maze[row, column] == '*' || visited[row, column])
            {
                return false;
            }
            return true;
        }
    }
}
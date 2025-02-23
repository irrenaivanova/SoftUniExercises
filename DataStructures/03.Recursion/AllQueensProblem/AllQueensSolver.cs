namespace AllQueensProblem
{
    public class AllQueensSolver
    {
        private readonly int Size;
        private List<List<int>> Solutions;
        private bool IsSolved;
        private int[,] Queens;

        public AllQueensSolver(int size)
        {
            if (size <=0)
            {
                throw new ArgumentException("Size must be positive.");
            }
            Size = size;
            Solutions = new List<List<int>>();
            IsSolved = false;
            Queens = new int[Size,Size];
        }

        public int GetTheNumberOfSolutions()
        {
            if (!IsSolved)
            {
                Solve();
            }
            return Solutions.Count;
        } 
        
        public void PrintTheSolutions()
        {
            if (!IsSolved)
            {
                Solve();
            }

            foreach (var solution in Solutions)
            {
                PrintBoard(solution);
                Console.WriteLine();
            }
        }

        private void PrintBoard(List<int> queens)
        { 
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Console.Write(queens[i]==j ? "Q " : "* ");
                }
                Console.WriteLine();
            }
        }

        private void Solve() 
        { 
            Solutions.Clear();
            var solution = new List<int>();
            RecursivelySolve(0, solution);
            IsSolved = true;
        }

        private void RecursivelySolve(int row, List<int> solution)
        {
            if (row == Size)
            {
                Solutions.Add(new List<int>(solution));
                return;
            }

            for (int col = 0; col < Size; col++)
            {
                if (IsSafe(row, col))
                {
                    PlaceQueenAndMarkUnsafe(row, col, true);
                    solution.Add(col);
                    RecursivelySolve(row + 1, solution);

                    PlaceQueenAndMarkUnsafe(row, col, false);
                    if (solution.Count > 0)
                    {
                        solution.RemoveAt(solution.Count - 1);
                    }
                }
            }
        }

        private void PlaceQueenAndMarkUnsafe(int row, int col, bool mark)
        {
            // here is the place of the queen itself
            for (int i = 0; i < Size; i++)
            {
                Queens[row, i] += mark ? 1 : -1;
            }
            for (int i = 0; i < Size; i++)
            {
                if (i == row)
                {
                    continue;
                }
                Queens[i, col] += mark ? 1 : -1;
            }

            for (int i = 1; i < Size; i++)
            {
                if (row + i >= Size || col + i >= Size)
                {
                    break;
                }

                Queens[row + i, col + i] += mark ? 1 : -1;
            }

            for (int i = 1; i < Size; i++)
            {
                if (row - i < 0 || col - i < 0)
                {
                    break;
                }
                Queens[row - i, col - i] += mark ? 1 : -1;
            }

            for (int i = 1; i < Size; i++)
            {
                if (row + i >= Size || col - i < 0)
                {
                    break;
                }
                Queens[row + i, col - i] += mark ? 1 : -1;
            }

            for (int i = 1; i < Size; i++)
            {
                if (row - i < 0 || col + i >= Size)
                {
                    break;
                }
                Queens[row - i, col + i] += mark ? 1 : -1;
            }
        }

        private bool IsSafe(int row, int col)
        {
            return row >= 0 && row < Size &&
                   col >= 0 && col < Size &&
                   Queens[row, col] == 0;
        }
    }
}

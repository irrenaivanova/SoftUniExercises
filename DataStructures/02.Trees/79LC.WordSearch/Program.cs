
int n = int.Parse(Console.ReadLine());
int m = int.Parse(Console.ReadLine());
char[,] board = new char[n,m];

for (int i = 0; i < n; i++)
{
    string row = Console.ReadLine();
    for (int j = 0; j < m; j++)
    {
        board[i,j] = row[j];
    }
}

string word = Console.ReadLine();
Console.WriteLine(Exist(board,word));

bool Exist(char[,] matrix, string word)
{
    throw new NotImplementedException();
}
// за по - добро решение, речникът започва да се прави, когато открием символ,
// от кйто сме пуснали БФС,не тръгваме от това колко дистинкт имаме,
// не търсим непрекъснато старт, а директно караме по квадратчетата,
// и си правим една нова матрица виситед с true и false 
// решава се проблема, ако имаме * като символ


int n = int.Parse(Console.ReadLine());
int m = int.Parse(Console.ReadLine()); 
char[,] matrix = new char[n, m];

List<char> distinct = new List<char>();
SortedDictionary<char,int> output = new SortedDictionary<char,int>();

for (int i = 0; i < n; i++)
{
	string input= Console.ReadLine();
	distinct.AddRange(input.ToCharArray().Distinct());
	for (int j = 0; j < m; j++)
	{
		matrix[i, j] = input[j];
	}
}
distinct = distinct.Distinct().ToList();

for (int i = 0;i < distinct.Count; i++)
{
	output.Add(distinct[i], 0);
}

foreach (var letter in distinct)
{
	while(true)
	{
        int[] start = FindTheStart(matrix, letter);
        if (start[0]==-1)
        {
            break;
        }
        FindTheConnectedArea(matrix, start[0], start[1],letter);
        output[letter]++;
	}
}

PrintTheOutput(output);

void FindTheConnectedArea(char[,] matrix, int row, int col, char letter)
{
    if (!IsInTheMatrix(row,col) || matrix[row,col]!=letter)
    {
        return;
    }
    matrix[row, col] = '*';

    FindTheConnectedArea(matrix, row+1, col, letter);
    FindTheConnectedArea(matrix, row-1, col, letter);
    FindTheConnectedArea(matrix, row, col+1, letter);
    FindTheConnectedArea(matrix, row, col-1, letter);
}

bool IsInTheMatrix(int row, int col)
{
    if (row<0 || col<0 || row>=matrix.GetLength(0) || col >=matrix.GetLength(1))
    {
        return false;
    }
    return true;
}

int[] FindTheStart(char[,] matrix, char letter)
{
    int[] start = new int[2];
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            if (matrix[i, j] == letter)
            {
                start[0] = i;
                start[1] = j;
                return start;
            }
        }
    }
    return new int[2] { -1, -1 };
}

void PrintTheOutput(SortedDictionary<char, int> output)
{
    Console.WriteLine($"Areas: {output.Values.Sum()}");
    Console.WriteLine(string.Join("\n",output.Select(x=>$"Letter '{x.Key}' -> '{x.Value}'")));
}
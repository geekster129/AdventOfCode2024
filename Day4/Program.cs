using System.Text;

string[] input = File.ReadAllLines("puzzle4.txt");
//string[] input = File.ReadAllLines("test.txt");

Console.WriteLine($"p1: {Part1(input)}");
Console.WriteLine($"p2: {Part2(input)}");

char Get(char[][] grid, int row, int col)
{
    if (row < 0 || row > grid.Length-1)
    {
        return '\0';
    }
    else
    {
        if (col < 0 || col > grid[row].Length-1)
        {
            return '\0';
        }
    }
    return grid[row][col];
}

int Part1(string[] input)
{
    var grid = GetGrid(input);
    var occurence = 0;
    for (int row = 0; row < grid.Length; row++)
    {
        for (int col = 0; col < grid[row].Length; col++)
        {
            if (grid[row][col] == 'X')
            {
                var east = new StringBuilder();
                var west = new StringBuilder();
                var north = new StringBuilder();
                var south = new StringBuilder();
                var ne = new StringBuilder();
                var nw = new StringBuilder();
                var se = new StringBuilder();
                var sw = new StringBuilder();
                for (var i = 0; i < 4; i++)
                {
                    east.Append(Get(grid, row, col + i));
                    west.Append(Get(grid, row, col - i));
                    north.Append(Get(grid, row - i, col));
                    south.Append(Get(grid, row + i, col));
                    ne.Append(Get(grid, row - i, col + i));
                    nw.Append(Get(grid, row - i, col - i));
                    se.Append(Get(grid, row + i, col + i));
                    sw.Append(Get(grid, row + i, col - i));
                }

                string xmas = "XMAS";
                if (east.ToString() == xmas) occurence++;
                if (west.ToString() == xmas) occurence++;
                if (north.ToString() == xmas) occurence++;
                if (south.ToString() == xmas) occurence++;
                if (ne.ToString() == xmas) occurence++;
                if (nw.ToString() == xmas) occurence++;
                if (se.ToString() == xmas) occurence++;
                if (sw.ToString() == xmas) occurence++;
            }
        }
    }
    return occurence;
}

int Part2(string[] input)
{
    var grid = GetGrid(input);
    var occurence = 0;
    for (int row = 0; row < grid.Length; row++)
    {
        for (int col = 0; col < grid[row].Length; col++)
        {
            if (grid[row][col] == 'A' && row > 0)
            {
                var ne = new StringBuilder();
                var nw = new StringBuilder();
                var se = new StringBuilder();
                var sw = new StringBuilder();
                for (var i = 0; i < 2; i++)
                {
                    ne.Append(Get(grid, row - i, col + i));
                    nw.Append(Get(grid, row - i, col - i));
                    se.Append(Get(grid, row + i, col + i));
                    sw.Append(Get(grid, row + i, col - i));
                }
                
                if (ne.ToString() == "AS" && nw.ToString() == "AM" && se.ToString() == "AS" && sw.ToString() == "AM") occurence++;
                if (ne.ToString() == "AM" && nw.ToString() == "AS" && se.ToString() == "AM" && sw.ToString() == "AS") occurence++;
                if (ne.ToString() == "AS" && nw.ToString() == "AS" && se.ToString() == "AM" && sw.ToString() == "AM") occurence++;
                if (ne.ToString() == "AM" && nw.ToString() == "AM" && se.ToString() == "AS" && sw.ToString() == "AS") occurence++;
            }
        }
    }
    return occurence;
}

char[][] GetGrid(string[] input)
{
    List<char[]> grid = [];
    foreach (var line in input)
    {
        char[] chars = line.ToCharArray();
        grid.Add(chars);
    }
    return grid.ToArray();
}
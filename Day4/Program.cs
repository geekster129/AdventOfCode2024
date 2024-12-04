using System.Text;

string[] input = File.ReadAllLines("puzzle4.txt");
//string[] input = File.ReadAllLines("test.txt");

Console.WriteLine($"p1: {Part1(input)}");
Console.WriteLine($"p2: {Part2(input)}");

char Get(char[][] grid, int x, int y)
{
    if (x < 0 || x > grid.Length-1)
    {
        return '\0';
    }
    else
    {
        if (y < 0 || y > grid[x].Length-1)
        {
            return '\0';
        }
    }
    return grid[x][y];
}

int Scan(char[][] grid)
{
    var occurence = 0;
    for (int posX = 0; posX < grid.Length; posX++)
    {
        for (int posY = 0; posY < grid[posX].Length; posY++)
        {
            if (grid[posX][posY] == 'X')
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
                    east.Append(Get(grid, posX + i, posY));
                    west.Append(Get(grid, posX - i, posY));
                    north.Append(Get(grid, posX, posY - i));
                    south.Append(Get(grid, posX, posY + i));
                    ne.Append(Get(grid, posX + i, posY - i));
                    nw.Append(Get(grid, posX - i, posY - i));
                    se.Append(Get(grid, posX + i, posY + i));
                    sw.Append(Get(grid, posX - i, posY + i));
                }
                Console.WriteLine($"Left: {east}");
                Console.WriteLine($"Right: {west}");
                Console.WriteLine($"Down: {south}");
                Console.WriteLine($"Up: {north}");
                Console.WriteLine($"Up-Right: {ne}");
                Console.WriteLine($"Up-Left: {nw}");
                Console.WriteLine($"Down-Right: {se}");
                Console.WriteLine($"Down-Left: {sw}");
                Console.WriteLine("============");

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

int Part1(string[] input)
{
    List<char[]> grid = [];
    foreach(var line in input) 
    {
        char[] chars = line.ToCharArray();
        grid.Add(chars);
    }
    var newGrid = grid.ToArray();
    return Scan(newGrid);
}

int Part2(string[] input)
{
   return 0;
}
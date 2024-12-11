using System.Diagnostics;

bool isTest = false;

if (isTest)
{
    string[] input = File.ReadAllLines("test.txt");
    var p1 = Part1(input);
    var p2 = Part2(input);

    Debug.Assert(p1 == 14);
    Debug.Assert(p2 == 0);

    Console.WriteLine("Success!");

}
else
{
    string[] input = File.ReadAllLines("puzzle8.txt");
    Console.WriteLine($"p1: {Part1(input)}");
    Console.WriteLine($"p2: {Part2(input)}");
}

int Part1(string[] input)
{
    int cnt = 0;
    var antiNodeGrid = new string[input.Length,input[0].Length];
    Dictionary<char, List<Tuple<int, int>>> antPos = [];

    // Stage 1 - get antenna positions into a hashmap
    for (int row = 0; row < input.Length; row++)
    {
        for (int col = 0; col < input[row].Length; col++)
        {
            var elem = input[row][col];
            if (elem != '.' && elem != '#')
            {
                if (!antPos.TryGetValue(elem, out List<Tuple<int, int>>? value))
                {
                    antPos[elem] = [new(row, col)];
                }
                else
                {
                    value.Add(new(row, col));
                }
            }
        }       
    }

    // Stage 2 - read antenna positions from the hashmap and calculate all possible antinodes
    foreach (var antenna in antPos.Keys)
    {
        for (int k = 0; k < antPos[antenna].Count - 1; k++)
        {
            var posRow1 = antPos[antenna][k].Item1;
            var posCol1 = antPos[antenna][k].Item2;

            for (int z = k; z < antPos[antenna].Count - 1; z++) 
            { 
                var posRow2 = antPos[antenna][z + 1].Item1;
                var posCol2 = antPos[antenna][z + 1].Item2;

                var rowDistance = posRow2 - posRow1;
                var colDistance = posCol1 - posCol2;

                var gridMaxCol = input[0].Length;
                var gridMaxRow = input.Length;

                if (colDistance > 0) // pair is on the left
                {
                    // antinode at top-right

                    if (posRow2 - (rowDistance * 2) >= 0 && posCol2 + (colDistance * 2) < gridMaxCol)
                    {
                        antiNodeGrid[posRow2 - (rowDistance * 2), posCol2 + (colDistance * 2)] = "#";
                    }

                    // antinode at bottom-left
                    if (posRow1 + (rowDistance * 2) < gridMaxRow && posCol1 - (colDistance * 2) >= 0)
                    {
                        antiNodeGrid[posRow1 + (rowDistance * 2), posCol1 - (colDistance * 2)] = "#";
                    }
                }
                else // pair is on the right
                {
                    colDistance = Math.Abs(colDistance);
                    // antinode at top-left
                    if (posRow2 - (rowDistance * 2) >= 0 && posCol2 - (colDistance * 2) >= 0)
                    {
                        antiNodeGrid[posRow2 - (rowDistance * 2), posCol2 - (colDistance * 2)] = "#";
                    }

                    // antinode at bottom-right
                    if (posRow1 + (rowDistance * 2) < gridMaxRow && posCol1 + (colDistance * 2) < gridMaxCol)
                    {
                        antiNodeGrid[posRow1 + (rowDistance * 2), posCol1 + (colDistance * 2)] = "#";
                    }
                }
            }
        }        
    }

    // Stage 3 find all the distinct antinode positions
    for (int row = 0; row < antiNodeGrid.GetLength(0); row++)
    {
        for (int col = 0; col < antiNodeGrid.GetLength(1); col++)
        {
            Console.Write(antiNodeGrid[row, col] ?? ".");
            if (antiNodeGrid[row, col] == "#")
            {
                cnt++;
            }
        }
        Console.WriteLine();
    }
    return cnt;
}



int Part2(string[] input)
{
    return 0;
}
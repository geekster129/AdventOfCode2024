string[] lines = File.ReadAllLines("/workspaces/AdventOfCode2024/Day2/puzzle2.txt");

Part1(lines);
Part2(lines);

bool isSafe(string[] levels)
{
    Dictionary<string, int> diffMap = [];
    List<int> threshold = [];
    for (int j = 1; j < levels.Length; j++)
    {
        var diff = Convert.ToInt32(levels[j]) - Convert.ToInt32(levels[j - 1]);
        var symbol = diff > 0 ? "+" : "-";
        diffMap[symbol] = 1;
        threshold.Add(Math.Abs(diff));
    }
    return !threshold.Any(t => (t < 1 || t > 3)) && diffMap.Count == 1;
}

void Part1(string[] lines)
{
    var safeCnt = 0;
    for(int line=0;line<lines.Length;line++) 
    {
        var levels = lines[line].Split();
        if (isSafe(levels)) safeCnt++;
    }
    Console.WriteLine($"p1: {safeCnt}");
}

void Part2(string[] lines)
{
    var safeCnt = 0;
    for (int line = 0; line < lines.Length; line++)
    {
        var levels = lines[line].Split();
        if (isSafe(levels)) safeCnt++;
        else
        {
            for (int k = 0; k < levels.Length; k++)
            {
                var newList = levels.Where((val, idx) => idx != k).ToArray();                                
                if(isSafe(newList))
                {
                    safeCnt++;
                    break;
                }
            }
        }
    }
    Console.WriteLine($"p2: {safeCnt}");
}
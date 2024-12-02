string[] lines = File.ReadAllLines("/workspace/AdventOfCode2024/Day2/puzzle2.txt");

Part1(lines);
Part2(lines);

bool isSafe(string[] levels)
{
    Dictionary<string, int> diffMap = [];

    List<int> threshold = [];
    for (int j = 0; j < levels.ToList().Count; j++)
    {
        if (j > 0)
        {
            var diff = Convert.ToInt32(levels[j]) - Convert.ToInt32(levels[j - 1]);
            if (diff > 0)
            {
                diffMap["+"] = 1;
            }
            else
            {
                diffMap["-"] = 1;
            }

            threshold.Add(Math.Abs(diff));

        }
    }

    var safeThreshold = !threshold.Any(t => (t < 1 || t > 3));
    return safeThreshold && diffMap.Count == 1;
}

void Part1(string[] lines)
{
    var safeCnt = 0;
    for(int line=0;line<lines.ToList().Count;line++) 
    {
        var levels = lines[line].Split();
        if (isSafe(levels)) safeCnt++;
    }
    Console.WriteLine($"p1: {safeCnt}");
}

void Part2(string[] lines)
{
    var safeCnt = 0;
    for (int line = 0; line < lines.ToList().Count; line++)
    {
        var levels = lines[line].Split();
        if (isSafe(levels))
        {
            safeCnt++;
        }
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
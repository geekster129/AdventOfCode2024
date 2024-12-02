string[] lines = File.ReadAllLines("/workspaces/AdventOfCode2024/Day2/puzzle2.txt");

//Part1(lines);
//Part2(lines);

void Part1(string[] lines)
{
    var safeCnt = 0;
    for(int line=0;line<lines.ToList().Count;line++) 
    {
        var levels = lines[line].Split();
        Dictionary<string,int> diffMap = [];
        
        List<int> threshold = [];
        for(int j=0;j<levels.ToList().Count;j++) {
            if(j>0) {
                var diff = Convert.ToInt32(levels[j])-Convert.ToInt32(levels[j-1]);
                if(diff>0) {
                   diffMap["+"]=1;
                }
                else {
                    diffMap["-"]=1;
                }

                threshold.Add(Math.Abs(diff));
                
            }
        }

        var safeThreshold = threshold.Count(t => (t<1 || t>3)) == 0;
        var judgment = safeThreshold && diffMap.Count == 1;
        Console.WriteLine($"Data: {lines[line]}, SafeThreshold: {safeThreshold}, Thresholds: {String.Join(",",threshold)}, Number of rates: {diffMap.Count}, Judgment: {judgment}");
        if(judgment)
        {
            safeCnt++;
        }
    }
    Console.WriteLine($"p1: {safeCnt}");
}

void Part2(string[] lines)
{
    var safeCnt = 0;
    for(int line=0;line<lines.ToList().Count;line++) 
    {
        var levels = lines[line].Split();
        Dictionary<string,int> diffMap = [];
        
        List<int> threshold = [];
        for(int j=0;j<levels.ToList().Count;j++) {
            if(j>0) {
                var diff = Convert.ToInt32(levels[j])-Convert.ToInt32(levels[j-1]);
                if(diff>0) {
                    if(diffMap.ContainsKey("+")) {
                        diffMap["+"]++;
                    }
                    else {
                        diffMap["+"]=1;
                    }
                }
                else if(diff<0) {
                    if(diffMap.ContainsKey("-")) {                        
                        diffMap["-"]++;
                    }
                    else {
                        diffMap["-"]=1;
                    }
                }

                threshold.Add(Math.Abs(diff));
                
            }
        }

        var safeThreshold = threshold.Count(t => (t<1 || t>3));
        var judgment = safeThreshold<2 && diffMap.Count == 1;
        if(diffMap.Count==1) {
            //safeCnt++;
            //Console.WriteLine($"Data: {lines[line]}, SafeThreshold: {safeThreshold}, Thresholds: {String.Join(",",threshold)}, Number of rates: {diffMap.Count}, Judgment: {judgment}");
        }
        else 
        {
            //if(diffMap["+"]==1 && diffMap["-"]==1) {
            //    Console.WriteLine($"Data: {lines[line]}, SafeThreshold: {safeThreshold}, Thresholds: {String.Join(",",threshold)}, Number of rates (I/D): {diffMap["+"]}/{diffMap["-"]}, Judgment: {judgment}");
            //}
        }
  
        if(judgment)
        {
            Console.WriteLine($"OK Data: {lines[line]}, SafeThreshold: {safeThreshold}, number of rates: {diffMap.Count}");
            safeCnt++;
        }
        else {
            Console.WriteLine($"NG Data: {lines[line]}, SafeThreshold: {safeThreshold}, number of rates: {diffMap.Count}");
        }
    }
    Console.WriteLine($"p2: {safeCnt}");
}
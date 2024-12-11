string input = File.ReadAllText("puzzle11.txt");

Console.WriteLine($"p1: {Part1(input)}");
Console.WriteLine($"p2: {Part2(input)}");

long GetNewStones(string input, int blinkTimes) {
    Dictionary<long, long> aggregateMap = input.Split().GroupBy(x => Convert.ToInt64(x)).ToDictionary(x => x.Key, x => 1L);
    for(int i = 0; i < blinkTimes; i++) {
        foreach(var stone in aggregateMap.ToList())
        {
            aggregateMap[stone.Key] -= stone.Value;

            var stoneStr = stone.Key.ToString();
            if(stoneStr == "0") 
            {
                aggregateMap.TryAdd(1, 0L);
                aggregateMap[1] += stone.Value;
            }
            else if(stoneStr.Length%2 == 0) 
            {            
                var mid = stoneStr.Length/2;
                var left = Convert.ToInt64(stoneStr[..mid]);
                var right = Convert.ToInt64(stoneStr[mid..]);

                aggregateMap.TryAdd(left, 0L);
                aggregateMap.TryAdd(right, 0L);

                aggregateMap[left] += stone.Value;
                aggregateMap[right] += stone.Value;
            }
            else
            {
                aggregateMap.TryAdd(Convert.ToInt64(stoneStr) * 2024, 0L);
                aggregateMap[Convert.ToInt64(stoneStr) * 2024] += stone.Value;    
            }

        }
        //Console.WriteLine(string.Join(" ", aggregateMap.Keys));
        

    }
    return aggregateMap.Values.Sum();
}

long Part1(string input)
{
    return GetNewStones(input, 25);
}

long Part2(string input)
{
   return GetNewStones(input, 75);
}
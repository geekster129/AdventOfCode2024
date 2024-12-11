using System;
using System.Linq;
using System.Text;

string input = File.ReadAllText("test.txt");

Console.WriteLine($"p1: {Part1(input)}");
Console.WriteLine($"p2: {Part2(input)}");

int GetNewStones(string input, int blinkTimes) {
    var stones = input.Split().Select(x => Convert.ToInt64(x)).ToList();
    List<long> changedStones = [];
    for(int i = 0; i < blinkTimes; i++) {
        foreach(var stone in stones.ToList())
        {
            var stoneStr = stone.ToString();
            if(stoneStr == "0") 
            {
                changedStones.Add(1);
            }
            else if(stoneStr.Length%2 == 0) 
            {            
                var mid = stoneStr.Length/2;
                var left = stoneStr.Substring(0, mid);
                var right = stoneStr.Substring(mid, mid);
                changedStones.Add(Convert.ToInt64(left));
                changedStones.Add(Convert.ToInt64(right));
            }
            else
            {
                changedStones.Add(Convert.ToInt64(stone)*2024);
            }        
        }
        //Console.WriteLine(string.Join(" ", changedStones));
        

        stones = changedStones;
        Console.WriteLine($"{i}: {stones.Count}");
        changedStones = [];
    }
    return stones.Count;
}

int Part1(string input)
{
    return GetNewStones(input, 25);
}

int Part2(string input)
{
   return GetNewStones(input, 75);
}
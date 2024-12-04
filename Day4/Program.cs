using System;
using System.Linq;
using System.Text.RegularExpressions;

//string input = File.ReadAllText("puzzle4.txt");
string[] input = File.ReadAllLines("test.txt");

Console.WriteLine($"p1: {Part1(input)}");
Console.WriteLine($"p2: {Part2(input)}");

int Part1(string[] input)
{
    var sum = 0;
    foreach(var line in input) 
    {
        var xmasCnt = Regex.Matches(line, "XMAS", RegexOptions.None, TimeSpan.FromSeconds(1)).Count;
        var samxCnt = Regex.Matches(line, "SAMX", RegexOptions.None, TimeSpan.FromSeconds(1)).Count;
        Console.WriteLine($"{line} {xmasCnt} {samxCnt}");
        sum += xmasCnt + samxCnt;
    }

    return sum;
}

int Part2(string[] input)
{
   return 0;
}
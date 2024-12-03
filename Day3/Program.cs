using System.Text.RegularExpressions;
using System.Text;

string input = File.ReadAllText("d:\\AdventOfCode2024\\Day3\\puzzle3.txt");

Console.WriteLine($"p1: {Part1(input)}");
Console.WriteLine($"p2: {Part2(input)}");

int Part1(string input) {
    int sum = 0;
    var pattern = @"mul\((\d+),(\d+)\)";
    try 
    {
         foreach (Match match in Regex.Matches(input, pattern, RegexOptions.None,TimeSpan.FromSeconds(1))) 
         {
            var val1 = Convert.ToInt32(match.Groups[1].Value);
            var val2 = Convert.ToInt32(match.Groups[2].Value);
            sum += val1*val2;
         }
    }
    catch (RegexMatchTimeoutException) {

    }    
    return sum;
}

int Part2(string input)
{
    var enabledString = new StringBuilder();
    foreach (var instruction in input.Split("do()"))
    {
        enabledString.Append(instruction.Split("don\'t()")[0]);
    }
    return Part1(enabledString.ToString());
}
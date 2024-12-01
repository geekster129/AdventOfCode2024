List<int> leftList = [];
List<int> rightList = [];

string[] lines = File.ReadAllLines("D:\\AdventOfCode2024\\Day1\\puzzle1.txt");

foreach(string line in lines)
{
    var leftElement = Convert.ToInt32(line.Split("  ")[0]);
    var rightElement = Convert.ToInt32(line.Split("  ")[1]);
    leftList.Add(leftElement);
    rightList.Add(rightElement);
}

var leftListedSorted = leftList.Order().ToList();
var rightListedSorted = rightList.Order().ToList();

int totalDistance = 0;
for(int cnt = 0; cnt < leftListedSorted.Count(); cnt++) 
{    
    totalDistance += Math.Abs(leftListedSorted[cnt] - rightListedSorted[cnt]);
}
Console.WriteLine($"Total distance is: {totalDistance}");
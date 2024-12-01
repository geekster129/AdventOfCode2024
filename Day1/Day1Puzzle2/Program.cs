List<int> leftList = [];
List<int> rightList = [];

string[] lines = File.ReadAllLines("D:\\AdventOfCode2024\\Day1\\puzzle1.txt");

foreach (string line in lines)
{
    var leftElement = Convert.ToInt32(line.Split("  ")[0]);
    var rightElement = Convert.ToInt32(line.Split("  ")[1]);
    leftList.Add(leftElement);
    rightList.Add(rightElement);
}

int similarityScore = 0;

//O(n^2)
//for (int cnt = 0; cnt < leftList.Count; cnt++)
//{
//    var leftElement = leftList[cnt];
//    var rightOccurences = rightList.Count(rightElement => (leftElement == rightElement));
//    similarityScore += (leftElement * rightOccurences);
//}

//O(n)
Dictionary<int, int> map = [];
foreach (var rightElem in rightList)
{
    if(map.TryGetValue(rightElem, out int value))
    {
        map[rightElem] = ++value;
    }
    else
    {
        map[rightElem] = 1;
    }
}

foreach(var leftElem in leftList)
{
    var occurences = map.TryGetValue(leftElem, out int value) ? value : 0;
    similarityScore += (leftElem * occurences);
}

Console.WriteLine($"Simularity score is: {similarityScore}");
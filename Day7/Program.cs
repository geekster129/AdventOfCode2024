using System.Data;
using System.Diagnostics;
using System.Text;

bool isTest = false;

if (isTest)
{
    string[] input = File.ReadAllLines("test.txt");
    var p1 = Part1(input);
    var p2 = Part2(input);

    Debug.Assert(p1 == 3749);
    Debug.Assert(p2 == 0);

    Console.WriteLine("Success!");

}
else
{
    string[] input = File.ReadAllLines("puzzle7.txt");
    Console.WriteLine($"p1: {Part1(input)}");
    Console.WriteLine($"p2: {Part2(input)}");
}

long Part1(string[] lines)
{
    long sum = 0;
    foreach(var line in lines)
    {
        var result = Convert.ToInt64(line.Split(":")[0]);
        var operands = line.Split(':')[1].TrimStart().Split();
        List<string> ops = [];
        double OpLen = Math.Pow((double)2, (double)(operands.Length - 1));
        bool found = false;

        for (int k = 0; k < OpLen; k++)
        {
            var bin = Convert.ToString(k, 2).PadLeft(Convert.ToInt32(operands.Length - 1), '0');
            bin = bin.Replace('0', '+');
            bin = bin.Replace('1', '*');
            ops.Add(bin);
        }
        foreach(string combo in ops)
        {
            var resultToCompare = Convert.ToInt64(operands[0]);
            for (int x = 0; x< combo.Length;x++)
            {
                if (combo[x]=='+')
                {
                    resultToCompare += Convert.ToInt32(operands[x+1]);
                }
                else
                {
                    resultToCompare *= Convert.ToInt32(operands[x+1]);
                }
            }
            if(resultToCompare == result)
            {
                sum += resultToCompare;
                found = true;
                break;
            }
            Console.WriteLine(String.Join(",", ops));
        }        


        if(!found)
        {


        }
    }

    return sum;
}

int Part2(string[] lines)
{
    return 0;
}

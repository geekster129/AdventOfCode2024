using System;
using System.Linq;
using System.Text;

string input = File.ReadAllText("puzzle9.txt");

Console.WriteLine($"p1: {Part1(input)}");
Console.WriteLine($"p2: {Part2(input)}");

// test - 2333133121414131402 to 00...111...2...333.44.5555.6666.777.888899
int Part1(string input)
{
    var checksum = 0;
    StringBuilder block = new StringBuilder();
    for(int i = 0;i<=input.Length/2; i++ ) 
    {
        int usage = Convert.ToInt32(input[(i*2)].ToString());        
        block.Append(new string(i.ToString().ToCharArray()[0], usage));

        if((i*2)+1 < input.Length)
        {
            int free = Convert.ToInt32(input[(i*2)+1].ToString());
            block.Append(new string('.', free));
        }
    }

    var defragged = "";
    var finalBlock = block.ToString().ToCharArray();
    for(int k = finalBlock.Length - 1; k > 0; k--) 
    {
        var lastNum = block[k];
        var firstFreePos = new string(finalBlock).Split('.')[0].Length;        
        finalBlock[k] = '.';
        finalBlock[firstFreePos]=lastNum;
        defragged = new string(finalBlock).TrimEnd('.');
        if(!defragged.Contains('.'))
            break; 
    }

    Console.WriteLine(defragged);
    var xDefrag = defragged.ToCharArray().Select(x => x).ToList();
    for(int x = 0; x < xDefrag.Count; x++) 
    {
        var num = Convert.ToInt32(xDefrag[x].ToString());
        checksum += x * num;
    }

    return checksum;
}

int Part2(string input)
{
   int sum = 0;
   return sum;
}
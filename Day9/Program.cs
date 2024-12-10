using System;
using System.Linq;
using System.Text;

string input = File.ReadAllText("puzzle9.txt");

Console.WriteLine($"p1: {Part1(input)}");
Console.WriteLine($"p2: {Part2(input)}");

List<string> repeatedString(string str, int times) 
{
    return Enumerable.Repeat(str, times).ToList();
}

int findFreeSpace(List<string> str) {
    for(int x = 0;x <str.Count; x++)
    {    
        if(str[x]==".") {  
            return x;
        }
    }
    return 0;
}


List<string> TrimEnd(List<string> lst) 
{
    
    int last = 0;
    for(int x = lst.Count-1; x>0; x--) 
    {
        if(lst[x]!=".") 
        {
            last = x+1;
            break;
        }        
    }    
    return lst.Take(last).ToList();

}

// test - 2333133121414131402 to 00...111...2...333.44.5555.6666.777.888899
long Part1(string input)
{
    long checksum = 0;
    List<string> block = [];
    for(int i = 0;i<=input.Length/2; i++ ) 
    {
        int usage = Convert.ToInt32(input[(i*2)].ToString());        
        block.AddRange(repeatedString(i.ToString(), usage));

        if((i*2)+1 < input.Length)
        {
            int free = Convert.ToInt32(input[(i*2)+1].ToString());
            block.AddRange(repeatedString(".", free));
        }
    }

    List<string> defragged = [];
    for(int k = block.Count - 1; k > 0; k--) 
    {
        var lastNum = block[k];
        var firstFreePos = findFreeSpace(block);             
        block[k] = ".";
        block[firstFreePos]=lastNum;
        defragged = TrimEnd(block);
        if(!defragged.Any(d => d == "."))
            break; 
    }

    for(int x = 0; x < defragged.Count; x++) 
    {
        var num = Convert.ToInt32(defragged[x]);
        checksum += x * num;
    }
    
    return checksum;
}

int Part2(string input)
{
   int sum = 0;
   return sum;
}
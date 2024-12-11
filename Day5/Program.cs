using System.Data;
using System.Text;

string input = File.ReadAllText("puzzle5.txt");
//string[] input = File.ReadAllLines("test.txt");

//Console.WriteLine($"p1: {Part1(input)}");
Console.WriteLine($"p2: {Part2(input)}");

int Part1(string[] lines)
{
    int sum = 0;
    int cnt = 0;
    Dictionary<string, int> orders = [];
    foreach (string line in lines) {
        if(line.Contains('|')) 
        {
            orders[line] =1;        
        }
        else if(line.Contains(',')) 
        {
            var list = line.Split(",");
            var isOk = true;
            for(int i=0;i< list.Length-1;i++) 
            {
                if (!orders.ContainsKey($"{list[i]}|{list[i + 1]}"))
                {
                    isOk = false;
                    break;
                }
            }
            if (isOk)
            {
                var midVal = GetMidVal(list);
                sum += midVal;
                cnt++;
            }
        }
    }
    Console.WriteLine(cnt);
    return sum;
}

static List<T> TopologicalSort<T>(HashSet<T> nodes, HashSet<Tuple<T, T>> edges) where T : IEquatable<T>
{
    // Empty list that will contain the sorted elements
    var L = new List<T>();

    // Set of all nodes with no incoming edges
    var S = new HashSet<T>(nodes.Where(n => edges.All(e => e.Item2.Equals(n) == false)));

    // while S is non-empty do
    while (S.Any())
    {

        //  remove a node n from S
        var n = S.First();
        S.Remove(n);

        // add n to tail of L
        L.Add(n);

        // for each node m with an edge e from n to m do
        foreach (var e in edges.Where(e => e.Item1.Equals(n)).ToList())
        {
            var m = e.Item2;

            // remove edge e from the graph
            edges.Remove(e);

            // if m has no other incoming edges then
            if (edges.All(me => me.Item2.Equals(m) == false))
            {
                // insert m into S
                S.Add(m);
            }
        }
    }

    // if graph has edges then
    if (edges.Any())
    {
        // return error (graph has at least one cycle)
        return null;
    }
    else
    {
        // return L (a topologically sorted order)
        return L;
    }
}
int Part2(string lines)
{
    var (updates, comparer) = Parse(lines);
    return updates
        .Where(pages => !Sorted(pages, comparer))
        .Select(pages => pages.OrderBy(p => p, comparer).ToArray())
        .Sum(GetMiddlePage);
}

int GetMidVal(string[] input)
{
    return Convert.ToInt32(input[Convert.ToInt32(Math.Round((decimal)input.Length / 2, MidpointRounding.AwayFromZero)) - 1]);
}


(string[][] updates, Comparer<string>) Parse(string input)
{
    var parts = input.Split("\r\n\r\n");

    var ordering = new HashSet<string>(parts[0].Split("\r\n"));
    var comparer =
        Comparer<string>.Create((p1, p2) => ordering.Contains(p1 + "|" + p2) ? -1 : 1);

    var updates = parts[1].Split("\r\n").Select(line => line.Split(",")).ToArray();
    return (updates, comparer);
}

int GetMiddlePage(string[] nums) => int.Parse(nums[nums.Length / 2]);

bool Sorted(string[] pages, Comparer<string> comparer) =>
    Enumerable.SequenceEqual(pages, pages.OrderBy(x => x, comparer));
using System.Data;
using System.Diagnostics;
using System.Text;

string[] input = File.ReadAllLines("puzzle6.txt");
//string[] input = File.ReadAllLines("test.txt");

//Console.WriteLine($"p1: {Part1(input)}");
Console.WriteLine($"p2: {Part2(input)}");

bool ValidGrid(char grid) => grid == '.' || grid == 'X' || grid == '^';

int Part1(string[] lines)
{
    int cnt = 1;
    List<char[]> map = [];
    bool StateChange = false;
    int row = 6;
    int col = 4;
    State state = State.Up;
    foreach(string line in lines)
    {
        map.Add(line.ToCharArray());
    }

    bool onMap = true;
    
    while(onMap)
    {
        if (StateChange)
        {
            //Thread.Sleep(200);
            
        }

        switch (state)
        {
            case State.Up:
                {
                    if (row > 0)
                    {
                        var nextGrid = map[row - 1][col];
                        if (nextGrid == '#')
                        {
                            state = State.Right;
                            StateChange = true;
                        }                        
                        else if (ValidGrid(nextGrid))
                        {
                            row = row - 1;
                            if (map[row][col] != 'X')
                            {
                                map[row][col] = 'X';
                                cnt++;
                            }
                            StateChange = false;
                        }         
                    }
                    else
                    {
                        onMap = false;
                        break;
                    }
                }
                break;
            case State.Down:
                {
                    if (row < map.Count-1)
                    {
                        var nextGrid = map[row + 1][col];
                        if (nextGrid == '#')
                        {
                            state = State.Left;
                            StateChange = true;

                        }
                        else if (ValidGrid(nextGrid))
                        {
                            row = row + 1;
                            if (map[row][col] != 'X')
                            {
                                map[row][col] = 'X';
                                cnt++;
                            }
                            StateChange = false;
                        }
                    }
                    else
                    {
                        onMap = false;
                        break;
                    }
                }
                break;
            case State.Left:
                {
                    if (col > 0)
                    {
                        var nextGrid = map[row][col - 1];
                        if (nextGrid == '#')
                        {
                            state = State.Up;
                            StateChange = true;
                        }
                        else if (ValidGrid(nextGrid))
                        {
                            col = col - 1;
                            if (map[row][col] != 'X')
                            {
                                map[row][col] = 'X';
                                cnt++;
                            }
                            StateChange = false;
                        };
                        
                    }
                    else
                    {
                        onMap = false;
                        break;
                    }
                }
                break;
            case State.Right:
                {
                    if (col < map[row].Length - 1)
                    {
                        var nextGrid = map[row][col + 1];
                        if (nextGrid == '#')
                        {
                            state = State.Down;
                            StateChange = true;

                        }
                        else if (ValidGrid(nextGrid))
                        {
                            col = col + 1;
                            if (map[row][col] != 'X')
                            {
                                map[row][col] = 'X';
                                cnt++;
                            }
                            StateChange = false;
                        }
                    }
                    else
                    {
                        onMap = false;
                        break;
                    }
                }
                break;
        }

    }
    Console.Clear();
    foreach (var rowx in map)
    {
        foreach (var colx in rowx)
        {
            switch (colx)
            {
                case 'X':
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        //cnt++;
                    }                    
                    break;
                case '.':
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case '#':
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
            }
            Console.Write(colx);
            Console.ResetColor();
        }
        Console.WriteLine();
    }
    Console.WriteLine($"Last pos: {row}, {col}");
    return cnt;
}


int Part2(string[] lines)
{
    int cnt = 0;
    List<char[]> map = [];
    bool StateChange = false;
    int row = 61;
    int col = 78;
    State state = State.Up;
    foreach (string line in lines)
    {
        map.Add(line.ToCharArray());
    }
   
    for (int obsRow = 0; obsRow < map.Count; obsRow++)
    {
        for (int obsCol = 0; obsCol < map[obsRow].Length; obsCol++) {            
            if (map[obsRow][obsCol] == '#') continue;

            map = [];
            foreach (string line in lines)
            {
                map.Add(line.ToCharArray());
            }
            row = 61;
            col = 78;
            state = State.Up;
            map[obsRow][obsCol] = 'O';
            Console.WriteLine($"{obsRow},{obsCol}");
            bool onMap = true;
            var blockedByObs = false;
            var stopwatch = Stopwatch.StartNew();
            while (onMap && stopwatch.ElapsedMilliseconds < 1000)
            {
                if (StateChange)
                {
                    //Thread.Sleep(200);

                }

                switch (state)
                {
                    case State.Up:
                        {
                            if (row > 0)
                            {
                                var nextGrid = map[row - 1][col];
                                if (nextGrid == '#')
                                {
                                    state = State.Right;
                                    StateChange = true;
                                }
                                else if(nextGrid == 'O')
                                {
                                    if (blockedByObs == false)
                                    {
                                        state = State.Right;
                                        StateChange = true;
                                        blockedByObs = true;
                                    }
                                    else
                                    {
                                        cnt++;
                                        onMap = false;
                                        //Console.WriteLine("Revisited - Loop");
                                        break;
                                    }

                                }
                                else if (ValidGrid(nextGrid))
                                {
                                    row = row - 1;
                                    if (map[row][col] != 'X')
                                    {
                                        map[row][col] = 'X';
                                    }
                                    StateChange = false;
                                }
                            }
                            else
                            {
                                onMap = false;
                                //Console.WriteLine("Off map");
                                break;
                            }
                        }
                        break;
                    case State.Down:
                        {
                            if (row < map.Count - 1)
                            {
                                var nextGrid = map[row + 1][col];
                                if (nextGrid == '#')
                                {
                                    state = State.Left;
                                    StateChange = true;

                                }
                                else if (nextGrid == 'O')
                                {
                                    if (blockedByObs == false)
                                    {
                                        state = State.Left;
                                        StateChange = true;
                                        blockedByObs = true;
                                    }
                                    else
                                    {
                                        cnt++;
                                        onMap = false;
                                        //Console.WriteLine("Revisited - Loop");
                                        break;
                                    }

                                }
                                else if (ValidGrid(nextGrid))
                                {
                                    row = row + 1;
                                    if (map[row][col] != 'X')
                                    {
                                        map[row][col] = 'X';
                                    }
                                    StateChange = false;
                                }
                            }
                            else
                            {
                                onMap = false;
                                //Console.WriteLine("Off map");
                                break;
                            }
                        }
                        break;
                    case State.Left:
                        {
                            if (col > 0)
                            {
                                var nextGrid = map[row][col - 1];
                                if (nextGrid == '#')
                                {
                                    state = State.Up;
                                    StateChange = true;
                                }
                                else if (nextGrid == 'O')
                                {
                                    if (blockedByObs == false)
                                    {
                                        blockedByObs = true;
                                        state = State.Up;
                                        StateChange = true;
                                    }
                                    else
                                    {
                                        cnt++;
                                        onMap = false;
                                        //Console.WriteLine("Revisited - Loop");
                                        break;
                                    }

                                }
                                else if (ValidGrid(nextGrid))
                                {
                                    col = col - 1;
                                    if (map[row][col] != 'X')
                                    {
                                        map[row][col] = 'X';
                                    }
                                    StateChange = false;
                                };

                            }
                            else
                            {
                                onMap = false;
                                //Console.WriteLine("Off map");
                                break;
                            }
                        }
                        break;
                    case State.Right:
                        {
                            if (col < map[row].Length - 1)
                            {
                                var nextGrid = map[row][col + 1];
                                if (nextGrid == '#')
                                {
                                    state = State.Down;
                                    StateChange = true;

                                }
                                else if (nextGrid == 'O')
                                {
                                    if (blockedByObs == false)
                                    {
                                        blockedByObs = true;
                                        state = State.Down;
                                        StateChange = true;
                                    }
                                    else
                                    {
                                        cnt++;
                                        onMap = false;
                                        //Console.WriteLine("Revisited - Loop");
                                        break;
                                    }

                                }
                                else if (ValidGrid(nextGrid))
                                {
                                    col = col + 1;
                                    if (map[row][col] != 'X')
                                    {
                                        map[row][col] = 'X';
                                    }
                                    StateChange = false;
                                }
                            }
                            else
                            {
                                onMap = false;
                                //Console.WriteLine("Off map");
                                break;
                            }
                        }
                        break;
                }
            }

            //Console.Clear();
            //foreach (var rowx in map)
            //{
            //    foreach (var colx in rowx)
            //    {
            //        switch (colx)
            //        {
            //            case 'X':
            //                {
            //                    Console.ForegroundColor = ConsoleColor.Green;
            //                    cnt++;
            //                }
            //                break;
            //            case '.':
            //                Console.ForegroundColor = ConsoleColor.Gray;
            //                break;
            //            case '#':
            //                Console.ForegroundColor = ConsoleColor.Red;
            //                break;
            //        }
            //        Console.Write(colx);
            //        Console.ResetColor();
            //    }
            //    Console.WriteLine();
            //}
            //Console.ReadLine();
        }
    }

    return cnt;
}
enum State
{
    Up, Down, Left, Right
}
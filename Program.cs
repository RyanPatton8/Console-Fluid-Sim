using System;
using System.Threading;

class Program
{
    //width and height
    static int width; 
    static int height;
    //create matrix board
    static char[,] grid = {{},{}};
    //water variables
    static char water = '0';
    static int waterAmount = 8;
    
    static void Main(string[] args)
    {
        width = Console.WindowWidth;
        height = Console.WindowHeight;
        Console.CursorVisible = false;

        grid = new char[width, height];
        
        for (int i = 0; i < width - 1; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if(j == height - 1) {
                    Console.SetCursorPosition(i,j);
                    Console.Write('-');
                    grid[i,j] = '-';
                } else {
                    Console.SetCursorPosition(i,j);
                    Console.Write(' ');
                    grid[i,j] = ' ';
                }
                
            }
        }

        Simulate();
    }

    static void Simulate()
    {
        while (true)
        {
            //potentially make terminal height responsive?
            
            //pour water from the top of terminal one water at a time until amount set is empty
            if (waterAmount > 0)
            {
                Console.SetCursorPosition(10,2);
                Console.Write(water);
                grid[10,2] = water;
                waterAmount--; 
            }
            

            //loop through all spaces in terminal to check if current space is water
            for (int i = width - 1; i > 1; i--)
            {
                for (int j = height - 1; j > 1; j--)
                {
                    //if it is choose the next move for that water
                    if (grid[i,j] == water) {
                        //if there is space below the water go there
                        //detect bottom of terminal
                        if (grid[i, j + 1] == ' ') {
                            Console.SetCursorPosition(i, j + 1);
                            Console.Write(water);
                            grid[i, j + 1] = water;

                            Console.SetCursorPosition(i, j);
                            Console.Write(' ');
                            grid[i, j] = ' ';
                        }
                        //provide move random left or right functionality
                    }
                }
            }

            Thread.Sleep(100);  
        }
    }
}

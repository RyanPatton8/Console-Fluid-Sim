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
    static int waterAmount = 20;
    
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
                }else if((j == height - 2 ||j == height - 3) && (i == 7 || i == 15)){
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
                        if (grid[i, j + 1] == ' ') 
                        {
                            Console.SetCursorPosition(i, j + 1);
                            Console.Write(water);
                            grid[i, j + 1] = water;

                            Console.SetCursorPosition(i, j);
                            Console.Write(' ');
                            grid[i, j] = ' ';
                        } 
                        //if there is space both ways choose a random one between them
                        else if(grid[i - 1,j] == ' ' && grid[i + 1, j] == ' ')
                        {
                            Random random = new Random();
                            int decision = random.Next();
                            if(decision > 0 && decision % 2 == 0) 
                            {
                                Console.SetCursorPosition(i + 1, j);
                                Console.Write(water);
                                grid[i + 1, j] = water;

                                Console.SetCursorPosition(i, j);
                                Console.Write(' ');
                                grid[i, j] = ' ';
                            } 
                            else 
                            {
                                Console.SetCursorPosition(i - 1, j);
                                Console.Write(water);
                                grid[i - 1, j] = water;

                                Console.SetCursorPosition(i, j);
                                Console.Write(' ');
                                grid[i, j] = ' ';
                            }
                        }
                        // if you can go left go left
                        else if (grid[i - 1,j] == ' ')
                        {
                            Console.SetCursorPosition(i - 1, j);
                            Console.Write(water);
                            grid[i - 1, j] = water;

                            Console.SetCursorPosition(i, j);
                            Console.Write(' ');
                            grid[i, j] = ' ';
                        }
                        // if you can go right go right
                        else if (grid[i + 1, j] == ' ')
                        {
                            Console.SetCursorPosition(i + 1, j);
                            Console.Write(water);
                            grid[i + 1, j] = water;

                            Console.SetCursorPosition(i, j);
                            Console.Write(' ');
                            grid[i, j] = ' ';
                        }
                    }
                }
            }

            Thread.Sleep(100);  
        }
    }
}

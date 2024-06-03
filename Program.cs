using System;
using System.Threading;

class Program
{
    //width and height
    static int width; 
    static int height;
    //create matrix board
    static public char[,] grid = {{},{}};
    //water variables
    static int waterAmount = 150;
    static List<Object> waterList = new List<Object>();

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
                }else if (i == width - 2 || i == 0) {
                    Console.SetCursorPosition(i,j);
                    Console.Write('-');
                    grid[i,j] = '-';
                }else if((j == height - 2 ||j == height - 3) && (i == 5 || i == 25)){
                    Console.SetCursorPosition(i,j);
                    Console.Write('-');
                    grid[i,j] = '-';
                }else {
                    Console.SetCursorPosition(i,j);
                    Console.Write(' ');
                    grid[i,j] = ' ';
                } 
            }
        }

        Simulate();
    }

    public static void Simulate()
    {
        // create a list of instantiated water objects
        for(int i = waterAmount; i > 0; i--){
            Water water = new Water();
            waterList.Add(water);
        }

        while (true)
        {   // for everyone of them check their position and update it
            foreach (Water water in waterList){
                string direction = water.Move(grid[water.positionX, water.positionY + 1], 
                                              grid[water.positionX - 1, water.positionY], 
                                              grid[water.positionX + 1, water.positionY],
                                              grid[water.positionX - 1, water.positionY + 1],
                                              grid[water.positionX + 1, water.positionY + 1],
                                              grid[water.positionX, water.positionY - 1]);

                if (direction == "below"){
                    Console.SetCursorPosition(water.positionX, water.positionY + 1);
                    Console.Write(water.character);
                    grid[water.positionX, water.positionY + 1] = water.character;

                    Console.SetCursorPosition(water.positionX, water.positionY);
                    Console.Write(' ');
                    grid[water.positionX, water.positionY] = ' ';

                    water.positionY ++;
                }
                else if (direction == "bottomLeft"){
                    Console.SetCursorPosition(water.positionX - 1, water.positionY + 1);
                    Console.Write(water.character);
                    grid[water.positionX - 1, water.positionY + 1] = water.character;

                    Console.SetCursorPosition(water.positionX, water.positionY);
                    Console.Write(' ');
                    grid[water.positionX, water.positionY] = ' ';

                    water.positionX --;
                    water.positionY ++;
                }
                else if (direction == "bottomRight"){
                    Console.SetCursorPosition(water.positionX + 1, water.positionY + 1);
                    Console.Write(water.character);
                    grid[water.positionX + 1, water.positionY + 1] = water.character;

                    Console.SetCursorPosition(water.positionX, water.positionY);
                    Console.Write(' ');
                    grid[water.positionX, water.positionY] = ' ';

                    water.positionX ++;
                    water.positionY ++;
                }
                else if (direction == "left"){
                    Console.SetCursorPosition(water.positionX - 1, water.positionY);
                    Console.Write(water.character);
                    grid[water.positionX - 1, water.positionY] = water.character;

                    Console.SetCursorPosition(water.positionX, water.positionY);
                    Console.Write(' ');
                    grid[water.positionX, water.positionY] = ' ';

                    water.positionX --;
                }
                else if (direction == "right"){
                    Console.SetCursorPosition(water.positionX + 1, water.positionY);
                    Console.Write(water.character);
                    grid[water.positionX + 1, water.positionY] = water.character;

                    Console.SetCursorPosition(water.positionX, water.positionY);
                    Console.Write(' ');
                    grid[water.positionX, water.positionY] = ' ';

                    water.positionX ++;
                }
                else if (direction == "dead"){
                    Console.SetCursorPosition(water.positionX, water.positionY);
                    Console.Write(water.character);
                    grid[water.positionX, water.positionY] = ' ';
                }
            }

            Thread.Sleep(50);  
        }
    }
}

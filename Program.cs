using System;
using System.Threading;


// break the water into lists of 100
// loop through each list
class Program
{
    //width and height of terminal
    static int width; 
    static int height;
    //create a matrix to keep track of all characters in terminal
    static public char[,] grid = {{},{}};
    //water variables
    static public int waterAmount = 1000;//how much water to drop
    static private int waterSpeed = 0;//how long it should wait to loop (effectively how fast the water moves)
    static public List<Object> waterList = new List<Object>();//list to hold and loop through all instances of water

    public static void Simulate()
    {
        while (true)
        {   // for every drop of water check adjacent tiles and move accordingly replacing previous placement with a blank tile
            foreach (Water water in waterList){
                string direction = water.Move(grid[water.positionX, water.positionY + 1], 
                                              grid[water.positionX - 1, water.positionY], 
                                              grid[water.positionX + 1, water.positionY],
                                              grid[water.positionX - 1, water.positionY + 1],
                                              grid[water.positionX + 1, water.positionY + 1]);

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
            }
            //how long to wait until next loop
            Thread.Sleep(waterSpeed);  
        }
    }
    static private void SetFlowRate()
    {
        int potentialRate = 30 - (waterAmount / 100);
        if(potentialRate > 0){
            waterSpeed = potentialRate;
        }
    }

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
                }else if((j == height - 2 ||j == height - 3 ||j == height - 4) && (i == 35 || i == 85)){
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

        for (int i = 1; i < 14; i++){
            Console.SetCursorPosition(40 + i,11 + i);
            Console.Write('-');
            grid[40 + i,11 + i] = '-';
            Console.SetCursorPosition(41 + i,11 + i);
            Console.Write('-');
            grid[41 + i,11 + i] = '-';
        }

        // create a list of instantiated water objects
        for(int i = waterAmount; i > 0; i--){
            Water water = new Water();
            waterList.Add(water);
        }

        SetFlowRate();
        Simulate();
    }
}

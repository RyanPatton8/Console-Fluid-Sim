using System;
using System.Reflection;
using System.Threading;
using Microsoft.VisualBasic;


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
    static public int waterAmount = 200;//how much water to drop
    static private int flowRate = 0;//how long it should wait to loop (effectively how fast the water moves)
    static public List<Object> waterList = new List<Object>();//list to hold and loop through all instances of water
    
    static OverFlowPublisher overFlowPublisher = new OverFlowPublisher();

    public static void Simulate()
    {
        while (true)
        {   // for every drop of water check adjacent tiles and move accordingly replacing previous placement with a blank tile
            foreach (Water water in waterList){
                string direction = water.Move(grid[water.positionX, water.positionY + 1],       //below 
                                              grid[water.positionX - 1, water.positionY],       //left
                                              grid[water.positionX + 1, water.positionY],       //right
                                              grid[water.positionX - 1, water.positionY + 1],   //bottom left
                                              grid[water.positionX + 1, water.positionY + 1],   //bottom right
                                              grid[water.positionX - 1, water.positionY - 1],   //top left
                                              grid[water.positionX + 1, water.positionY - 1],   //top right
                                              grid[water.positionX, water.positionY - 1]);      //above

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
                else if (direction == "topright"){
                    Console.SetCursorPosition(water.positionX + 1, water.positionY - 1);
                    Console.Write(water.character);
                    grid[water.positionX + 1, water.positionY - 1] = water.character;

                    Console.SetCursorPosition(water.positionX, water.positionY);
                    Console.Write(' ');
                    grid[water.positionX, water.positionY] = ' ';

                    water.positionX ++;
                    water.positionY --;
                }
                else if (direction == "topleft"){
                    Console.SetCursorPosition(water.positionX - 1, water.positionY - 1);
                    Console.Write(water.character);
                    grid[water.positionX - 1, water.positionY - 1] = water.character;

                    Console.SetCursorPosition(water.positionX, water.positionY);
                    Console.Write(' ');
                    grid[water.positionX, water.positionY] = ' ';

                    water.positionX --;
                    water.positionY --;
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
                else if (direction == "tryOverFlow")
                {
                    overFlowPublisher.CallEvent();
                }
            }
            //how long to wait until next loop
            Thread.Sleep(flowRate);  
        }
    }

    static private void SetFlowRate()
    {
        int potentialRate = 30 - (waterAmount / 100);

        if(potentialRate > 0){
            flowRate = potentialRate;
        }
    }

    static void Main(string[] args)
    {
        width = Console.WindowWidth;
        height = Console.WindowHeight;
        Console.CursorVisible = false;

        grid = new char[width, height];

        Scene.BlankCanvas(width,height);
        Scene.SteepSlopeR(40,13);
        Scene.SteepSlopeL(62,3);
        Scene.SteepSlopeL(62,16);

        // create a list of instantiated water objects
        for(int i = waterAmount; i > 0; i--){
            Water water = new Water();
            waterList.Add(water);
            overFlowPublisher.OverFlowed += water.OnOverFlowed;
        }

        SetFlowRate();
        Simulate();
    }
}
